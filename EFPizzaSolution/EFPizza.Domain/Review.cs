using System;
using System.Collections.Generic;
using System.Text;

namespace EFPizza.Domain
{
    public class Review
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Grade { get; set; } //eller Enum?
        public DateTime Date { get; set; }
        public int PizzaId { get; set; }
        public Pizza Pizzas { get; set; }

    }
}
