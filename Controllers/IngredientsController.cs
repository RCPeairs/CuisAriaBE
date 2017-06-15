using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CuisAriaBE.Models;

namespace CuisAriaBE.Controllers
{
    [Route("api/[controller]")]
    public class IngredientsController : Controller
    {
        private readonly CuisAriaBEContext _context;

        public IngredientsController(CuisAriaBEContext context)
        {
            _context = context;
        }

        // GET: api/Ingredients
        [HttpGet]
        public IEnumerable<Ingredient> GetAllIngredients()
        {
            return _context.Ingredients.ToList();
        }

        // GET api/Ingredients/5
        [HttpGet("{id}", Name = "GetIngredient")]
        public IActionResult GetById(int id)
        {
            var ingredient = _context.Ingredients.FirstOrDefault(i => i.Id == id);
            if (ingredient == null)
            {
                return NotFound();
            }

            return new ObjectResult(ingredient);
        }

        // POST api/Ingredients
        [HttpPost]
        public IActionResult Create([FromBody] Ingredient ingredient)
        {
            if (ModelState.IsValid)
            {
                if (ingredient.Id == 0)
                {
                    _context.Ingredients.Add(ingredient);
                    _context.SaveChanges();
                    return CreatedAtRoute("GetIngredient", new { id = ingredient.Id }, ingredient);
                }
                else
                {
                    _context.Ingredients.Update(ingredient);
                    _context.SaveChanges();
                    return new NoContentResult();
                }
            }
            return BadRequest();
        }

        // DELETE api/Ingredient/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var delIngredient = _context.Ingredients.First(i => i.Id == id);
            if (delIngredient == null)
            {
                return NotFound();
            }

            _context.Ingredients.Remove(delIngredient);
            _context.SaveChanges();
            return new NoContentResult();
        }
    }
}
