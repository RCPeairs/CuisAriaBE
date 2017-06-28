using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CuisAriaBE.Models;
using CuisAriaBE.ViewModels;
using Newtonsoft.Json;

namespace CuisAriaBE.Controllers
{
    public class RecipesController : Controller
    {
        private readonly CuisAriaBEContext _context;

        public RecipesController(CuisAriaBEContext context)
        {
            _context = context;
        }

        // GET /GetSharedRecipes/[UserId]/[optional search string]
        [HttpGet, Route("GetSharedRecipes/{searchStr?}/{userId}")]
        public IActionResult GetSharedRecipes(int userId, string searchStr=" ")
        //[HttpGet, Route("GetSharedRecipes/{userId}")]
        //public IActionResult GetSharedRecipes(int userId)
        {
            //var userId = 240;
            List<Recipe> tempSharedList = new List<Recipe>();
            if (searchStr != null)
            {
                var tmpSharedRecipes = from recipe in _context.Recipes
                                       where (recipe.Description.Contains('%' + searchStr + '%'))
                                       select recipe;
                tempSharedList = tmpSharedRecipes.ToList();

            }
            else
            {
                var tmpSharedRecipes = from recipe in _context.Recipes
                                where recipe.Shared == true
                                select recipe;
                tempSharedList = tmpSharedRecipes.ToList();
                //var tempSharedList = tmpSharedRecipes.ToList();

            }

            List<UserRecipeVM> sharedRecipes = new List<UserRecipeVM>();
            foreach (Recipe recipePtr in tempSharedList)
            {
                var recipe = new UserRecipeVM();
                var recipeObj = new UserRecipeFavorite();
                recipeObj = _context.UserRecipeFavorite.FirstOrDefault(u => u.RecipeId == recipePtr.Id && u.UserId == userId);
                if (recipeObj != null)
                {
                    recipe.Favorite = recipeObj.Favorite;
                } else
                {
                    recipe.Favorite = false;
                }
                recipe.UserId = userId;
                recipe.RecipeId = recipePtr.Id;
                recipe.RecipeName = recipePtr.RecipeName;
                recipe.Description = recipePtr.Description;
                recipe.OwnerId = recipePtr.OwnerId;
                recipe.Shared = recipePtr.Shared;
                recipe.Notes = recipePtr.Notes;
                recipe.MyRating = recipePtr.MyRating;
                recipe.ShareRating = recipePtr.ShareRating;
                recipe.NumShareRatings = recipePtr.NumShareRatings;
                recipe.RecipePic = recipePtr.RecipePic;
                recipe.PrepTime = recipePtr.PrepTime;
                recipe.CookTime = recipePtr.CookTime;
                recipe.RecipeServings = recipePtr.RecipeServings;
                recipe.ServingSize = recipePtr.ServingSize;

                sharedRecipes.Add(recipe);
            }

            if (sharedRecipes.Count() == 0)
            {
                return NotFound();
            }
            return new ObjectResult(sharedRecipes);
        }

        // GET /GetMyRecipes/[UserId]
        [HttpGet, Route("GetMyRecipes/{id}")]
        public IActionResult GetMyRecipes(int id)
        {
            var myRecipePntrs = from recipePtr in _context.Recipes
                                where recipePtr.OwnerId == id
                                select recipePtr;
            var tempList = myRecipePntrs.ToList();

            List<UserRecipeVM> myRecipes = new List<UserRecipeVM>();
            foreach (Recipe recipePtr in tempList)
            {
                var recipeObj = new UserRecipeFavorite();
                recipeObj = _context.UserRecipeFavorite.FirstOrDefault(u => u.RecipeId == recipePtr.Id && u.UserId == recipePtr.OwnerId);

                var recipe = new UserRecipeVM();
                recipe.UserId = recipeObj.UserId;
                recipe.RecipeId = recipeObj.RecipeId;
                recipe.Favorite = recipeObj.Favorite;
                recipe.RecipeName = recipePtr.RecipeName;
                recipe.Description = recipePtr.Description;
                recipe.OwnerId = recipePtr.OwnerId;
                recipe.Shared = recipePtr.Shared;
                recipe.Notes = recipePtr.Notes;
                recipe.MyRating = recipePtr.MyRating;
                recipe.ShareRating = recipePtr.ShareRating;
                recipe.NumShareRatings = recipePtr.NumShareRatings;
                recipe.RecipePic = recipePtr.RecipePic;
                recipe.PrepTime = recipePtr.PrepTime;
                recipe.CookTime = recipePtr.CookTime;
                recipe.RecipeServings = recipePtr.RecipeServings;
                recipe.ServingSize = recipePtr.ServingSize;

                myRecipes.Add(recipe);
            }

            if (myRecipes.Count() == 0)
            {
                return NotFound();
            }

            return new ObjectResult(myRecipes);
        }

