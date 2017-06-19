using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CuisAriaBE.Models;

namespace CuisAriaBE.Controllers
{
    [Route("api/[controller]")]
    public class ItemsController : Controller
    {
        private readonly CuisAriaBEContext _context;

        public ItemsController(CuisAriaBEContext context)
        {
            _context = context;
        }

        // GET: api/Items
        [HttpGet]
        public IEnumerable<Item> GetAllItems()
        {
            return _context.Items.ToList();
        }

        // GET api/Items/5
        [HttpGet("{id}", Name = "GetItem")]
        public IActionResult GetById(int id)
        {
            var item = _context.Items.FirstOrDefault(u => u.Id == id);
            if (item == null)
            {
                return NotFound();
            }

            return new ObjectResult(item);
        }

        // POST api/Items
        [HttpPost]
        public IActionResult Create([FromBody] Item item)
        {
            if (ModelState.IsValid)
            {
                if (item.Id == 0)
                {
                    _context.Items.Add(item);
                    _context.SaveChanges();
                    return CreatedAtRoute("GetItem", new { id = item.Id }, item);
                }
                else
                {
                    _context.Items.Update(item);
                    _context.SaveChanges();
                    return new NoContentResult();
                }
            }
            return BadRequest();
        }

        // DELETE api/Items/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var delItem = _context.Items.First(u => u.Id == id);
            if (delItem == null)
            {
                return NotFound();
            }

            _context.Items.Remove(delItem);
            _context.SaveChanges();
            return new NoContentResult();
        }
    }
}
