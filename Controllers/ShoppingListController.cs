using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CuisAriaBE.Models;

namespace CuisAriaBE.Controllers
{
    [Route("api/[controller]")]
    public class ShoppingListsController : Controller
    {
        private readonly CuisAriaBEContext _context;

        public ShoppingListsController(CuisAriaBEContext context)
        {
            _context = context;
        }

        // GET: api/ShoppingLists
        [HttpGet]
        public IEnumerable<ShoppingList> GetAllShoppingLists()
        {
            return _context.ShoppingLists.ToList();
        }

        // GET api/ShoppingLists/5
        [HttpGet("{id}", Name = "GetShoppingList")]
        public IActionResult GetById(int id)
        {
            var shoppingList = _context.ShoppingLists.FirstOrDefault(s => s.Id == id);
            if (shoppingList == null)
            {
                return NotFound();
            }

            return new ObjectResult(shoppingList);
        }

        // POST api/ShoppingLists
        [HttpPost]
        public IActionResult Create([FromBody] ShoppingList shoppingList)
        {
            if (ModelState.IsValid)
            {
                if (shoppingList.Id == 0)
                {
                    _context.ShoppingLists.Add(shoppingList);
                    _context.SaveChanges();
                    return CreatedAtRoute("GetShoppingList", new { id = shoppingList.Id }, shoppingList);
                }
                else
                {
                    _context.ShoppingLists.Update(shoppingList);
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
            var delShoppingList = _context.ShoppingLists.First(s => s.Id == id);
            if (delShoppingList == null)
            {
                return NotFound();
            }

            _context.ShoppingLists.Remove(delShoppingList);
            _context.SaveChanges();
            return new NoContentResult();
        }
    }
}