        // GET /GetFavRecipes/[UserId]
        [HttpGet, Route("GetFavRecipes/{id}")]
        public IActionResult GetFavRecipes(int id)
        {
            var myRecipePntrs = from recipePtr in _context.UserRecipeFavorite
                                where recipePtr.UserId == id && recipePtr.Favorite == true
                                select recipePtr;

            var tempList = myRecipePntrs.ToList();

            List<UserRecipeVM> myRecipes = new List<UserRecipeVM>();
            foreach (UserRecipeFavorite recipePtr in tempList)
            {
                var recipeObj = new Recipe();
                recipeObj = _context.Recipes.FirstOrDefault(r => r.Id == recipePtr.RecipeId);

                var recipe = new UserRecipeVM();
                recipe.UserId = recipePtr.UserId;
                recipe.RecipeId = recipePtr.RecipeId;
                recipe.Favorite = recipePtr.Favorite;
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

                myRecipes.Add(recipe);
            }

            if (myRecipes.Count() == 0)
            {
                return NotFound();
            }

            return new ObjectResult(myRecipes);
        }

        // GET /GetRecipe/[RecipeId]
        [HttpGet, Route("GetRecipe/{id}")]
        public IActionResult GetRecipe(int id)
        {
            var recipe = _context.Recipes.FirstOrDefault(r => r.Id == id);
            if (recipe == null)
            {
                return NotFound();
            }

            return new ObjectResult(recipe);
        }









