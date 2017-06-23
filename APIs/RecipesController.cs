using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CuisAriaBE.Models;
using CuisAriaBE.ViewModels;

namespace CuisAriaBE.Controllers
{
    public class RecipesController : Controller
    {
        private readonly CuisAriaBEContext _context;

        public RecipesController(CuisAriaBEContext context)
        {
            _context = context;
        }

        // GET /GetSharedRecipes
        [HttpGet, Route("GetSharedRecipes")]
        public IActionResult GetSharedRecipes()
        {
            var sharedRecipes = from recipe in _context.Recipes
                                where recipe.Shared == true
                                select recipe;
            if (sharedRecipes.Count() == 0)
            {
                return NotFound();
            }

            return new ObjectResult(sharedRecipes);
        }

        // GET /GetMyRecipes/Id
        [HttpGet, Route("GetMyRecipes/{id}")]
        public IActionResult GetMyRecipes(int id)
        {
            var myRecipePntrs = from recipePtr in _context.UserRecipeFavorite
                                where recipePtr.UserId == id
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

        // GET /GetFavRecipes/Id
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

        // GET /GetRecipe/Id
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

        // POST api/Recipes
        [HttpPost]
        public IActionResult Create([FromBody] Recipe recipe)
        {
            if (ModelState.IsValid)
            {
                if (recipe.Id == 0)
                {
                    _context.Recipes.Add(recipe);
                    _context.SaveChanges();
                    return CreatedAtRoute("GetRecipe", new { id = recipe.Id }, recipe);
                }
                else
                {
                    _context.Recipes.Update(recipe);
                    _context.SaveChanges();
                    return new NoContentResult();
                }
            }
            return BadRequest();
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
