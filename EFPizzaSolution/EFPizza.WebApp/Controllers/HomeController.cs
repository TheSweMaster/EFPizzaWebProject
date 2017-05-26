using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EFPizza.WebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace EFPizza.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly EFPizzaContext _context;

        public HomeController(EFPizzaContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CreateDatabase()
        {
            ClearDatabase();
            CreateData();
            return RedirectToAction("Index", "Pizzas");
        }

        public IActionResult CreateDatabaseV2()
        {
            ClearDatabase();
            CreateDataV2();
            return RedirectToAction("Index", "Pizzas");
        }

        public IActionResult ClearDatabaseAction()
        {
            ClearDatabase();
            return RedirectToAction("Index", "Pizzas");
        }

        public IActionResult Error()
        {
            return View();
        }

        public void ClearDatabase()
        {
            var pizzaIngredients = _context.PizzaIngredients.Select(x => x);
            _context.PizzaIngredients.RemoveRange(pizzaIngredients);

            var ingredients = _context.Ingredients.Select(x => x);
            _context.Ingredients.RemoveRange(ingredients);

            var reviews = _context.Reviews.Select(x => x);
            _context.Reviews.RemoveRange(reviews);

            var origins = _context.Orgins.Select(x => x);
            _context.Orgins.RemoveRange(origins);

            var pizzas = _context.Pizzas.Select(x => x);
            _context.Pizzas.RemoveRange(pizzas);

            _context.SaveChanges();
        }

        private void CreateDataV2()
        {
            var piz1 = new Pizzas { Name = "Caprichosa", Description = "Pizza from Italy with great taste.", Prize = 70 };
            var piz2 = new Pizzas { Name = "Veggie", Description = "Veggie Pizza for vegitarians", Prize = 65 };

            var pizs = new List<Pizzas>()
            {
                piz1, piz2,
            };

            var revs = new List<Reviews>()
            {
                new Reviews { Title ="Best Pizza with mushrooms", Description="I love this Pizza with mushrooms on it.", Grade=4, Date=DateTime.Now, Pizza = piz1 },
                new Reviews { Title ="Worst Pizza with mushrooms", Description="I hate this Pizza with mushrooms on it.", Grade=1, Date=DateTime.Now.AddDays(-1), Pizza = piz1 },
                new Reviews { Title ="Only Bland Vegetables", Description="Tasteless vegetables on this soggy Pizza.", Grade=0, Date=DateTime.Now, Pizza = piz2 },
                new Reviews { Title ="Great Veggie Pizza", Description="Good choice if you are a vegitarian.", Grade=5, Date=DateTime.Now.AddDays(-6), Pizza = piz2 },
            };

            var orgs = new List<Orgins>()
            {
                new Orgins { City = "Rome", Country = "Italy", Date = DateTime.Now.Date.AddYears(-186), Pizza = piz1 },
                new Orgins { City = "Gothenburg", Country = "Sweden", Date = DateTime.Now.Date.AddYears(-6), Pizza = piz2 },
            };

            var ing1 = new Ingredients { Name = "Cheese", Gluten = 0, Type = Types.Other };
            var ing2 = new Ingredients { Name = "Flour", Gluten = 1, Type = Types.Other };
            var ing3 = new Ingredients { Name = "Tomatoe", Gluten = 0, Type = Types.Vegetable };
            var ing4 = new Ingredients { Name = "Lettuce", Gluten = 0, Type = Types.Vegetable };
            var ing5 = new Ingredients { Name = "Mushroom", Gluten = 0, Type = Types.Meat };
            var ing6 = new Ingredients { Name = "Kebab", Gluten = 1, Type = Types.Meat };
            var ing7 = new Ingredients { Name = "Shrimp", Gluten = 0, Type = Types.Meat };
            var ing8 = new Ingredients { Name = "Pineapple", Gluten = 0, Type = Types.Fruit };
            var ing9 = new Ingredients { Name = "Ham", Gluten = 0, Type = Types.Meat };
            var ing10 = new Ingredients { Name = "Broccoli", Gluten = 0, Type = Types.Vegetable };

            var ings = new List<Ingredients>()
            {
                ing1, ing2, ing3, ing4, ing5, ing6, ing7, ing8, ing9, ing10,
            };

            var pizIngs = new List<PizzaIngredients>()
            {
                new PizzaIngredients { Ingredient = ing1, Pizza = piz1 },
                new PizzaIngredients { Ingredient = ing2, Pizza = piz1 },
                new PizzaIngredients { Ingredient = ing3, Pizza = piz1 },
                new PizzaIngredients { Ingredient = ing5, Pizza = piz1 },
                new PizzaIngredients { Ingredient = ing9, Pizza = piz1 },
                new PizzaIngredients { Ingredient = ing1, Pizza = piz2 },
                new PizzaIngredients { Ingredient = ing2, Pizza = piz2 },
                new PizzaIngredients { Ingredient = ing3, Pizza = piz2 },
                new PizzaIngredients { Ingredient = ing4, Pizza = piz2 },
                new PizzaIngredients { Ingredient = ing10, Pizza = piz2 },
            };

            _context.Pizzas.AddRange(pizs);
            _context.Reviews.AddRange(revs);
            _context.Orgins.AddRange(orgs);
            _context.Ingredients.AddRange(ings);
            _context.PizzaIngredients.AddRange(pizIngs);
            _context.SaveChanges();
        }

        public void CreateData()
        {
            _context.Database.ExecuteSqlCommand
                (
                "SET IDENTITY_INSERT[dbo].[Pizzas] ON " +
"INSERT INTO[dbo].[Pizzas]([Id], [Description], [Name], [Prize]) VALUES(1, N'Stan bästa kebab pizza.', N'Kebab Pizza', CAST(95.00 AS Decimal(18, 2))) " +
"INSERT INTO[dbo].[Pizzas] ([Id], [Description], [Name], [Prize]) VALUES(1002, N'Pizza med smak ifrån Hawaii.', N'Hawaii', CAST(75.00 AS Decimal(18, 2))) " +
"INSERT INTO[dbo].[Pizzas] ([Id], [Description], [Name], [Prize]) VALUES(2002, N'Våran egna Special pizza.', N'Special Pizza', CAST(99.00 AS Decimal(18, 2))) " +
"INSERT INTO[dbo].[Pizzas] ([Id], [Description], [Name], [Prize]) VALUES(2003, N'Den senaste pizzan.', N'Nya Pizzan', CAST(105.00 AS Decimal(18, 2))) " +
"SET IDENTITY_INSERT[dbo].[Pizzas] OFF " +

"SET IDENTITY_INSERT [dbo].[Orgins] ON " +
"INSERT INTO [dbo].[Orgins] ([Id], [City], [Country], [Date], [PizzaId]) VALUES (1, N'Malaga', N'Spain', N'2015-11-13 00:00:00', 1) " +
"INSERT INTO [dbo].[Orgins] ([Id], [City], [Country], [Date], [PizzaId]) VALUES (2, N'Hewi Town', N'Hawaii', N'2015-11-29 00:00:00', 1002) " +
"INSERT INTO [dbo].[Orgins] ([Id], [City], [Country], [Date], [PizzaId]) VALUES (1002, N'Gothenburg', N'Sweden', N'2013-02-25 00:00:00', 2002) " +
"SET IDENTITY_INSERT [dbo].[Orgins] OFF " +

"SET IDENTITY_INSERT [dbo].[Reviews] ON " +
"INSERT INTO [dbo].[Reviews] ([Id], [Description], [Grade], [PizzaId], [Title], [Date]) VALUES (1, N'Mumssss', 3, 1, N'Bästa pizzan', N'2017-05-15 00:00:00') " +
"INSERT INTO [dbo].[Reviews] ([Id], [Description], [Grade], [PizzaId], [Title], [Date]) VALUES (2, N'God pizza av högsta kvalitet', 5, 1002, N'BÄST!', N'2017-05-14 00:00:00') " +
"INSERT INTO [dbo].[Reviews] ([Id], [Description], [Grade], [PizzaId], [Title], [Date]) VALUES (1002, N'Kebab Pizzan var sämst', 1, 1, N'Värsta Kebaben', N'2017-05-16 00:00:00') " +
"INSERT INTO [dbo].[Reviews] ([Id], [Description], [Grade], [PizzaId], [Title], [Date]) VALUES (1003, N'Unik pizza med många olika smaker.', 4, 2002, N'Speciellt god', N'2017-05-18 00:00:00') " +
"SET IDENTITY_INSERT [dbo].[Reviews] OFF " +

"SET IDENTITY_INSERT [dbo].[Ingredients] ON " +
"INSERT INTO [dbo].[Ingredients] ([Id], [Gluten], [Name], [Type]) VALUES (1, 0, N'Tomatoe', 2) " +
"INSERT INTO [dbo].[Ingredients] ([Id], [Gluten], [Name], [Type]) VALUES (2, 1, N'Flour', 0) " +
"INSERT INTO [dbo].[Ingredients] ([Id], [Gluten], [Name], [Type]) VALUES (3, 0, N'Cheese', 0) " +
"INSERT INTO [dbo].[Ingredients] ([Id], [Gluten], [Name], [Type]) VALUES (4, 0, N'Lettuce', 2) " +
"INSERT INTO [dbo].[Ingredients] ([Id], [Gluten], [Name], [Type]) VALUES (5, 0, N'Shrimp', 1) " +
"INSERT INTO [dbo].[Ingredients] ([Id], [Gluten], [Name], [Type]) VALUES (6, 1, N'Kebab', 1) " +
"INSERT INTO [dbo].[Ingredients] ([Id], [Gluten], [Name], [Type]) VALUES (7, 0, N'Pineapple', 3) " +
"SET IDENTITY_INSERT [dbo].[Ingredients] OFF " +

"SET IDENTITY_INSERT [dbo].[PizzaIngredients] ON " +
"INSERT INTO [dbo].[PizzaIngredients] ([Id], [IngredientId], [PizzaId]) VALUES (1, 1, 1) " +
"INSERT INTO [dbo].[PizzaIngredients] ([Id], [IngredientId], [PizzaId]) VALUES (2, 2, 1) " +
"INSERT INTO [dbo].[PizzaIngredients] ([Id], [IngredientId], [PizzaId]) VALUES (3, 3, 1) " +
"INSERT INTO [dbo].[PizzaIngredients] ([Id], [IngredientId], [PizzaId]) VALUES (4, 6, 1) " +
"INSERT INTO [dbo].[PizzaIngredients] ([Id], [IngredientId], [PizzaId]) VALUES (5, 1, 2002) " +
"INSERT INTO [dbo].[PizzaIngredients] ([Id], [IngredientId], [PizzaId]) VALUES (6, 2, 2002) " +
"INSERT INTO [dbo].[PizzaIngredients] ([Id], [IngredientId], [PizzaId]) VALUES (7, 3, 2002) " +
"INSERT INTO [dbo].[PizzaIngredients] ([Id], [IngredientId], [PizzaId]) VALUES (8, 4, 2002) " +
"INSERT INTO [dbo].[PizzaIngredients] ([Id], [IngredientId], [PizzaId]) VALUES (9, 5, 2002) " +
"INSERT INTO [dbo].[PizzaIngredients] ([Id], [IngredientId], [PizzaId]) VALUES (10, 1, 1002) " +
"INSERT INTO [dbo].[PizzaIngredients] ([Id], [IngredientId], [PizzaId]) VALUES (11, 2, 1002) " +
"INSERT INTO [dbo].[PizzaIngredients] ([Id], [IngredientId], [PizzaId]) VALUES (12, 3, 1002) " +
"INSERT INTO [dbo].[PizzaIngredients] ([Id], [IngredientId], [PizzaId]) VALUES (13, 7, 1002) " +
"INSERT INTO [dbo].[PizzaIngredients] ([Id], [IngredientId], [PizzaId]) VALUES (14, 4, 1) " +
"SET IDENTITY_INSERT [dbo].[PizzaIngredients] OFF "

                );
            _context.SaveChanges();
        }

    }
}
