using System;
using System.Collections.Generic;
using System.Text;

namespace EFPizza.Domain
{
    public class PizzaIngredients
    {
        public int Id { get; set; }
        public Pizza Pizzas { get; set; }
        public int PizzaId { get; set; }
        public Ingredient Ingredients { get; set; }
        public int IngredientId { get; set; }

    }
}
