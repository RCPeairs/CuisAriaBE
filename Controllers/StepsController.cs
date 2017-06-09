using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CuisAriaBE.Models;

namespace CuisAriaBE.Controllers
{
    [Route("api/[controller]")]
    public class StepsController : Controller
    {
        private readonly CuisAriaBEContext _context;

        public StepsController(CuisAriaBEContext context)
        {
            _context = context;
        }

        // GET: api/Steps
        [HttpGet]
        public IEnumerable<Step> GetAllSteps()
        {
            return _context.Steps.ToList();
        }

        // GET api/Steps/5
        [HttpGet("{id}", Name = "GetStep")]
        public IActionResult GetById(int id)
        {
            var step = _context.Steps.FirstOrDefault(s => s.StepId == id);
            if (step == null)
            {
                return NotFound();
            }

            return new ObjectResult(step);
        }

        // POST api/Steps
        [HttpPost]
        public IActionResult Create([FromBody] Step step)
        {
            if (ModelState.IsValid)
            {
                if (step.StepId == 0)
                {
                    _context.Steps.Add(step);
                    _context.SaveChanges();
                    return CreatedAtRoute("Getstep", new { id = step.StepId }, step);
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
            var delStep = _context.Steps.First(s => s.StepId == id);
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
