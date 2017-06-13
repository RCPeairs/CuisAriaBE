//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using CuisAriaBE.Models;

//namespace CuisAriaBE.Controllers
//{
//    [Route("api/[controller]")]
//    public class UnitsController : Controller
//    {
//        private readonly CuisAriaBEContext _context;

//        public UnitsController(CuisAriaBEContext context)
//        {
//            _context = context;
//        }

//        // GET: api/Units
//        [HttpGet]
//        public IEnumerable<Unit> GetAllUnits()
//        {
//            return _context.Units.ToList();
//        }

//        // GET api/Units/5
//        [HttpGet("{id}", Name = "GetUnit")]
//        public IActionResult GetById(int id)
//        {
//            var unit = _context.Units.FirstOrDefault(u => u.UnitId == id);
//            if (unit == null)
//            {
//                return NotFound();
//            }

//            return new ObjectResult(unit);
//        }

//        // POST api/Units
//        [HttpPost]
//        public IActionResult Create([FromBody] Unit unit)
//        {
//            if (ModelState.IsValid)
//            {
//                if (unit.UnitId == 0)
//                {
//                    _context.Units.Add(unit);
//                    _context.SaveChanges();
//                    return CreatedAtRoute("GetUnit", new { id = unit.UnitId }, unit);
//                }
//                else
//                {
//                    _context.Units.Update(unit);
//                    _context.SaveChanges();
//                    return new NoContentResult();
//                }
//            }
//            return BadRequest();
//        }

//        // DELETE api/Unit/5
//        [HttpDelete("{id}")]
//        public IActionResult Delete(int id)
//        {
//            var delUnit = _context.Units.First(u => u.UnitId == id);
//            if (delUnit == null)
//            {
//                return NotFound();
//            }

//            _context.Units.Remove(delUnit);
//            _context.SaveChanges();
//            return new NoContentResult();
//        }
//    }
//}
