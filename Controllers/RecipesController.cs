using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CuisAriaBE.Models;

namespace CuisAriaBE.Controllers
{
    [Route("api/[controller]")]
    public class RecipesController : Controller
    {
        private readonly CuisAriaBEContext _context;

        public RecipesController(CuisAriaBEContext context)
        {
            _context = context;
        }

        // GET: api/Recipes
        [HttpGet]
        public IEnumerable<Recipe> GetAllRecipes()
        {
            return _context.Recipes.ToList();
        }

        // GET api/Recipes/5
        [HttpGet("{id}", Name = "GetRecipe")]
        public IActionResult GetById(int id)
        {
            var recipe = _context.Recipes.FirstOrDefault(r => r.RecipeId == id);
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
                if (recipe.RecipeId == 0)
                {
                    _context.Recipes.Add(recipe);
                    _context.SaveChanges();
                    return CreatedAtRoute("GetRecipe", new { id = recipe.RecipeId }, recipe);
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
            var delRecipe = _context.Recipes.First(r => r.RecipeId == id);
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
