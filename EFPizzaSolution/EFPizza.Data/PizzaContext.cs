using Microsoft.EntityFrameworkCore;
using EFPizza.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFPizza.Data
{
    public class PizzaContext : DbContext
    {
        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<Origin> Orgins { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<PizzaIngredients> PizzaIngredients { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
              "Server = (localdb)\\mssqllocaldb; Database = EfPizza; Trusted_Connection = True; ");
        }
    }
}
