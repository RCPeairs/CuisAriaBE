using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CuisAriaBE.Models;
using CuisAriaBE.ViewModels;

namespace CuisAriaBE.Controllers
{
    public class ShoppingListsController : Controller
    {
        private readonly CuisAriaBEContext _context;

        public ShoppingListsController(CuisAriaBEContext context)
        {
            _context = context;
        }

        // GET GetShoppingList/[UserId]
        [HttpGet, Route("GetShoppingList/{userId}")]
        public IActionResult GetShoppingList(int userId)
        {
            var tempShopList = _context.ShoppingLists.FirstOrDefault(s => s.UserId == userId);
            if (tempShopList == null)
            {
                return NotFound();
            }
            var shoppingListId = tempShopList.Id;
            var tmpItemList = from itemListPtr in _context.Items
                              where itemListPtr.ShoppingListId == shoppingListId
                              select itemListPtr;
            var tempItemList = tmpItemList.ToList();

            List<ItemVM> itemList = new List<ItemVM>();
            foreach (Item item in tempItemList)
            {
                var tempItem = new ItemVM();
                tempItem.ItemName = item.ItemName;
                tempItem.ItemQty = item.ItemQty;
                tempItem.ItemUnit = item.ItemUnit;
                itemList.Add(tempItem);
            }

            var shoppingList = new ShoppingListVM();
            shoppingList.ListName = tempShopList.ListName;
            shoppingList.ShoppingListId = tempShopList.Id;
            shoppingList.UserId = tempShopList.UserId;
            shoppingList.Items = itemList;

            return new ObjectResult(shoppingList);
        }

