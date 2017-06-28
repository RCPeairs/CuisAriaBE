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


        // DELETE DeleteUser/[UserId]
        //[HttpDelete, Route("DeleteUser/{userId}")]
        //public IActionResult Delete(int userId)
        //{
        //    var delUser = _context.Users.First(u => u.Id == userId);
        //    if (delUser == null)
        //    {
        //        return NotFound();
        //    }

        //    // Delete user entries from UserRecipeFavorites
        //    // Delete MenuRecipe entries
        //    // Delete user menus
        //    // Delete ShoppingList items for user shopping list
        //    // Delete user ShoppingList
        //    // Delete StepIngredient entries for use owned recipes
        //    // Delete RecipeKeyword entries
        //    // Delete Steps for user owned recipes
        //    // Delete user owned Recipes
        //    // Delete User



        //    _context.Users.Remove(delUser);
        //    _context.SaveChanges();
        //    return new NoContentResult();
        //}
    }
}
