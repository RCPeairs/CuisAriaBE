//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using CuisAriaBE.Models;

//namespace CuisAriaBE.Controllers
//{
//    [Route("api/[controller]")]
//    public class QtysController : Controller
//    {
//        private readonly CuisAriaBEContext _context;

//        public QtysController(CuisAriaBEContext context)
//        {
//            _context = context;
//        }

//        // GET: api/Qtys
//        [HttpGet]
//        public IEnumerable<Qty> GetAllQtys()
//        {
//            return _context.Qtys.ToList();
//        }

//        // GET api/Qtys/5
//        [HttpGet("{id}", Name = "GetQty")]
//        public IActionResult GetById(int id)
//        {
//            var qty = _context.Qtys.FirstOrDefault(q => q.QtyId == id);
//            if (qty == null)
//            {
//                return NotFound();
//            }

//            return new ObjectResult(qty);
//        }

//        // POST api/Qtys
//        [HttpPost]
//        public IActionResult Create([FromBody] Qty qty)
//        {
//            if (ModelState.IsValid)
//            {
//                if (qty.QtyId == 0)
//                {
//                    _context.Qtys.Add(qty);
//                    _context.SaveChanges();
//                    return CreatedAtRoute("GetQty", new { id = qty.QtyId }, qty);
//                }
//                else
//                {
//                    _context.Qtys.Update(qty);
//                    _context.SaveChanges();
//                    return new NoContentResult();
//                }
//            }
//            return BadRequest();
//        }

//        // DELETE api/Qty/5
//        [HttpDelete("{id}")]
//        public IActionResult Delete(int id)
//        {
//            var delQty = _context.Qtys.First(q => q.QtyId == id);
//            if (delQty == null)
//            {
//                return NotFound();
//            }

//            _context.Qtys.Remove(delQty);
//            _context.SaveChanges();
//            return new NoContentResult();
//        }
//    }
//}
