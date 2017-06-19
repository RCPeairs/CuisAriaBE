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
                new User {UserName = "Picabo Street", Password = "123456", Email = "Picabo@Hotmail.Com", Avatar = "Moguls"},
                new User {UserName = "Lindsey Vonn", Password = "234567", Email = "LindseyV@Hotmail.Com", Avatar = "Race Gate"},
                new User {UserName = "Bode Miller", Password = "345678", Email = "BodeM@Gmail.Com", Avatar = "Bumps"},
                new User {UserName = "Ted Ligety", Password = "456789", Email = "TedL@Yahoo.Com", Avatar = "Cornice"},
                new User {UserName = "Tommy Moe", Password = "567890", Email = "TommyM@Gmail.Com", Avatar = "Trees"}
            };
            foreach (User u in users)
            {
                context.Users.Add(u);
            }
            context.SaveChanges();

            var recipes = new Recipe[]
            {
                new Recipe
                {
                    RecipeName = "Low-carb Chocolate Chip Cookies",
                    Description = "A surprisingly good low-carb cookie",
                    OwnerId = users.Single(u => u.UserName == "Picabo Street").Id, Shared = false,
                    RecipeServings = 8,
                    ServingSize = "3 cookies",
                    MyRating = 4,
                    ShareRating = 0,
                    NumShareRatings = 0,
                    CookTime = 30,
                    PrepTime = 20,
                    Notes = "Use REAL butter! Do not substitute margarine.",
                    RecipePic = "cookie pic"
                },
                new Recipe
                {
                    RecipeName = "Southwest Scrambled Eggs",
                    Description = "Spicy scrambled eggs",
                    OwnerId = users.Single(u => u.UserName == "Lindsey Vonn").Id,
                    Shared = true,
                    RecipeServings = 1,
                    ServingSize = "2 eggs",
                    MyRating = 3,
                    ShareRating = 9,
                    NumShareRatings = 4,
                    CookTime = 15,
                    PrepTime = 20,
                    Notes = "",
                    RecipePic = "scrambled eggs pic"
                },
                new Recipe
                {
                    RecipeName = "Brownies",
                    Description = "A delicious chewy chocolaty brownie",
                    OwnerId = users.Single(u => u.UserName == "Bode Miller").Id,
                    Shared = false,
                    RecipeServings = 12,
                    ServingSize = "1 brownie",
                    MyRating = 5,
                    ShareRating = 0,
                    NumShareRatings = 0,
                    CookTime = 25,
                    PrepTime = 15,
                    Notes = "Use 8x8 pan for chewier brownies",
                    RecipePic = "brownies pic"
                },
                new Recipe
                {
                    RecipeName = "Fried Chicken",
                    Description = "Crispy fried chicken",
                    OwnerId = users.Single(u => u.UserName == "Picabo Street").Id,
                    Shared = true,
                    RecipeServings = 4,
                    ServingSize = "2 pieces",
                    MyRating = 4,
                    ShareRating = 22,
                    NumShareRatings = 5,
                    CookTime = 30,
                    PrepTime = 25,
                    Notes = "",
                    RecipePic = "fried chicken pic"
                },
                new Recipe
                {
                    RecipeName = "Greek Salad",
                    Description = "A refreshing summer salad",
                    OwnerId = users.Single(u => u.UserName == "Picabo Street").Id,
                    Shared = true,
                    RecipeServings = 8,
                    ServingSize = "approx 2 cups",
                    MyRating = 3,
                    ShareRating = 21,
                    NumShareRatings = 10,
                    CookTime = 0,
                    PrepTime = 30,
                    Notes = "",
                    RecipePic = "greek salad pic"
                }
            };
            foreach (Recipe r in recipes)
            {
                context.Recipes.Add(r);
            }
            context.SaveChanges();

            var userRecipeFavorites = new UserRecipeFavorite[]
            {
                new UserRecipeFavorite
                {
                    UserId = users.Single(u => u.UserName == "Picabo Street").Id,
                    RecipeId = recipes.Single(r => r.RecipeName == "Low-carb Chocolate Chip Cookies").Id,
                    Favorite = true
                },
                new UserRecipeFavorite
                {

                    UserId = users.Single(u => u.UserName == "Lindsey Vonn").Id,
                    RecipeId = recipes.Single(r => r.RecipeName == "Southwest Scrambled Eggs").Id,
                    Favorite = true
                },
                new UserRecipeFavorite
                {
                    UserId = users.Single(u => u.UserName == "Bode Miller").Id,
                    RecipeId = recipes.Single(r => r.RecipeName == "Brownies").Id,
                    Favorite = false
                },
                 new UserRecipeFavorite
                {
                    UserId = users.Single(u => u.UserName == "Picabo Street").Id,
                    RecipeId = recipes.Single(r => r.RecipeName == "Fried Chicken").Id,
                    Favorite = true
                },
                  new UserRecipeFavorite
                {
                    UserId = users.Single(u => u.UserName == "Picabo Street").Id,
                    RecipeId = recipes.Single(r => r.RecipeName == "Greek Salad").Id,
                    Favorite = false
                },
            };
            foreach (UserRecipeFavorite u in userRecipeFavorites)
            {
                context.UserRecipeFavorite.Add(u);
            }
            context.SaveChanges();

            var keywords = new Keyword[]
            {
                new Keyword {SearchWord = "Breakfast"},
                new Keyword {SearchWord = "Brunch"},
                new Keyword {SearchWord = "Lunch"},
                new Keyword {SearchWord = "Dinner"},
                new Keyword {SearchWord = "Dessert"},
                new Keyword {SearchWord = "Southwest"},
                new Keyword {SearchWord = "Chicken"},
                new Keyword {SearchWord = "Salad"},
                new Keyword {SearchWord = "Eggs"},
                new Keyword {SearchWord = "Low-carb"},
                new Keyword {SearchWord = "Spicy"},
                new Keyword {SearchWord = "Chocolate"},
                new Keyword {SearchWord = "Cookie"},
                new Keyword {SearchWord = "Egg"},
                new Keyword {SearchWord = "Greek"}

            };
            foreach (Keyword k in keywords)
            {
                context.Keywords.Add(k);
            }
            context.SaveChanges();

            var recipeKeywords = new RecipeKeyword[]
            {
                new RecipeKeyword
                {
                    KeywordId = keywords.Single(k => k.SearchWord == "Low-carb").Id,
                    RecipeId = recipes.Single(r => r.RecipeName == "Low-carb Chocolate Chip Cookies").Id,
                },
                new RecipeKeyword
                {
                    KeywordId = keywords.Single(k => k.SearchWord == "Chocolate").Id,
                    RecipeId = recipes.Single(r => r.RecipeName == "Low-carb Chocolate Chip Cookies").Id,
                },
                new RecipeKeyword
                {
                    KeywordId = keywords.Single(k => k.SearchWord == "Cookie").Id,
                    RecipeId = recipes.Single(r => r.RecipeName == "Low-carb Chocolate Chip Cookies").Id,
                },
                new RecipeKeyword
                {
                    KeywordId = keywords.Single(k => k.SearchWord == "Low-carb").Id,
                    RecipeId = recipes.Single(r => r.RecipeName == "Southwest Scrambled Eggs").Id,
                },
                new RecipeKeyword
                {
                    KeywordId = keywords.Single(k => k.SearchWord == "Egg").Id,
                    RecipeId = recipes.Single(r => r.RecipeName == "Southwest Scrambled Eggs").Id,
                },
                new RecipeKeyword
                {
                    KeywordId = keywords.Single(k => k.SearchWord == "Southwest").Id,
                    RecipeId = recipes.Single(r => r.RecipeName == "Southwest Scrambled Eggs").Id,
                },
                new RecipeKeyword
                {
                    KeywordId = keywords.Single(k => k.SearchWord == "Spicy").Id,
                    RecipeId = recipes.Single(r => r.RecipeName == "Southwest Scrambled Eggs").Id,
                },
                new RecipeKeyword
                {
                    KeywordId = keywords.Single(k => k.SearchWord == "Chicken").Id,
                    RecipeId = recipes.Single(r => r.RecipeName == "Southwest Scrambled Eggs").Id,
                },
                new RecipeKeyword
                {
                    KeywordId = keywords.Single(k => k.SearchWord == "Dessert").Id,
                    RecipeId = recipes.Single(r => r.RecipeName == "Brownies").Id,
                },
                new RecipeKeyword
                {
                    KeywordId = keywords.Single(k => k.SearchWord == "Chocolate").Id,
                    RecipeId = recipes.Single(r => r.RecipeName == "Brownies").Id,
                },
                new RecipeKeyword
                {
                    KeywordId = keywords.Single(k => k.SearchWord == "Chicken").Id,
                    RecipeId = recipes.Single(r => r.RecipeName == "Fried Chicken").Id,
                },
                new RecipeKeyword
                {
                    KeywordId = keywords.Single(k => k.SearchWord == "Greek").Id,
                    RecipeId = recipes.Single(r => r.RecipeName == "Greek Salad").Id,
                },
                new RecipeKeyword
                {
                    KeywordId = keywords.Single(k => k.SearchWord == "Salad").Id,
                    RecipeId = recipes.Single(r => r.RecipeName == "Greek Salad").Id,
                },
                new RecipeKeyword
                {
                    KeywordId = keywords.Single(k => k.SearchWord == "Low-carb").Id,
                    RecipeId = recipes.Single(r => r.RecipeName == "Greek Salad").Id,
                }
            };
            foreach (RecipeKeyword r in recipeKeywords)
            {
                context.RecipeKeyword.Add(r);
            }
            context.SaveChanges();

            var steps = new Step[]
            {
                new Step
                {
                    Recipe = recipes.Single(r => r.RecipeName == "Low-carb Chocolate Chip Cookies"),
                    StepNumber = 1,
                    Instruction = "Preheat oven to 350 degrees F."
                },
                new Step
                {
                    Recipe = recipes.Single(r => r.RecipeName == "Low-carb Chocolate Chip Cookies"),
                    StepNumber = 2,
                    Instruction = "Heat butter in a sauce pan on medium heat until butter begins to brown. Stir occasionally. Remove from heat and allow to cool about 5 minutes."
                },
                new Step
                {
                    Recipe = recipes.Single(r => r.RecipeName == "Low-carb Chocolate Chip Cookies"),
                    StepNumber = 3,
                    Instruction = "While butter is cooling, whisk together the egg and vanilla extract. Add the sugar and sweetener and whisk again until combined. Add the butter once it has cooled and mix well."
                },
                new Step
                {
                    Recipe = recipes.Single(r => r.RecipeName == "Low-carb Chocolate Chip Cookies"),
                    StepNumber = 4,
                    Instruction = "Sift in the almond flour. Add the salt and half the chocolate chips. Mix gently until the batter is well combined and creamy. Spoon batter into 9 inch pice pan and top with remaining chocolate chips"
                },
                new Step
                {
                    Recipe = recipes.Single(r => r.RecipeName == "Low-carb Chocolate Chip Cookies"),
                    StepNumber = 5,
                    Instruction = "Bake for 25 to 30 minutes or until set and a toothpick inserted into the center of the cookie comes out clean."
                },
                new Step
                {
                    Recipe = recipes.Single(r => r.RecipeName == "Southwest Scrambled Eggs"),
                    StepNumber = 1,
                    Instruction = "Add oil to frying pan and saute peppers and chicken over medium heat until peppers start to soften. Approximately 5 minutes."
                },
                new Step
                {
                    Recipe = recipes.Single(r => r.RecipeName == "Southwest Scrambled Eggs"),
                    StepNumber = 2,
                    Instruction = "Whisk eggs with cayenne pepper, chives, salt and black pepper until frothy."
                },
                new Step
                {
                    Recipe = recipes.Single(r => r.RecipeName == "Southwest Scrambled Eggs"),
                    StepNumber = 3,
                    Instruction = "Add egg mixture to sauted peppers and chicken. Stir occasionally to scramble."
                },
                new Step
                {
                    Recipe = recipes.Single(r => r.RecipeName == "Southwest Scrambled Eggs"),
                    StepNumber = 4,
                    Instruction = "When eggs are cooked to desired firmness top with shredded cheese, diced avocado and chipotle pepper sauce."
                },
                new Step
                {
                    Recipe = recipes.Single(r => r.RecipeName == "Brownies"),
                    StepNumber = 1,
                    Instruction = "Preheat oven to 300 degrees F. Line a 9x13 inch pan with greased parchement paper"
                },
                new Step
                {
                    Recipe = recipes.Single(r => r.RecipeName == "Brownies"),
                    StepNumber = 2,
                    Instruction = "Combine cocoa, melted butter, sugar, eggs, salt, flour and vanilla. Mix until well combined. It should be very thick and sticky."
                },
                new Step
                {
                    Recipe = recipes.Single(r => r.RecipeName == "Brownies"),
                    StepNumber = 3,
                    Instruction = "Spread mixture into the prepared pan. Bake at 300 degrees F for 30 minutes. Cool completely before cutting into squares."
                },
                new Step
                {
                    Recipe = recipes.Single(r => r.RecipeName == "Fried Chicken"),
                    StepNumber = 1,
                    Instruction = "Preheat oven to 425 degrees F. Place a rack in a roasting pan or on a baking sheet."
                },
                new Step
                {
                    Recipe = recipes.Single(r => r.RecipeName == "Fried Chicken"),
                    StepNumber = 2,
                    Instruction = "Rinse chicken in cold water and pat dry. In a wide bowl mix flour with salt and black pepper. Dredge each chicken piece through the flour so it's fully coated, tapping against the edge of the bowl to shake off excess flour. Discard leftover flour."
                },
                new Step
                {
                    Recipe = recipes.Single(r => r.RecipeName == "Fried Chicken"),
                    StepNumber = 3,
                    Instruction = "Place cornflakes in a plastic bag and squeeze out as much air from the bag as possible. Seal the bag. Crush the cornflakes by rolling over the bag with a rolling pin. Pour the crushed cornflakes into a wide bowl."
                },
                new Step
                {
                    Recipe = recipes.Single(r => r.RecipeName == "Fried Chicken"),
                    StepNumber = 4,
                    Instruction = "In a bowl big enough to dredge chicken pieces, mix the buttermilk, mustard, cayenne pepper, paprika and sage. Give each floured chicken piece a good buttermilk bath and then roll in the cornflake crumbs."
                },
                new Step
                {
                    Recipe = recipes.Single(r => r.RecipeName == "Fried Chicken"),
                    StepNumber = 5,
                    Instruction = "Arrange the chicken pieces on the rack and place in the hot oven. Bake for 15 to 20 minutes, then lower the heat to 375 degrees F and bake for another 25 to 30 minutes, until cooked through and crispy. The juices should run clear when the meat is pierced with a knife."
                },
                new Step
                {
                    Recipe = recipes.Single(r => r.RecipeName == "Greek Salad"),
                    StepNumber = 1,
                    Instruction = "In a large bowl, combine the Romaine, onion, olives, bell peppers, tomatoes, cucumber and cheese."
                },
                new Step
                {
                    Recipe = recipes.Single(r => r.RecipeName == "Greek Salad"),
                    StepNumber = 2,
                    Instruction = "Whisk together the olive oil, oregano, lemon juice and black pepper. Pour dressing over salad, toss and serve." +
                    ""}
            };
            foreach (Step s in steps)
            {
                context.Steps.Add(s);
            }
            context.SaveChanges();

            var ingredients = new Ingredient[]
            {
                new Ingredient {IngredName = "all-purpose flour"},
                new Ingredient {IngredName = "butter"},
                new Ingredient {IngredName = "large egg"},
                new Ingredient {IngredName = "vanilla extract"},
                new Ingredient {IngredName = "brown sugar"},
                new Ingredient {IngredName = "natural granulated sweetener"},
                new Ingredient {IngredName = "almond flour"},
                new Ingredient {IngredName = "salt"},
                new Ingredient {IngredName = "sugar-free chocolate chips"},
                new Ingredient {IngredName = "large eggs"},
                new Ingredient {IngredName = "diced green pepper"},
                new Ingredient {IngredName = "chopped chives"},
                new Ingredient {IngredName = "diced chicken breast"},
                new Ingredient {IngredName = "olive oil"},
                new Ingredient {IngredName = "cayenne pepper"},
                new Ingredient {IngredName = "shredded cheese"},
                new Ingredient {IngredName = "avocado, diced"},
                new Ingredient {IngredName = "chipotle pepper sauce"},
                new Ingredient {IngredName = "unsweetened cocoa powder"},
                new Ingredient {IngredName = "melted butter"},
                new Ingredient {IngredName = "granulated sugar"},
                new Ingredient {IngredName = "chicken pieces"},
                new Ingredient {IngredName = "ground black pepper"},
                new Ingredient {IngredName = "cornflakes"},
                new Ingredient {IngredName = "buttermilk"},
                new Ingredient {IngredName = "mustard"},
                new Ingredient {IngredName = "paprika"},
                new Ingredient {IngredName = "ground sage"},
                new Ingredient {IngredName = "chopped romaine lettuce"},
                new Ingredient {IngredName = "red onion thinly sliced"},
                new Ingredient {IngredName = "pitted black olives"},
                new Ingredient {IngredName = "chopped red bell pepper"},
                new Ingredient {IngredName = "chopped green bell pepper"},
                new Ingredient {IngredName = "chopped tomatoes"},
                new Ingredient {IngredName = "sliced cucumber"},
                new Ingredient {IngredName = "crumbled feta cheese"},
                new Ingredient {IngredName = "dried oregano"},
                new Ingredient {IngredName = "lemon, juiced"}
            };
            foreach (Ingredient i in ingredients)
            {
                context.Ingredients.Add(i);
            }
            context.SaveChanges();

            var shoppingLists = new ShoppingList[]
            {
                new ShoppingList
                {
                    ListName = "Dinner",
                    User = users.Single(u => u.UserName == "Picabo Street"),
                },
               new ShoppingList
                {
                    ListName = "Breakfast",
                    User = users.Single(u => u.UserName == "Lindsey Vonn"),
                }
            };
            foreach (ShoppingList s in shoppingLists)
            {
                context.ShoppingLists.Add(s);
            }
            context.SaveChanges();

            var items = new Item[]
            {
                new Item
                {
                    ItemName = "chicken pieces",
                    ItemQty = 8,
                    ItemUnit = "",
                    ShoppingLists = shoppingLists.Single(s => s.ListName == "Dinner")
                },
               new Item
                {
                    ItemName = "all-purpose flour",
                    ItemQty = 0.5m,
                    ItemUnit = "cup",
                    ShoppingLists = shoppingLists.Single(s => s.ListName == "Dinner")
                },
               new Item
                {
                    ItemName = "salt",
                    ItemQty = 0.25m,
                    ItemUnit = "tsp",
                    ShoppingLists = shoppingLists.Single(s => s.ListName == "Dinner")
                },
               new Item
                {
                    ItemName = "ground black pepper",
                    ItemQty = 0.25m,
                    ItemUnit = "tsp",
                    ShoppingLists = shoppingLists.Single(s => s.ListName == "Dinner")
                },
               new Item
                {
                    ItemName = "cornflakes",
                    ItemQty = 4,
                    ItemUnit = "cups",
                    ShoppingLists = shoppingLists.Single(s => s.ListName == "Dinner")
                },
               new Item
                {
                    ItemName = "buttermilk",
                    ItemQty = 0.66m,
                    ItemUnit = "cup",
                    ShoppingLists = shoppingLists.Single(s => s.ListName == "Dinner")
                },
               new Item
                {
                    ItemName = "mustard",
                    ItemQty = 2,
                    ItemUnit = "Tbsp",
                    ShoppingLists = shoppingLists.Single(s => s.ListName == "Dinner")
                },
               new Item
                {
                    ItemName = "cayenne pepper",
                    ItemQty = 0.25m,
                    ItemUnit = "tsp",
                    ShoppingLists = shoppingLists.Single(s => s.ListName == "Dinner")
                },
               new Item
                {
                    ItemName = "paprika",
                    ItemQty = 1.5m,
                    ItemUnit = "tsp",
                    ShoppingLists = shoppingLists.Single(s => s.ListName == "Dinner")
                },
               new Item
                {
                    ItemName = "ground sage",
                    ItemQty = 0.75m,
                    ItemUnit = "tsp",
                    ShoppingLists = shoppingLists.Single(s => s.ListName == "Dinner")
                },
               new Item
                {
                    ItemName = "romaine lettuce",
                    ItemQty = 0.5m,
                    ItemUnit = "head",
                    ShoppingLists = shoppingLists.Single(s => s.ListName == "Dinner")
                },
               new Item
                {
                    ItemName = "red onion thinly sliced",
                    ItemQty = 0.5m,
                    ItemUnit = "",
                    ShoppingLists = shoppingLists.Single(s => s.ListName == "Dinner")
                },
               new Item
                {
                    ItemName = "pitted black olives",
                    ItemQty = 0.5m,
                    ItemUnit = "6oz can",
                    ShoppingLists = shoppingLists.Single(s => s.ListName == "Dinner")
                },
               new Item
                {
                    ItemName = "chopped green pepper",
                    ItemQty = 0.5m,
                    ItemUnit = "",
                    ShoppingLists = shoppingLists.Single(s => s.ListName == "Dinner")
                },
               new Item
                {
                    ItemName = "chopped red pepper",
                    ItemQty = 0.5m,
                    ItemUnit = "",
                    ShoppingLists = shoppingLists.Single(s => s.ListName == "Dinner")
                },
               new Item
                {
                    ItemName = "large tomatoe",
                    ItemQty = 1,
                    ItemUnit = "",
                    ShoppingLists = shoppingLists.Single(s => s.ListName == "Dinner")
                },
               new Item
                {
                    ItemName = "sliced cucumber",
                    ItemQty = 0.5m,
                    ItemUnit = "",
                    ShoppingLists = shoppingLists.Single(s => s.ListName == "Dinner")
                },
               new Item
                {
                    ItemName = "crumbled feta cheese",
                    ItemQty = 0.5m,
                    ItemUnit = "cup",
                    ShoppingLists = shoppingLists.Single(s => s.ListName == "Dinner")
                },
               new Item
                {
                    ItemName = "olive oil",
                    ItemQty = 3,
                    ItemUnit = "Tbsp",
                    ShoppingLists = shoppingLists.Single(s => s.ListName == "Dinner")
                },
               new Item
                {
                    ItemName = "dried oregano",
                    ItemQty = 0.5m,
                    ItemUnit = "tsp",
                    ShoppingLists = shoppingLists.Single(s => s.ListName == "Dinner")
                },
               new Item
               {
                    ItemName = "lemon, juiced",
                    ItemQty = 0.5m,
                    ItemUnit = "",
                    ShoppingLists = shoppingLists.Single(s => s.ListName == "Dinner")
                },
               new Item
                {
                    ItemName = "olive oil",
                    ItemQty = 2m,
                    ItemUnit = "tsp",
                    ShoppingLists = shoppingLists.Single(s => s.ListName == "Breakfast")
                },
               new Item
                {
                    ItemName = "diced green pepper",
                    ItemQty = 0.5m,
                    ItemUnit = "cup",
                    ShoppingLists = shoppingLists.Single(s => s.ListName == "Breakfast")
                },
               new Item
                {
                    ItemName = "diced chicken breast",
                    ItemQty = 1,
                    ItemUnit = "cup",
                    ShoppingLists = shoppingLists.Single(s => s.ListName == "Breakfast")
                },
               new Item
                {
                    ItemName = "large eggs",
                    ItemQty = 4,
                    ItemUnit = "",
                    ShoppingLists = shoppingLists.Single(s => s.ListName == "Breakfast")
                },
               new Item
                {
                    ItemName = "cayenne pepper",
                    ItemQty = 0.25m,
                    ItemUnit = "tsp",
                    ShoppingLists = shoppingLists.Single(s => s.ListName == "Breakfast")
                },
               new Item
                {
                    ItemName = "chopped chives",
                    ItemQty = 2,
                    ItemUnit = "tsp",
                    ShoppingLists = shoppingLists.Single(s => s.ListName == "Breakfast")
                },
               new Item
                {
                    ItemName = "salt",
                    ItemQty = 0.25m,
                    ItemUnit = "tsp",
                    ShoppingLists = shoppingLists.Single(s => s.ListName == "Breakfast")
                },
               new Item
                {
                    ItemName = "ground black pepper",
                    ItemQty = 0.25m,
                    ItemUnit = "tsp",
                    ShoppingLists = shoppingLists.Single(s => s.ListName == "Breakfast")
                },
               new Item
                {
                    ItemName = "shredded cheese",
                    ItemQty = 0.66m,
                    ItemUnit = "cup",
                    ShoppingLists = shoppingLists.Single(s => s.ListName == "Breakfast")
                },
               new Item
                {
                    ItemName = "avocado, diced",
                    ItemQty = 1m,
                    ItemUnit = "",
                    ShoppingLists = shoppingLists.Single(s => s.ListName == "Breakfast")
                },
               new Item
                {
                    ItemName = "chipotle pepper sauce",
                    ItemQty = 2m,
                    ItemUnit = "Tbsp",
                    ShoppingLists = shoppingLists.Single(s => s.ListName == "Breakfast")
                }
            };
            foreach (Item i in items)
            {
                context.Items.Add(i);
            }
            context.SaveChanges();

            var menus = new Menu[]
            {
                new Menu
                {
                    MenuName = "Dinner",
                    User = users.Single(u => u.UserName == "Picabo Street"),
                },
                new Menu
                {
                    MenuName = "Breakfast",
                    User = users.Single(u => u.UserName == "Lindsey Vonn"),
                }
            };
            foreach (Menu m in menus)
            {
                context.Menus.Add(m);
            }
            context.SaveChanges();

            var menuRecipes = new MenuRecipe[]
            {
            new MenuRecipe
            {
                MenuId = menus.Single(m => m.MenuName == "Dinner").Id,
                RecipeId = recipes.Single(r => r.RecipeName == "Fried Chicken").Id,
                MenuServings = 4
            },
            new MenuRecipe
            {
                MenuId = menus.Single(m => m.MenuName == "Dinner").Id,
                RecipeId = recipes.Single(r => r.RecipeName == "Greek Salad").Id,
                MenuServings = 4
            },
            new MenuRecipe
            {
                MenuId = menus.Single(m => m.MenuName == "Breakfast").Id,
                RecipeId = recipes.Single(r => r.RecipeName == "Southwest Scrambled Eggs").Id,
                MenuServings = 2
            },
            };
            foreach (MenuRecipe m in menuRecipes)
            {
                context.MenuRecipe.Add(m);
            }
            context.SaveChanges();

            var stepIngredients = new StepIngredient[]
            {
                new StepIngredient
                {
                    StepId = steps.Single(s => s.StepNumber == 2 && s.Instruction.StartsWith("Heat butter in a sauce pan o") == true).Id,
                    IngredientId = ingredients.Single(i => i.IngredName == "butter").Id,
                    IngredQty = 0.5m,
                    IngredUnit = "cup"
                },
                new StepIngredient
                {
                    StepId = steps.Single(s => s.StepNumber == 3 && s.Instruction.StartsWith("While butter is cooling, whisk") == true).Id,
                    IngredientId = ingredients.Single(i => i.IngredName == "large egg").Id,
                    IngredQty = 1m,
                    IngredUnit = ""
                },
                new StepIngredient
                {
                    StepId = steps.Single(s => s.StepNumber == 3 && s.Instruction.StartsWith("While butter is cooling, whisk") == true).Id,
                    IngredientId = ingredients.Single(i => i.IngredName == "vanilla extract").Id,
                    IngredQty = 1m,
                    IngredUnit = "tsp"
                },
                new StepIngredient
                {
                    StepId = steps.Single(s => s.StepNumber == 3 && s.Instruction.StartsWith("While butter is cooling, whisk") == true).Id,
                    IngredientId = ingredients.Single(i => i.IngredName == "brown sugar").Id,
                    IngredQty = 2m,
                    IngredUnit = "Tbsp"
                },
                new StepIngredient
                {
                    StepId = steps.Single(s => s.StepNumber == 3 && s.Instruction.StartsWith("While butter is cooling, whisk") == true).Id,
                    IngredientId = ingredients.Single(i => i.IngredName == "natural granulated sweetener").Id,
                    IngredQty = 0.25m,
                    IngredUnit = "cup"
                },
                new StepIngredient
                {
                    StepId = steps.Single(s => s.StepNumber == 4 && s.Instruction.StartsWith("Sift in the almond flour. Add t") == true).Id,
                    IngredientId = ingredients.Single(i => i.IngredName == "almond flour").Id,
                    IngredQty = 2m,
                    IngredUnit = "cups"
                },
                new StepIngredient
                {
                    StepId = steps.Single(s => s.StepNumber == 4 && s.Instruction.StartsWith("Sift in the almond flour. Add t") == true).Id,
                    IngredientId = ingredients.Single(i => i.IngredName == "salt").Id,
                    IngredQty = 0.5m,
                    IngredUnit = "tsp"
                },
                new StepIngredient
                {
                    StepId = steps.Single(s => s.StepNumber == 4 && s.Instruction.StartsWith("Sift in the almond flour. Add t") == true).Id,
                    IngredientId = ingredients.Single(i => i.IngredName == "sugar-free chocolate chips").Id,
                    IngredQty = 0.5m,
                    IngredUnit = "cup"
                },
                new StepIngredient
                {
                    StepId = steps.Single(s => s.StepNumber == 1 && s.Instruction.StartsWith("Add oil to frying pan and saute pepper") == true).Id,
                    IngredientId = ingredients.Single(i => i.IngredName == "olive oil").Id,
                    IngredQty = 1m,
                    IngredUnit = "tsp"
                },
                new StepIngredient
                {
                    StepId = steps.Single(s => s.StepNumber == 1 && s.Instruction.StartsWith("Add oil to frying pan and saute pepper") == true).Id,
                    IngredientId = ingredients.Single(i => i.IngredName == "diced green pepper").Id,
                    IngredQty = 0.25m,
                    IngredUnit = "cup"
                },
                new StepIngredient
                {
                    StepId = steps.Single(s => s.StepNumber == 1 && s.Instruction.StartsWith("Add oil to frying pan and saute pepper") == true).Id,
                    IngredientId = ingredients.Single(i => i.IngredName == "diced chicken breast").Id,
                    IngredQty = 0.5m,
                    IngredUnit = "cup"
                },
                new StepIngredient
                {
                    StepId = steps.Single(s => s.StepNumber == 2 && s.Instruction.StartsWith("Whisk eggs with cayenne pepper, chives") == true).Id,
                    IngredientId = ingredients.Single(i => i.IngredName == "large eggs").Id,
                    IngredQty = 2m,
                    IngredUnit = ""
                },
                new StepIngredient
                {
                    StepId = steps.Single(s => s.StepNumber == 2 && s.Instruction.StartsWith("Whisk eggs with cayenne pepper, chives") == true).Id,
                    IngredientId = ingredients.Single(i => i.IngredName == "cayenne pepper").Id,
                    IngredQty = 0.125m,
                    IngredUnit = "tsp"
                },
                new StepIngredient
                {
                    StepId = steps.Single(s => s.StepNumber == 2 && s.Instruction.StartsWith("Whisk eggs with cayenne pepper, chives") == true).Id,
                    IngredientId = ingredients.Single(i => i.IngredName == "chopped chives").Id,
                    IngredQty = 1m,
                    IngredUnit = "tsp"
                },
                new StepIngredient
                {
                    StepId = steps.Single(s => s.StepNumber == 2 && s.Instruction.StartsWith("Whisk eggs with cayenne pepper, chives") == true).Id,
                    IngredientId = ingredients.Single(i => i.IngredName == "salt").Id,
                    IngredQty = 0.125m,
                    IngredUnit = ""
                },
                new StepIngredient
                {
                    StepId = steps.Single(s => s.StepNumber == 2 && s.Instruction.StartsWith("Whisk eggs with cayenne pepper, chives") == true).Id,
                    IngredientId = ingredients.Single(i => i.IngredName == "ground black pepper").Id,
                    IngredQty = 0.125m,
                    IngredUnit = "tsp"
                },
                new StepIngredient
                {
                    StepId = steps.Single(s => s.StepNumber == 4 && s.Instruction.StartsWith("When eggs are cooked to desired firmness") == true).Id,
                    IngredientId = ingredients.Single(i => i.IngredName == "shredded cheese").Id,
                    IngredQty = 0.33m,
                    IngredUnit = "cup"
                },
                new StepIngredient
                {
                    StepId = steps.Single(s => s.StepNumber == 4 && s.Instruction.StartsWith("When eggs are cooked to desired firmness") == true).Id,
                    IngredientId = ingredients.Single(i => i.IngredName == "avocado, diced").Id,
                    IngredQty = 0.5m,
                    IngredUnit = ""
                },
                new StepIngredient
                {
                    StepId = steps.Single(s => s.StepNumber == 4 && s.Instruction.StartsWith("When eggs are cooked to desired firmness") == true).Id,
                    IngredientId = ingredients.Single(i => i.IngredName == "chipotle pepper sauce").Id,
                    IngredQty = 1m,
                    IngredUnit = "Tbsp"
                },
                new StepIngredient
                {
                    StepId = steps.Single(s => s.StepNumber == 2 && s.Instruction.StartsWith("Combine cocoa, melted butter, sugar, eggs") == true).Id,
                    IngredientId = ingredients.Single(i => i.IngredName == "unsweetened cocoa powder").Id,
                    IngredQty = 1m,
                    IngredUnit = "cup"
                },
                new StepIngredient
                {
                    StepId = steps.Single(s => s.StepNumber == 2 && s.Instruction.StartsWith("Combine cocoa, melted butter, sugar, eggs") == true).Id,
                    IngredientId = ingredients.Single(i => i.IngredName == "melted butter").Id,
                    IngredQty = 0.5m,
                    IngredUnit = "cup"
                },
                new StepIngredient
                {
                    StepId = steps.Single(s => s.StepNumber == 2 && s.Instruction.StartsWith("Combine cocoa, melted butter, sugar, eggs") == true).Id,
                    IngredientId = ingredients.Single(i => i.IngredName == "granulated sugar").Id,
                    IngredQty = 2m,
                    IngredUnit = "cups"
                },
                new StepIngredient
                {
                    StepId = steps.Single(s => s.StepNumber == 2 && s.Instruction.StartsWith("Combine cocoa, melted butter, sugar, eggs") == true).Id,
                    IngredientId = ingredients.Single(i => i.IngredName == "large eggs").Id,
                    IngredQty = 2m,
                    IngredUnit = ""
                },
                new StepIngredient
                {
                    StepId = steps.Single(s => s.StepNumber == 2 && s.Instruction.StartsWith("Combine cocoa, melted butter, sugar, eggs") == true).Id,
                    IngredientId = ingredients.Single(i => i.IngredName == "salt").Id,
                    IngredQty = 0.25m,
                    IngredUnit = "tsp"
                },
                new StepIngredient
                {
                    StepId = steps.Single(s => s.StepNumber == 2 && s.Instruction.StartsWith("Combine cocoa, melted butter, sugar, eggs") == true).Id,
                    IngredientId = ingredients.Single(i => i.IngredName == "all-purpose flour").Id,
                    IngredQty = 1m,
                    IngredUnit = "cup"
                },
                new StepIngredient
                {
                    StepId = steps.Single(s => s.StepNumber == 2 && s.Instruction.StartsWith("Combine cocoa, melted butter, sugar, eggs") == true).Id,
                    IngredientId = ingredients.Single(i => i.IngredName == "vanilla extract").Id,
                    IngredQty = 2m,
                    IngredUnit = "tsp"
                },
                new StepIngredient
                {
                    StepId = steps.Single(s => s.StepNumber == 2 && s.Instruction.StartsWith("Rinse chicken in cold water and pat dry.") == true).Id,
                    IngredientId = ingredients.Single(i => i.IngredName == "chicken pieces").Id,
                    IngredQty = 8m,
                    IngredUnit = ""
                },
                new StepIngredient
                {
                    StepId = steps.Single(s => s.StepNumber == 2 && s.Instruction.StartsWith("Rinse chicken in cold water and pat dry.") == true).Id,
                    IngredientId = ingredients.Single(i => i.IngredName == "all-purpose flour").Id,
                    IngredQty = 0.5m,
                    IngredUnit = "cup"
                },
                new StepIngredient
                {
                    StepId = steps.Single(s => s.StepNumber == 2 && s.Instruction.StartsWith("Rinse chicken in cold water and pat dry.") == true).Id,
                    IngredientId = ingredients.Single(i => i.IngredName == "salt").Id,
                    IngredQty = 0.25m,
                    IngredUnit = "tsp"
                },
                new StepIngredient
                {
                    StepId = steps.Single(s => s.StepNumber == 2 && s.Instruction.StartsWith("Rinse chicken in cold water and pat dry.") == true).Id,
                    IngredientId = ingredients.Single(i => i.IngredName == "ground black pepper").Id,
                    IngredQty = 0.25m,
                    IngredUnit = "tsp"
                },
                new StepIngredient
                {
                    StepId = steps.Single(s => s.StepNumber == 3 && s.Instruction.StartsWith("Place cornflakes in a plastic bag") == true).Id,
                    IngredientId = ingredients.Single(i => i.IngredName == "cornflakes").Id,
                    IngredQty = 4m,
                    IngredUnit = "cups"
                },
                new StepIngredient
                {
                    StepId = steps.Single(s => s.StepNumber == 4 && s.Instruction.StartsWith("In a bowl big enough to dredge chicken pieces") == true).Id,
                    IngredientId = ingredients.Single(i => i.IngredName == "buttermilk").Id,
                    IngredQty = .66m,
                    IngredUnit = "cup"
                },
                new StepIngredient
                {
                    StepId = steps.Single(s => s.StepNumber == 4 && s.Instruction.StartsWith("In a bowl big enough to dredge chicken pieces") == true).Id,
                    IngredientId = ingredients.Single(i => i.IngredName == "mustard").Id,
                    IngredQty = 2m,
                    IngredUnit = "Tbsp"
                },
                new StepIngredient
                {
                    StepId = steps.Single(s => s.StepNumber == 4 && s.Instruction.StartsWith("In a bowl big enough to dredge chicken pieces") == true).Id,
                    IngredientId = ingredients.Single(i => i.IngredName == "cayenne pepper").Id,
                    IngredQty = 0.25m,
                    IngredUnit = "tsp"
                },
                new StepIngredient
                {
                    StepId = steps.Single(s => s.StepNumber == 4 && s.Instruction.StartsWith("In a bowl big enough to dredge chicken pieces") == true).Id,
                    IngredientId = ingredients.Single(i => i.IngredName == "paprika").Id,
                    IngredQty = 1.5m,
                    IngredUnit = "tsp"
                },
                new StepIngredient
                {
                    StepId = steps.Single(s => s.StepNumber == 4 && s.Instruction.StartsWith("In a bowl big enough to dredge chicken pieces") == true).Id,
                    IngredientId = ingredients.Single(i => i.IngredName == "ground sage").Id,
                    IngredQty = 0.75m,
                    IngredUnit = "tsp"
                },
                new StepIngredient
                {
                    StepId = steps.Single(s => s.StepNumber == 1 && s.Instruction.StartsWith("In a large bowl, combine the Romaine, onion,") == true).Id,
                    IngredientId = ingredients.Single(i => i.IngredName == "chopped romaine lettuce").Id,
                    IngredQty = 1m,
                    IngredUnit = "head"
                },
                new StepIngredient
                {
                    StepId = steps.Single(s => s.StepNumber == 1 && s.Instruction.StartsWith("In a large bowl, combine the Romaine, onion,") == true).Id,
                    IngredientId = ingredients.Single(i => i.IngredName == "red onion thinly sliced").Id,
                    IngredQty = 1m,
                    IngredUnit = ""
                },
                new StepIngredient
                {
                    StepId = steps.Single(s => s.StepNumber == 1 && s.Instruction.StartsWith("In a large bowl, combine the Romaine, onion,") == true).Id,
                    IngredientId = ingredients.Single(i => i.IngredName == "pitted black olives").Id,
                    IngredQty = 1m,
                    IngredUnit = "6oz can"
                },
                new StepIngredient
                {
                    StepId = steps.Single(s => s.StepNumber == 1 && s.Instruction.StartsWith("In a large bowl, combine the Romaine, onion,") == true).Id,
                    IngredientId = ingredients.Single(i => i.IngredName == "chopped red bell pepper").Id,
                    IngredQty = 1m,
                    IngredUnit = ""
                },
                new StepIngredient
                {
                    StepId = steps.Single(s => s.StepNumber == 1 && s.Instruction.StartsWith("In a large bowl, combine the Romaine, onion,") == true).Id,
                    IngredientId = ingredients.Single(i => i.IngredName == "chopped green bell pepper").Id,
                    IngredQty = 1m,
                    IngredUnit = ""
                },
                new StepIngredient
                {
                    StepId = steps.Single(s => s.StepNumber == 1 && s.Instruction.StartsWith("In a large bowl, combine the Romaine, onion,") == true).Id,
                    IngredientId = ingredients.Single(i => i.IngredName == "chopped tomatoes").Id,
                    IngredQty = 2m,
                    IngredUnit = "large"
                },
                new StepIngredient
                {
                    StepId = steps.Single(s => s.StepNumber == 1 && s.Instruction.StartsWith("In a large bowl, combine the Romaine, onion,") == true).Id,
                    IngredientId = ingredients.Single(i => i.IngredName == "sliced cucumber").Id,
                    IngredQty = 1m,
                    IngredUnit = ""
                },
                new StepIngredient
                {
                    StepId = steps.Single(s => s.StepNumber == 1 && s.Instruction.StartsWith("In a large bowl, combine the Romaine, onion,") == true).Id,
                    IngredientId = ingredients.Single(i => i.IngredName == "crumbled feta cheese").Id,
                    IngredQty = 1m,
                    IngredUnit = "cup"
                },
                new StepIngredient
                {
                    StepId = steps.Single(s => s.StepNumber == 2 && s.Instruction.StartsWith("Whisk together the olive oil, oregano, ") == true).Id,
                    IngredientId = ingredients.Single(i => i.IngredName == "olive oil").Id,
                    IngredQty = 6m,
                    IngredUnit = "Tbsp"
                },
                new StepIngredient
                {
                    StepId = steps.Single(s => s.StepNumber == 2 && s.Instruction.StartsWith("Whisk together the olive oil, oregano, ") == true).Id,
                    IngredientId = ingredients.Single(i => i.IngredName == "dried oregano").Id,
                    IngredQty = 1m,
                    IngredUnit = "tsp"
                },
                new StepIngredient
                {
                    StepId = steps.Single(s => s.StepNumber == 2 && s.Instruction.StartsWith("Whisk together the olive oil, oregano, ") == true).Id,
                    IngredientId = ingredients.Single(i => i.IngredName == "lemon, juiced").Id,
                    IngredQty = 1m,
                    IngredUnit = ""
                },
                new StepIngredient
                {
                    StepId = steps.Single(s => s.StepNumber == 2 && s.Instruction.StartsWith("Whisk together the olive oil, oregano, ") == true).Id,
                    IngredientId = ingredients.Single(i => i.IngredName == "ground black pepper").Id,
                    IngredQty = 0m,
                    IngredUnit = "to taste"
                }
            };
            foreach (StepIngredient s in stepIngredients)
            {
                context.StepIngredient.Add(s);
            }
            context.SaveChanges();
        }
    }
}
