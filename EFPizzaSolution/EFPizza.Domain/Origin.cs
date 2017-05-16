using System;
using System.Collections.Generic;
using System.Text;

namespace EFPizza.Domain
{
    public class Origin
    {
        public int Id { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public DateTime Date { get; set; }
        public int PizzaId { get; set; }
        public Pizza Pizza { get; set; }

    }
}
