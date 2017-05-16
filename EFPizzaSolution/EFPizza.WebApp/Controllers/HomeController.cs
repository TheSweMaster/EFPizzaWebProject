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

        public void CreateData()
        {
            _context.Database.ExecuteSqlCommand
                (
                "SET IDENTITY_INSERT[dbo].[Pizzas] ON " +
"INSERT INTO[dbo].[Pizzas]([Id], [Description], [Name], [Prize]) VALUES(1, N'Stan bästa kebab pizza.', N'Kebab Pizza', CAST(95.00 AS Decimal(18, 2))) " +
"INSERT INTO[dbo].[Pizzas] ([Id], [Description], [Name], [Prize]) VALUES(1002, N'Pizza med smak ifrån Hawaii.', N'Hawaii', CAST(75.00 AS Decimal(18, 2))) " +
"INSERT INTO[dbo].[Pizzas] ([Id], [Description], [Name], [Prize]) VALUES(2002, N'Våran egna Special pizza.', N'Special Pizza', CAST(99.00 AS Decimal(18, 2))) " +
"SET IDENTITY_INSERT[dbo].[Pizzas] OFF " +

"SET IDENTITY_INSERT [dbo].[Orgins] ON " +
"INSERT INTO [dbo].[Orgins] ([Id], [City], [Country], [Date], [PizzaId]) VALUES (1, N'Malaga', N'Spain', N'2015-11-13 00:00:00', 1) " +
"INSERT INTO [dbo].[Orgins] ([Id], [City], [Country], [Date], [PizzaId]) VALUES (2, N'Hewi Town', N'Hawaii', N'2015-11-29 00:00:00', 1002) " +
"INSERT INTO [dbo].[Orgins] ([Id], [City], [Country], [Date], [PizzaId]) VALUES (1002, N'Gothenburg', N'Sweden', N'2013-02-25 00:00:00', 2002) " +
"SET IDENTITY_INSERT [dbo].[Orgins] OFF " +

"SET IDENTITY_INSERT [dbo].[Reviews] ON " +
"INSERT INTO [dbo].[Reviews] ([Id], [Description], [Grade], [PizzaId], [Title], [Date]) VALUES (1, N'Mumssss', 3, 1, N'Bästa pizza', N'2015-11-11 00:00:00') " +
"INSERT INTO [dbo].[Reviews] ([Id], [Description], [Grade], [PizzaId], [Title], [Date]) VALUES (2, N'God pizza av högsta kvalitet', 5, 1002, N'BÄST!', N'2017-05-15 00:00:00') " +
"INSERT INTO [dbo].[Reviews] ([Id], [Description], [Grade], [PizzaId], [Title], [Date]) VALUES (1002, N'Kebab Pizza var sämst', 0, 1, N'Värsta Kebabeb', N'2017-05-12 00:00:00') " +
"INSERT INTO [dbo].[Reviews] ([Id], [Description], [Grade], [PizzaId], [Title], [Date]) VALUES (1003, N'Unik pizza med många olika smaker.', 4, 2002, N'Speciellt god', N'2015-11-28 00:00:00') " +
"SET IDENTITY_INSERT [dbo].[Reviews] OFF " +

"SET IDENTITY_INSERT [dbo].[Ingredients] ON " +
"INSERT INTO [dbo].[Ingredients] ([Id], [Gluten], [Name], [Type]) VALUES (1, 0, N'Tomatoe', 3) " +
"INSERT INTO [dbo].[Ingredients] ([Id], [Gluten], [Name], [Type]) VALUES (2, 1, N'Flour', 1) " +
"INSERT INTO [dbo].[Ingredients] ([Id], [Gluten], [Name], [Type]) VALUES (3, 0, N'Cheese', 2) " +
"INSERT INTO [dbo].[Ingredients] ([Id], [Gluten], [Name], [Type]) VALUES (4, 0, N'Lettuce', 3) " +
"INSERT INTO [dbo].[Ingredients] ([Id], [Gluten], [Name], [Type]) VALUES (5, 0, N'Shrimp', 2) " +
"INSERT INTO [dbo].[Ingredients] ([Id], [Gluten], [Name], [Type]) VALUES (1002, 1, N'Kebab', 2) " +
"INSERT INTO [dbo].[Ingredients] ([Id], [Gluten], [Name], [Type]) VALUES (1003, 0, N'Pineapple', 3) " +
"SET IDENTITY_INSERT [dbo].[Ingredients] OFF " +

"SET IDENTITY_INSERT [dbo].[PizzaIngredients] ON " +
"INSERT INTO [dbo].[PizzaIngredients] ([Id], [IngredientId], [PizzaId]) VALUES (1, 1, 1) " +
"INSERT INTO [dbo].[PizzaIngredients] ([Id], [IngredientId], [PizzaId]) VALUES (2, 1, 2002) " +
"INSERT INTO [dbo].[PizzaIngredients] ([Id], [IngredientId], [PizzaId]) VALUES (1002, 2, 2002) " +
"INSERT INTO [dbo].[PizzaIngredients] ([Id], [IngredientId], [PizzaId]) VALUES (1003, 3, 2002) " +
"INSERT INTO [dbo].[PizzaIngredients] ([Id], [IngredientId], [PizzaId]) VALUES (1004, 5, 1) " +
"SET IDENTITY_INSERT [dbo].[PizzaIngredients] OFF "

                );
            _context.SaveChanges();
        }

    }
}
