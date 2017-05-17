using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EFPizza.WebApp.Models
{
    public partial class Pizzas
    {
        public Pizzas()
        {
            PizzaIngredients = new HashSet<PizzaIngredients>();
            Reviews = new HashSet<Reviews>();
        }

        public int Id { get; set; }

        [StringLength(100, MinimumLength = 2)]
        [RegularExpression("([a-zA-Z0-9 .&'-]+)", ErrorMessage = "The field Name should only include letters and number.")]
        [Required]
        public string Name { get; set; }

        [StringLength(255, MinimumLength = 2)]
        [Required]
        public string Description { get; set; }

        [Range(0,1000)]
        [Required]
        public decimal Prize { get; set; }

        public virtual Orgins Orgins { get; set; }

        [DisplayName("Pizza Ingredients")]
        public virtual ICollection<PizzaIngredients> PizzaIngredients { get; set; }
        public virtual ICollection<Reviews> Reviews { get; set; }
    }
}
