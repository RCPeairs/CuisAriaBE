using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CuisAriaBE.Models;

namespace CuisAriaBE.Controllers
{
    [Route("api/[controller]")]
    public class MenusController : Controller
    {
        private readonly CuisAriaBEContext _context;

        public MenusController(CuisAriaBEContext context)
        {
            _context = context;
        }

        // GET: api/Menus
        [HttpGet]
        public IEnumerable<Menu> GetAllMenus()
        {
            return _context.Menus.ToList();
        }

        // GET api/Menus/5
        [HttpGet("{id}", Name = "GetMenu")]
        public IActionResult GetById(int id)
        {
            var menu = _context.Menus.FirstOrDefault(m => m.Id == id);
            if (menu == null)
            {
                return NotFound();
            }

            return new ObjectResult(menu);
        }

        // POST api/Menus
        [HttpPost]
        public IActionResult Create([FromBody] Menu menu)
        {
            if (ModelState.IsValid)
            {
                if (menu.Id == 0)
                {
                    _context.Menus.Add(menu);
                    _context.SaveChanges();
                    return CreatedAtRoute("GetMenu", new { id = menu.Id }, menu);
                }
                else
                {
                    _context.Menus.Update(menu);
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
            var delMenu = _context.Menus.First(m => m.Id == id);
            if (delMenu == null)
            {
                return NotFound();
            }

            _context.Menus.Remove(delMenu);
            _context.SaveChanges();
            return new NoContentResult();
        }
    }
}
