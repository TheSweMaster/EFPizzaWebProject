using System;
using System.Collections.Generic;
using System.Text;

namespace EFPizza.Domain
{
    public class Pizza
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Prize { get; set; }
        public string Description { get; set; }
        public Origin Origin { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public ICollection<PizzaIngredients> PizzaIngredients { get; set; }
    }
}
