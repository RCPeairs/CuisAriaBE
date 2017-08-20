using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CuisAriaBE.Models;
using CuisAriaBE.ViewModels;

namespace CuisAriaBE.Controllers
{
    public class MenusController : Controller
    {
        private readonly CuisAriaBEContext _context;

        public MenusController(CuisAriaBEContext context)
        {
            _context = context;
        }

        // GET GetSavedMenus/[UserId]
        [HttpGet, Route("GetSavedMenus/{userId}")]
        public IActionResult GetSavedMenus(int userId)
        {
            var tmpSavedMenus = from menu in _context.Menus
                                where menu.UserId == userId
                                select menu;

            var tempSavedMenus = tmpSavedMenus.ToList();
            return new ObjectResult(tempSavedMenus);
        }

        // GET GetMenu/[UserId]/[MenuId]
        [HttpGet, Route("GetMenu/{userId}/{menuId}")]
        public IActionResult GetMenu(int userId, int menuId)
        {
            // If menuId = 0 get current menu
            if (menuId == 0)
            {
                var curMenu = new Menu();
                curMenu = _context.Menus.FirstOrDefault(m => m.UserId == userId && m.CurrentMenu == true);
                if (curMenu == null)
                {
                    curMenu = _context.Menus.FirstOrDefault(m => m.UserId == userId);
                    if (curMenu == null)
                    {
                        return NotFound();
                    }
                }
                menuId = curMenu.Id;
            }

            var tmpRecipes = from tempMenuRecipes in _context.MenuRecipe
                             where tempMenuRecipes.MenuId == menuId
                             select tempMenuRecipes;
            var tempRecipes = tmpRecipes.ToList();

            List<MenuRecipeVM> menuRecipes = new List<MenuRecipeVM>();
            foreach (MenuRecipe recipePtr in tempRecipes)
            {
                var recipe = new MenuRecipeVM();
                var recipeObj = new Recipe();
                var menuObj = new Menu();
                recipeObj = _context.Recipes.FirstOrDefault(r => r.Id == recipePtr.RecipeId);
                menuObj = _context.Menus.FirstOrDefault(m => m.Id == recipePtr.MenuId);

                recipe.MenuId = recipePtr.MenuId;
                recipe.MenuName = menuObj.MenuName;
                recipe.RecipeId = recipeObj.Id;
                recipe.RecipeName = recipeObj.RecipeName;
                recipe.Description = recipeObj.Description;
                recipe.OwnerId = recipeObj.OwnerId;
                recipe.Shared = recipeObj.Shared;
                recipe.Notes = recipeObj.Notes;
                recipe.MyRating = recipeObj.MyRating;
                recipe.ShareRating = recipeObj.ShareRating;
                recipe.NumShareRatings = recipeObj.NumShareRatings;
                recipe.RecipePic = recipeObj.RecipePic;
                recipe.PrepTime = recipeObj.PrepTime;
                recipe.CookTime = recipeObj.CookTime;
                recipe.RecipeServings = recipeObj.RecipeServings;
                recipe.ServingSize = recipeObj.ServingSize;
                recipe.MenuServings = recipePtr.MenuServings;

                menuRecipes.Add(recipe);
            }

            return new ObjectResult(menuRecipes);
        }

        // POST AddMenuRecipe
        [HttpPost, Route("AddMenuRecipe")]
        public IActionResult Create([FromBody] AddEditGetMenuVM menuInput)
        {
            if (ModelState.IsValid)
            {
                var addMenu = false;
                if (menuInput.MenuId == 0)
                {
                    addMenu = true;
                }

                // Validate UserId, MenuId & RecipeId before writing to database
                if (_context.Users.FirstOrDefault(m => m.Id == menuInput.UserId) == null || _context.Recipes.FirstOrDefault(r => r.Id == menuInput.RecipeId) == null)
                {
                    return BadRequest();
                }
                if (addMenu == false && _context.Menus.FirstOrDefault(m => m.Id == menuInput.MenuId) == null)
                {
                    return BadRequest();
                }  // end check for valid UserId, MenuId and RecipeId input

                // Clear current menu bit for user
                var clearCurrent = new Menu();
                clearCurrent = _context.Menus.FirstOrDefault(m => m.UserId == menuInput.UserId && m.CurrentMenu == true);
                if (clearCurrent != null)
                {
                    clearCurrent.CurrentMenu = false;
                    _context.Menus.Update(clearCurrent);
                    _context.SaveChanges();
                }

                // If new menu add to Menus table & get MenuId
                var newMenu = new Menu();
                if (addMenu == true)
                {
                    newMenu.UserId = menuInput.UserId;
                    newMenu.MenuName = menuInput.MenuName;
                    newMenu.CurrentMenu = true;
                    _context.Menus.Add(newMenu);
                    _context.SaveChanges();
                } else
                {
                    var editMenu = new Menu();
                    editMenu = _context.Menus.FirstOrDefault(m => m.Id == menuInput.MenuId);
                    editMenu.CurrentMenu = true;
                    _context.Menus.Update(editMenu);
                    _context.SaveChanges();
                }

                // Store recipe in MenuRecipe table
                var newMenuRecipe = new MenuRecipe();
                if (addMenu == true)
                {
                    newMenuRecipe.MenuId = newMenu.Id;
                }
                else
                {
                    newMenuRecipe.MenuId = menuInput.MenuId;
                }
                newMenuRecipe.RecipeId = menuInput.RecipeId;
                newMenuRecipe.MenuServings = menuInput.MenuServings;
                _context.MenuRecipe.Add(newMenuRecipe);
                _context.SaveChanges();

                return CreatedAtRoute("", new { id = newMenuRecipe.MenuId }, menuInput);
            }
            else
            {
                return BadRequest();
            }
        }



