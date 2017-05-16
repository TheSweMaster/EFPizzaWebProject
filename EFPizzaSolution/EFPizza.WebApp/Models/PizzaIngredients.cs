using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace EFPizza.WebApp.Models
{
    public partial class PizzaIngredients
    {
        public int Id { get; set; }

        [DisplayName("Select Pizza")]
        public int PizzaId { get; set; }

        [DisplayName("Select Ingredient")]
        public int IngredientId { get; set; }

        public virtual Ingredients Ingredient { get; set; }
        public virtual Pizzas Pizza { get; set; }
    }
}
