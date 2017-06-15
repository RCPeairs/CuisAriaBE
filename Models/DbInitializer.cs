using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


namespace CuisAriaBE.Models
{
    public static class DbInitializer
    {
        public static void Initialize(CuisAriaBEContext context)
        {
            //Check to see if database already has data
            if (context.Users.Any())
            {
                return;     //DB already has data
            }

            var users = new User[]
            {
                new User {UserName = "Picabo Street", Password = "123456", Email = "Picabo@Hotmail.Com", Avatar = ""},
                new User {UserName = "Lindsey Vonn", Password = "234567", Email = "LindseyV@Hotmail.Com", Avatar = ""},
                new User {UserName = "Bode Miller", Password = "345678", Email = "BodeM@Gmail.Com", Avatar = ""},
                new User {UserName = "Ted Ligety", Password = "456789", Email = "TedL@Yahoo.Com", Avatar = ""},
                new User {UserName = "Tommy Moe", Password = "567890", Email = "TommyM@Gmail.Com", Avatar = ""}
            };
            foreach (User u in users)
            {
                context.Users.Add(u);
            }
            context.SaveChanges();





        }



    }
}
