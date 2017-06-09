﻿using System;
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
            var Item = _context.Items.FirstOrDefault(i => i.ItemId == id);
            if (Item == null)
            {
                return NotFound();
            }

            return new ObjectResult(Item);
        }

        // POST api/Items
        [HttpPost]
        public IActionResult Create([FromBody] Item Item)
        {
            if (ModelState.IsValid)
            {
                if (Item.ItemId == 0)
                {
                    _context.Items.Add(Item);
                    _context.SaveChanges();
                    return CreatedAtRoute("GetItem", new { id = Item.ItemId }, Item);
                }
                else
                {
                    _context.Items.Update(Item);
                    _context.SaveChanges();
                    return new NoContentResult();
                }
            }
            return BadRequest();
        }

        // DELETE api/Item/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var delItem = _context.Items.First(i => i.ItemId == id);
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