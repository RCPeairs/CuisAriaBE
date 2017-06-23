using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CuisAriaBE.Models;

namespace CuisAriaBE.Controllers
{
    public class UsersController : Controller
    {
        private readonly CuisAriaBEContext _context;

        public UsersController(CuisAriaBEContext context)
        {
            _context = context;
        }

        // GET GetUserByName/UserName
        [HttpGet, Route("GetUserByName/{name}")]
        public IActionResult GetByValue(string name)
        {
            var user = _context.Users.FirstOrDefault(u => u.UserName.ToLower() == name.ToLower());
            if (user == null)
            {
                return NotFound();
            }

            return new ObjectResult(user);
        }

        // POST AddEditUser/UserId
        [HttpPost, Route("AddEditUser")]
        public IActionResult Create([FromBody] User user)
        {
            if (ModelState.IsValid)
            {
                // Add check here to insure UserName is unique


                if (user.Id == 0)
                {
                    _context.Users.Add(user);
                    _context.SaveChanges();
                    return CreatedAtRoute("", new { id = user.Id }, user);   
                }
                else
                {
                    _context.Users.Update(user);
                    _context.SaveChanges();
                    return new NoContentResult();
                }
            }
            return BadRequest();
        }








        // GET: api/Users
        //[HttpGet]
        //public IEnumerable<User> GetAllUsers()
        //{
        //    return _context.Users.ToList();
        //}

        //// GET api/Users/5
        //[HttpGet("{id}", Name = "GetUser")]
        //public IActionResult GetById(int id)
        //{
        //    var user = _context.Users.FirstOrDefault(u => u.Id == id);
        //    if (user == null)
        //    {
        //        return NotFound();
        //    }

        //    return new ObjectResult(user);
        //}





        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var delUser = _context.Users.First(u => u.Id == id);
            if (delUser == null)
            {
                return NotFound();
            }

            _context.Users.Remove(delUser);
            _context.SaveChanges();
            return new NoContentResult();
        }
    }
}