        // POST AddEditRecipes
        [HttpPost, Route("AddEditRecipe")]
        public IActionResult Create([FromBody] AddEditRecipeVM recipeInput)
        //public IActionResult Post([FromBody] Object jsonRecipeInput)
        {
            //var jsonString = jsonRecipeInput.ToString();
            //AddEditRecipeVM recipeInput = JsonConvert.DeserializeObject<AddEditRecipeVM>(jsonString);

            if (ModelState.IsValid)
            {
                // Validate data here before writing to database
                if (_context.Users.FirstOrDefault(u => u.Id == recipeInput.userRecipeFavorite.UserId) == null || _context.Users.FirstOrDefault(u => u.Id == recipeInput.recipe.OwnerId) == null)
                {
                    return NotFound();
                }

                var editRecipe = false;
                List<MenuRecipe> menuRecipeEdits = new List<MenuRecipe>();
                List<UserRecipeFavorite> userRecipeFavEdits = new List<UserRecipeFavorite>();
                if (recipeInput.recipe.RecipeId != 0)
                {
                    editRecipe = true;

                    // Save list of MenuRecipe entries
                    var tempMenuRecipes = from recipePtr in _context.MenuRecipe
                                          where recipePtr.RecipeId == recipeInput.recipe.RecipeId
                                          select recipePtr;
                    menuRecipeEdits = tempMenuRecipes.ToList();

                    // Delete MenuRecipe entries
                    _context.MenuRecipe.RemoveRange(_context.MenuRecipe.Where(m => m.RecipeId == recipeInput.recipe.RecipeId));
                    _context.SaveChanges();

                    // Delete StepIngredients entries
                    var tempSteps = from stepPtr in _context.Steps
                                          where stepPtr.RecipeId == recipeInput.recipe.RecipeId
                                          select stepPtr;
                    var delStepList = tempSteps.ToList();
                    foreach (Step delStepPtr in delStepList)
                    {
                    _context.StepIngredient.RemoveRange(_context.StepIngredient.Where(s => s.StepId == delStepPtr.Id));
                    }
                    _context.SaveChanges();

                    // Delete RecipeKeyword entries
                    _context.RecipeKeyword.RemoveRange(_context.RecipeKeyword.Where(r => r.RecipeId == recipeInput.recipe.RecipeId));
                    _context.SaveChanges();

                    // Save list of UserRecipeFavorite entries if recipe is shared
                    var curRecipe = new Recipe();
                    curRecipe = _context.Recipes.FirstOrDefault(r => r.Id == recipeInput.recipe.RecipeId);
                    var curRecipeShared = false;
                    if (curRecipe != null)
                    {
                    curRecipeShared = curRecipe.Shared;
                    }
                    if (recipeInput.recipe.Shared == true && curRecipeShared == true)
                    {
                        var tempUserRecFav = from userRecipePtr in _context.UserRecipeFavorite
                                              where userRecipePtr.RecipeId == recipeInput.recipe.RecipeId && userRecipePtr.UserId != recipeInput.recipe.OwnerId
                                             select userRecipePtr;
                        userRecipeFavEdits = tempUserRecFav.ToList();
                    }

                    // Delete UserRecipeFavorite entries
                    _context.UserRecipeFavorite.RemoveRange(_context.UserRecipeFavorite.Where(u => u.RecipeId == recipeInput.recipe.RecipeId));
                    _context.SaveChanges();

                    // Delete Steps entries
                    foreach (Step delStepPtr in delStepList)
                    {
                        _context.Steps.RemoveRange(_context.Steps.Where(s => s.RecipeId == delStepPtr.RecipeId));
                    }
                    _context.SaveChanges();

                    // Delete Recipes entry
                    _context.Recipes.RemoveRange(_context.Recipes.Where(r => r.Id == recipeInput.recipe.RecipeId));
                    _context.SaveChanges();
                }

                // Add Recipe table entry
                var tempRecipe = new Recipe();
                tempRecipe.RecipeName = recipeInput.recipe.RecipeName;
                tempRecipe.Description = recipeInput.recipe.Description;
                tempRecipe.OwnerId = recipeInput.recipe.OwnerId;
                tempRecipe.Shared = recipeInput.recipe.Shared;
                tempRecipe.Notes = recipeInput.recipe.Notes;
                tempRecipe.MyRating = recipeInput.recipe.MyRating;
                tempRecipe.ShareRating = recipeInput.recipe.ShareRating;
                tempRecipe.NumShareRatings = recipeInput.recipe.NumShareRatings;
                tempRecipe.RecipePic = recipeInput.recipe.RecipePic;
                tempRecipe.PrepTime = recipeInput.recipe.PrepTime;
                tempRecipe.CookTime = recipeInput.recipe.CookTime;
                tempRecipe.RecipeServings = recipeInput.recipe.RecipeServings;
                tempRecipe.ServingSize = recipeInput.recipe.ServingSize;
                _context.Recipes.Add(tempRecipe);
                _context.SaveChanges();

                // Add entry to UserRecipeFavorite join table
                var tempUserRecipeFavorite = new UserRecipeFavorite();
                tempUserRecipeFavorite.UserId = recipeInput.userRecipeFavorite.UserId;
                tempUserRecipeFavorite.RecipeId = tempRecipe.Id;
                tempUserRecipeFavorite.Favorite = recipeInput.userRecipeFavorite.Favorite;
                _context.UserRecipeFavorite.Add(tempUserRecipeFavorite);
                _context.SaveChanges();

                // Add steps to Steps table
                List<RecipeStepIngredientVM> tempRecipeStepIngredient = new List<RecipeStepIngredientVM>();
                tempRecipeStepIngredient = recipeInput.RecipeStepIngredients;

                // Add each step to Steps table
                foreach (RecipeStepIngredientVM stepItem in tempRecipeStepIngredient)
                {
                    var tempStepItem = new Step();
                    tempStepItem.RecipeId = tempRecipe.Id;
                    tempStepItem.StepNumber = stepItem.StepNumber;
                    tempStepItem.Instruction = stepItem.Instruction;
                    _context.Steps.Add(tempStepItem);
                    _context.SaveChanges();

                    // Add each ingredient to Ingredient and StepIngredient tables
                    List<IngredientListVM> tempIngredList = new List<IngredientListVM>();
                    tempIngredList = stepItem.IngredientList;

                    foreach (IngredientListVM ingredItem in tempIngredList)
                    {
                        var tempIngredId = 0;
                        var tempIngred = new Ingredient();
                        tempIngred = _context.Ingredients.FirstOrDefault(i => i.IngredName.ToLower() == ingredItem.IngredName.ToLower());
                        if (tempIngred == null)
                        {
                            var newIngred = new Ingredient();
                            newIngred.IngredName = ingredItem.IngredName;
                            _context.Ingredients.Add(newIngred);
                            _context.SaveChanges();
                            tempIngredId = newIngred.Id;
                        }
                        else
                        {
                            tempIngredId = tempIngred.Id;
                        }  // end add ingredient name

                        var tempStepIngred = new StepIngredient();
                        tempStepIngred.StepId = tempStepItem.Id;
                        tempStepIngred.IngredientId = tempIngredId;
                        tempStepIngred.IngredQty = ingredItem.IngredQty;
                        tempStepIngred.IngredUnit = ingredItem.IngredUnit;
                        _context.StepIngredient.Add(tempStepIngred);
                        _context.SaveChanges();
                    } // end add ingredItem loop
                } // end add stepItem loop

                // Add searchwords to Keywords table
                List<Keyword> keywordList = new List<Keyword>();
                keywordList = recipeInput.Keywords;
                if (keywordList != null)
                {
                    foreach (Keyword tempKeyword in keywordList)
                    {
                        var tempKeywordId = 0;
                        var tempSearchWord = new Keyword();
                        tempSearchWord = _context.Keywords.FirstOrDefault(k => k.SearchWord.ToLower() == tempKeyword.SearchWord.ToLower());
                        if (tempSearchWord == null)
                        {
                            var newKeyword = new Keyword();
                            newKeyword.SearchWord = tempKeyword.SearchWord;
                            _context.Keywords.Add(newKeyword);
                            _context.SaveChanges();
                            tempKeywordId = newKeyword.Id;
                        }
                        else
                        {
                            tempKeywordId = tempSearchWord.Id;
                        }

                        // Add entry to RecipeKeyword join table
                        var tempRecipeKeyword = new RecipeKeyword();
                        tempRecipeKeyword.RecipeId = tempRecipe.Id;
                        tempRecipeKeyword.KeywordId = tempKeywordId;
                        _context.RecipeKeyword.Add(tempRecipeKeyword);
                        _context.SaveChanges();
                    }
                }

                if (editRecipe == true)
                {
                    // Re-enter MenuRecipe entries with new RecipeId
                    foreach (MenuRecipe recipePtr in menuRecipeEdits)
                    {
                        var tempMenuRecipe = new MenuRecipe();
                        tempMenuRecipe.MenuId = recipePtr.MenuId;
                        tempMenuRecipe.RecipeId = tempRecipe.Id;
                        tempMenuRecipe.MenuServings = recipePtr.MenuServings;
                        _context.MenuRecipe.Add(tempMenuRecipe);
                    }
                    _context.SaveChanges();

                    // Re-enter UserRecipeFavorites entries with new RecipeId for shared recipes
                    foreach (UserRecipeFavorite userRecipePtr in userRecipeFavEdits)
                    {
                        var tempUserRecipe = new UserRecipeFavorite();
                        tempUserRecipe.UserId = userRecipePtr.UserId;
                        tempUserRecipe.RecipeId = tempRecipe.Id;
                        tempUserRecipe.Favorite = userRecipePtr.Favorite;
                        _context.UserRecipeFavorite.Add(tempUserRecipe);
                    }
                    _context.SaveChanges();
                }
                return CreatedAtRoute("", new { id = tempRecipe.Id }, recipeInput);
            }
            return BadRequest();
        }

