using System;
using System.Collections.Generic;
using System.Text;

namespace EFPizza.Domain
{
    public class Ingredient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Gluten { get; set; }
        public Types Type { get; set; }
        public ICollection<PizzaIngredients> PizzaIngredients { get; set; }

    }

    public enum Types
    {
        Meet,
        Vegetables,
        Fruit
    }
}
