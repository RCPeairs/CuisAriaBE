using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CuisAriaBE.Models;
using CuisAriaBE.ViewModels;

namespace CuisAriaBE.Controllers
{
    public class StepsController : Controller
    {
        private readonly CuisAriaBEContext _context;

        public StepsController(CuisAriaBEContext context)
        {
            _context = context;
        }

        // GET /GetRecipeSteps/RecipeId
        [HttpGet, Route("GetRecipeSteps/{id}")]
        public IActionResult GetRecipeSteps(int id)
        {
            var recipeSteps = from stepPtr in _context.Steps
                                where stepPtr.RecipeId == id 
                                select stepPtr;

            var stepList = recipeSteps.ToList();

            List<RecipeStepIngredientVM> recipeStepIngredients = new List<RecipeStepIngredientVM>();

            foreach (Step stepPtr in stepList)
            {
                var stepIngred = from ingredPtr in _context.StepIngredient
                                  where ingredPtr.StepId == stepPtr.Id
                                  select ingredPtr;

                var tempStpIngred = stepIngred.ToList();

                var stepIngredients = new RecipeStepIngredientVM();
                List<IngredientListVM> ingredientList = new List<IngredientListVM>();

                foreach (StepIngredient ingred in tempStpIngred)
                {
                    var tempIngred = new IngredientListVM();
                    var tempIngredName = from ingredNamePtr in _context.Ingredients
                                                where ingred.IngredientId == ingredNamePtr.Id
                                                select ingredNamePtr.IngredName;
                    tempIngred.IngredName = tempIngredName.Single().ToString();
                    tempIngred.IngredQty = ingred.IngredQty;
                    tempIngred.IngredUnit = ingred.IngredUnit;

                    ingredientList.Add(tempIngred);
                }

                stepIngredients.RecipeId = stepPtr.RecipeId;
                stepIngredients.StepId = stepPtr.Id;
                stepIngredients.StepNumber = stepPtr.StepNumber;
                stepIngredients.Instruction = stepPtr.Instruction;
                stepIngredients.IngredientList = ingredientList;

                recipeStepIngredients.Add(stepIngredients);
            }

            return new ObjectResult(recipeStepIngredients);
        }








        //// GET: api/Steps
        //[HttpGet]
        //public IEnumerable<Step> GetAllSteps()
        //{
        //    return _context.Steps.ToList();
        //}

        //// GET api/Steps/5
        //[HttpGet("{id}", Name = "GetStep")]
        //public IActionResult GetById(int id)
        //{
        //    var step = _context.Steps.FirstOrDefault(s => s.Id == id);
        //    if (step == null)
        //    {
        //        return NotFound();
        //    }

        //    return new ObjectResult(step);
        //}

        // POST api/Steps
        [HttpPost]
        public IActionResult Create([FromBody] Step step)
        {
            if (ModelState.IsValid)
            {
                if (step.Id == 0)
                {
                    _context.Steps.Add(step);
                    _context.SaveChanges();
                    return CreatedAtRoute("Getstep", new { id = step.Id }, step);
                }
                else
                {
                    _context.Steps.Update(step);
                    _context.SaveChanges();
                    return new NoContentResult();
                }
            }
            return BadRequest();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var delStep = _context.Steps.First(s => s.Id == id);
            if (delStep == null)
            {
                return NotFound();
            }

            _context.Steps.Remove(delStep);
            _context.SaveChanges();
            return new NoContentResult();
        }
    }
}
