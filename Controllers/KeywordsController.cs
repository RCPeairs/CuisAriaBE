using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CuisAriaBE.Models;

namespace CuisAriaBE.Controllers
{
    [Route("api/[controller]")]
    public class KeywordsController : Controller
    {
        private readonly CuisAriaBEContext _context;

        public KeywordsController(CuisAriaBEContext context)
        {
            _context = context;
        }

        // GET: api/Keywords
        [HttpGet]
        public IEnumerable<Keyword> GetAllKeywords()
        {
            return _context.Keywords.ToList();
        }

        // GET api/Keywords/5
        [HttpGet("{id}", Name = "GetKeyword")]
        public IActionResult GetById(int id)
        {
            var keyword = _context.Keywords.FirstOrDefault(k => k.KeywordId == id);
            if (keyword == null)
            {
                return NotFound();
            }

            return new ObjectResult(keyword);
        }

        // POST api/Keywords
        [HttpPost]
        public IActionResult Create([FromBody] Keyword keyword)
        {
            if (ModelState.IsValid)
            {
                if (keyword.KeywordId == 0)
                {
                    _context.Keywords.Add(keyword);
                    _context.SaveChanges();
                    return CreatedAtRoute("Getkeyword", new { id = keyword.KeywordId }, keyword);
                }
                else
                {
                    _context.Keywords.Update(keyword);
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
            var delKeyword = _context.Keywords.First(k => k.KeywordId == id);
            if (delKeyword == null)
            {
                return NotFound();
            }

            _context.Keywords.Remove(delKeyword);
            _context.SaveChanges();
            return new NoContentResult();
        }
    }
}