        // POST ShareRecipeToggle/RecipeId
        [HttpPost, Route("ShareRecipeToggle/{recipeId}")]
        public IActionResult ShareRecipeToggle(int recipeId)
        {
            var recipe = _context.Recipes.FirstOrDefault(r => r.Id == recipeId);
            if (recipe == null)
            {
                return NotFound();
            }
            else if (recipe.Shared == false)
            {
                recipe.Shared = true;
            }
            else
            {
                recipe.Shared = false;
            }
            _context.Recipes.Update(recipe);
            _context.SaveChanges();
            return new NoContentResult();
        }

        // POST FavRecipeToggle/userId/recipeId
        [HttpPost, Route("FavRecipeToggle/{userId}/{recipeId}")]
        public IActionResult FavRecipeToggle(int userId, int recipeId)
        {
            // Make sure user and recipe IDs are valid
            if (_context.Users.FirstOrDefault(u => u.Id == userId) == null || _context.Recipes.FirstOrDefault(r => r.Id == recipeId) == null)
            {
                return NotFound();
            }

            // Add entry if it does not already exists in UserRecipeFavorites table otherwise toggle Favorite  
            var favRecipe = _context.UserRecipeFavorite.FirstOrDefault(r => r.UserId == userId && r.RecipeId == recipeId);
            if (favRecipe == null)
            {
                var newFavRecipe = new UserRecipeFavorite();
                newFavRecipe.UserId = userId;
                newFavRecipe.RecipeId = recipeId;
                newFavRecipe.Favorite = true;
                _context.UserRecipeFavorite.Add(newFavRecipe);
            }
            else
            {
                favRecipe.UserId = userId;
                favRecipe.RecipeId = recipeId;
                if (favRecipe.Favorite == false)
                {
                    favRecipe.Favorite = true;
                }
                else
                {
                    favRecipe.Favorite = false;
                }
                _context.UserRecipeFavorite.Update(favRecipe);
            }
            _context.SaveChanges();
            return new NoContentResult();
        }

        // DELETE api/Recipe/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var delRecipe = _context.Recipes.First(r => r.Id == id);
            if (delRecipe == null)
            {
                return NotFound();
            }

            _context.Recipes.Remove(delRecipe);
            _context.SaveChanges();
            return new NoContentResult();
        }
    }
}
