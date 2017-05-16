using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EFPizza.WebApp.Models
{
    public partial class Reviews
    {
        public int Id { get; set; }

        [StringLength(100, MinimumLength = 2)]
        [RegularExpression("([a-zA-Z0-9 .&'-]+)", ErrorMessage = "The field Title should only include letters and number.")]
        [Required]
        public string Title { get; set; }

        [StringLength(255, MinimumLength = 2)]
        [Required]
        public string Description { get; set; }

        [Range(0,5)]
        public int Grade { get; set; }

        public DateTime Date { get; set; }

        [DisplayName("Select Pizza")]
        public int PizzaId { get; set; }

        public virtual Pizzas Pizza { get; set; }
    }
}