        // POST AddEditShoppingList/[UserId]/[MenuId]
        [HttpPost, Route("AddEditShoppingList/{userId}/{menuId}")]
        public IActionResult Create(int userId, int menuId)
        {
            if (menuId == 0)
            {
                var tempMenu = new Menu();
                tempMenu = _context.Menus.FirstOrDefault(m => m.UserId == userId && m.CurrentMenu == true);
                if (tempMenu == null)
                {
                    return BadRequest();
                }
                menuId = tempMenu.Id;
            } 
            var shoppingListMenu = (_context.Menus.FirstOrDefault(m => m.Id == menuId));
            if (shoppingListMenu == null)
            {
                return BadRequest();
            }

            // Delete existing shopping lists for user.
            // Temporarily restricting shopping lists to one per user.
            var userShoppingLists = from userPtr in _context.ShoppingLists
                                    where userPtr.UserId == userId
                                    select userPtr;
            var tempUserShoppingList = userShoppingLists.ToList();
            if (tempUserShoppingList != null)
            {
                foreach (var sList in tempUserShoppingList)
                {
                    var delItems =  from delPtr in _context.Items
                                   where delPtr.ShoppingListId == sList.Id
                                   select delPtr;
                    var delItemList = delItems.ToList();
                    foreach (var item in delItemList)
                    {
                        _context.Items.Remove(item);
                    }
                    _context.ShoppingLists.Remove(sList);
                    _context.SaveChanges();
                }
            }


            // Add shopping list
            var newShoppingList = new ShoppingList();
            newShoppingList.UserId = shoppingListMenu.UserId;
            newShoppingList.ListName = shoppingListMenu.MenuName;
            _context.ShoppingLists.Add(newShoppingList);
            _context.SaveChanges();

            // Scale menu items and add to tempItemList
            List<Item> tempItemList = new List<Item>();

            // Retrieve recipes
            var tempRecipeList = from recipePtr in _context.MenuRecipe
                                 where recipePtr.MenuId == menuId
                                 select recipePtr;
            var recipeList = tempRecipeList.ToList();
            if (recipeList == null)
            {
                return NoContent();
            }

            // Retrieve ingredients from each recipe
            foreach (MenuRecipe recipe in recipeList)
            {
                var tempRecipe = _context.Recipes.FirstOrDefault(r => r.Id == recipe.RecipeId);
                if (tempRecipe == null)
                {
                    return BadRequest();  // Put shopping list creation in a transaction so an invalid recipeId does not leave orphan items in item database.
                }
                decimal scaleFactor = 0.000m;
                if (recipe.MenuServings > 0)
                {
                    scaleFactor = recipe.MenuServings / tempRecipe.RecipeServings;
                }
                var tmpSteps = from stepsPtr in _context.Steps
                               where stepsPtr.RecipeId == recipe.RecipeId
                               select stepsPtr;
                var tempSteps = tmpSteps.ToList();

                // Add step ingredients to shopping list
                foreach (Step stepPtr in tempSteps)
                {
                    var tmpIngred = from ingredPtr in _context.StepIngredient
                                    where ingredPtr.StepId == stepPtr.Id
                                    select ingredPtr;
                    var tempIngred = tmpIngred.ToList();

                    foreach (StepIngredient Ingred in tempIngred)
                    {
                        var tempItem = new Item();
                        tempItem.ShoppingListId = newShoppingList.Id;
                        var tmpItem = _context.Ingredients.FirstOrDefault(i => i.Id == Ingred.IngredientId);
                        if (tmpItem == null)
                        {
                            return BadRequest();
                        }
                        tempItem.ItemName = tmpItem.IngredName;
                        tempItem.ItemQty = Ingred.IngredQty * scaleFactor;
                        tempItem.ItemUnit = Ingred.IngredUnit;
                        tempItemList.Add(tempItem);
                        //_context.SaveChanges();
                    }  // end process ingredients
                } // end process steps
            } // end process recipes

            // Consolidate duplicate line items
            var groupItemList = from groupItems in tempItemList
                                group groupItems by groupItems.ItemName;

            foreach (var itemGroup in groupItemList)
            {
                // Count number of items to consolidate
                var itemCount = itemGroup.Count();

                if (itemCount > 1)
                {

                    // Find largest unit of measure
                    string[] volumeUnits = { "gallon", "liter", "quart", "pint", "cup", "deciliter", "fluid ounce", "tablespoon", "teaspoon", "milliliter", "dash" , "pinch" };
                    string[] weightUnits = { "kilogram", "pound", "ounce", "gram" };
                    var maxVolUnitIndex = 99;
                    var maxWtUnitIndex = 99;
                    var volumeCount = 0;
                    var weightCount = 0;
                    var eachCount = 0;
                    foreach (Item item in itemGroup)
                    {
                        var tempVolUnit = Array.IndexOf(volumeUnits, item.ItemUnit);
                        var tempWtUnit = Array.IndexOf(weightUnits, item.ItemUnit);
                        if (tempVolUnit >= 0)
                        {
                            volumeCount++;
                            if (maxVolUnitIndex > tempVolUnit)
                            {
                                maxVolUnitIndex = tempVolUnit;
                            }
                        }
                        else
                        if (tempWtUnit >= 0)
                        {
                            weightCount++;
                            if (maxWtUnitIndex > tempWtUnit)
                            {
                                maxWtUnitIndex = tempWtUnit;
                            }
                        }
                        else
                        {
                            eachCount++;
                        }
                    }
                    //var largestUnit = unitList.Substring(unitPosition,11);

                    // Convert units to consistent units and add qtys together
                    decimal[,] volConvertArray = new decimal[12, 12]
                    {{1m, 3.785m, 4m, 8m, 16m, 37.85m, 128m, 256m, 768m, 3785m, 6144m, 12288 },
                     {0.2642m, 1m, 1.057m, 2.113m, 4.227m, 10m, 33.81m, 67.63m, 202.9m, 1000m, 1623.2m, 3246.4m },
                     {0.25m, 0.9464m, 1m, 2m, 4m, 9.464m, 32m, 64m, 192m, 946.4m, 1536m, 3072m },
                     {0.125m, 0.4732m, 0.5m, 1m, 2m, 4.732m, 16m, 32m, 96m, 473.2m, 768m, 1536m },
                     {0.0625m, 0.2366m, 0.25m, 0.5m, 1m, 2.366m, 8m, 16m, 48m, 236.6m, 384m, 768m },
                     {0.02642m, 0.1m, 0.1057m, 0.2113m, 0.4227m, 1m, 3.381m, 6.763m, 20.29m, 100m, 162.32m, 324.64m },
                     {0.007813m, 0.02957m, 0.03125m, 0.0625m, 0.125m, 0.2957m, 1m, 2m, 6m, 29.57m, 48m, 96m },
                     {0.003906m, 0.01479m, 0.01562m, 0.03125m, 0.0625m, 0.1479m, 0.5m, 1m, 3m, 14.79m, 24m, 48m },
                     {0.001302m, 0.004929m, 0.005208m, 0.01042m, 0.02083m, 0.04929m, 0.1667m, 0.3333m, 1m, 4.929m, 8m, 16m },
                     {0.0002642m, 0.001m, 0.001057m, 0.002113m, 0.004227m, 0.01m, 0.03381m, 0.06763m, 0.2029m, 1m, 1.6232m, 3.2464m },
                     {0.0001628m, 0.0006161m, 0.000651m, 0.001302m, 0.002604m, 0.006161m, 0.02083m, 0.04167m, 0.125m, 0.6161m, 1m, 2m },
                     {0.000002625m, 0.0003081m, 0.0003255m, 0.000651m, 00.001302m, 0.003081m, 0.01042m, 0.02083m, 0.0625m, 0.3081m, 0.5m, 1m },};

                    decimal[,] wtConvertArray = new decimal[4, 4]
                    {{1m, 2.205m, 35.27m, 1000m },
                     {0.4536m, 1m, 16m, 453.6m },
                     {0.02835m, 0.0625m, 1m, 28.35m },
                     {0.001m, 0.002205m, 0.03527m, 1m }};

                    var itemVolQty = 0.000m;
                    var itemWtQty = 0.000m;
                    var itemEaQty = 0.000m;

                    foreach (Item item in itemGroup)
                    {
                        if (volumeCount > 1 && Array.IndexOf(volumeUnits, item.ItemUnit) >= 0)
                        {
                            itemVolQty += item.ItemQty * volConvertArray[maxVolUnitIndex, Array.IndexOf(volumeUnits, item.ItemUnit)];
                        }
                        else if (weightCount > 1 && Array.IndexOf(weightUnits, item.ItemUnit) >= 0)
                        {
                            itemWtQty += item.ItemQty * wtConvertArray[maxWtUnitIndex, Array.IndexOf(weightUnits, item.ItemUnit)];
                        }
                        else
                        {
                            itemEaQty += item.ItemQty;
                        }
                    }
                    // Store consolidated item entrys

                    if (volumeCount > 0)
                    {
                        var tempVolItem = new Item();
                        tempVolItem.ShoppingListId = newShoppingList.Id;
                        tempVolItem.ItemName = itemGroup.Key;
                        tempVolItem.ItemQty = itemVolQty;
                        tempVolItem.ItemUnit = volumeUnits[maxVolUnitIndex];
                        _context.Items.Add(tempVolItem);
                    }
                    if (weightCount > 0)
                    {
                        var tempWtItem = new Item();
                        tempWtItem.ShoppingListId = newShoppingList.Id;
                        tempWtItem.ItemName = itemGroup.Key;
                        tempWtItem.ItemQty = itemWtQty;
                        tempWtItem.ItemUnit = weightUnits[maxWtUnitIndex];
                        _context.Items.Add(tempWtItem);
                    }
                    if (eachCount > 0)
                    {
                        var tempEaItem = new Item();
                        tempEaItem.ShoppingListId = newShoppingList.Id;
                        tempEaItem.ItemName = itemGroup.Key;
                        tempEaItem.ItemQty = itemEaQty;
                        tempEaItem.ItemUnit = "";
                        _context.Items.Add(tempEaItem);
                    }
                    _context.SaveChanges();
                }
                else
                {
                    foreach (Item item in itemGroup)
                    {
                        _context.Items.Add(item);
                    }
                }
                _context.SaveChanges();
            }
            //return new ObjectResult(newShoppingList);

            return Created("", new { id = newShoppingList.Id });
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var delShoppingList = _context.ShoppingLists.First(s => s.Id == id);
            if (delShoppingList == null)
            {
                return NotFound();
            }

            _context.ShoppingLists.Remove(delShoppingList);
            _context.SaveChanges();
            return new NoContentResult();
        }
    }
}