        //// POST AddEditMenu
        //[HttpPost, Route("AddEditMenu")]
        //public IActionResult Create([FromBody] AddEditMenuVM menuInput)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var editMenu = false;
        //        if (menuInput.MenuId != 0)
        //        {
        //            editMenu = true;
        //        }
        //        List<MenuRecipe> tempRecipeList = new List<MenuRecipe>();

        //        // Validate data here before writing to database
        //        if (_context.Users.FirstOrDefault(m => m.Id == menuInput.UserId) == null)
        //        {
        //            return BadRequest();
        //        }
        //        else
        //        {
        //            tempRecipeList = menuInput.menuRecipes;
        //            foreach (MenuRecipe tempRecipeId in tempRecipeList)
        //            {
        //                if(_context.Recipes.FirstOrDefault(r => r.Id == tempRecipeId.RecipeId) == null)
        //                {
        //                    return BadRequest();
        //                }
        //            }
        //        }  // end check for valid UserId and RecipeIds

        //        var tempMenu = new Menu();
        //        if (editMenu)
        //        {
        //            // Edit existing menu
        //            tempMenu = _context.Menus.FirstOrDefault(m => m.Id == menuInput.MenuId);
        //            tempMenu.MenuName = menuInput.MenuName;
        //            _context.Menus.Update(tempMenu);

        //            var delExistingRecipes = from recipePtr in _context.MenuRecipe
        //                                  where recipePtr.MenuId == menuInput.MenuId
        //                                  select recipePtr;
        //            var delRecipeList = delExistingRecipes.ToList();
        //            foreach (MenuRecipe delRecipe in delRecipeList)
        //            {
        //                _context.MenuRecipe.Remove(delRecipe);
        //            }
        //            _context.SaveChanges();

        //            foreach (MenuRecipe addRecipe in tempRecipeList)
        //            {
        //                var tempAddRecipe = new MenuRecipe();
        //                tempAddRecipe.MenuId = menuInput.MenuId;
        //                tempAddRecipe.RecipeId = addRecipe.RecipeId;
        //                tempAddRecipe.MenuServings = addRecipe.MenuServings;

        //                _context.MenuRecipe.Add(tempAddRecipe);
        //                _context.SaveChanges();
        //            }

        //        } else
        //        {
        //            // Add new menu
        //            tempMenu.UserId = menuInput.UserId;
        //            tempMenu.MenuName = menuInput.MenuName;
        //            _context.Menus.Add(tempMenu);
        //            _context.SaveChanges();

        //            foreach (MenuRecipe addRecipe in tempRecipeList)
        //            {
        //                var tempAddRecipe = new MenuRecipe();
        //                tempAddRecipe.MenuId = tempMenu.Id;
        //                tempAddRecipe.RecipeId = addRecipe.RecipeId;
        //                tempAddRecipe.MenuServings = addRecipe.MenuServings;
        //                _context.MenuRecipe.Add(tempAddRecipe);
        //            }
        //        }
        //        _context.SaveChanges();
        //        return CreatedAtRoute("", new { id = tempMenu.Id }, menuInput);
        //    } else
        //    {
        //        return BadRequest();
        //    }
        //}

        // POST DeleteMenu/[MenuId]
        [HttpPost, Route("DeleteMenu/{menuId}")]
        public IActionResult DeleteMenu(int menuId)
        {
            // Validate menuId here before attempting to delete
            if (_context.Menus.FirstOrDefault(m => m.Id == menuId) == null)
            {
                return BadRequest();
            }

            var delRecipes = from recipePtr in _context.MenuRecipe
                             where recipePtr.MenuId == menuId
                             select recipePtr;
            var delRecipeList = delRecipes.ToList();
            foreach (MenuRecipe delRecipe in delRecipeList)
            {
                _context.MenuRecipe.Remove(delRecipe);
            }
            _context.SaveChanges();
            var tempMenu = new Menu();
            tempMenu = _context.Menus.FirstOrDefault(m => m.Id == menuId);
            _context.Menus.Remove(tempMenu);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
