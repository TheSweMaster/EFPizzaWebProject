using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EFPizza.WebApp.Models
{
    public partial class Orgins
    {
        public int Id { get; set; }

        [StringLength(100, MinimumLength = 2)]
        [RegularExpression("([a-zA-Z0-9 .&'-]+)", ErrorMessage = "The field Country should only include letters and number.")]
        [Required]
        public string Country { get; set; }

        [StringLength(100, MinimumLength = 2)]
        [RegularExpression("([a-zA-Z0-9 .&'-]+)", ErrorMessage = "The field City should only include letters and number.")]
        [Required]
        public string City { get; set; }

        [CustomDateRange]
        [Required]
        public DateTime Date { get; set; }

        [DisplayName("Select Pizza")]
        public int PizzaId { get; set; }

        public virtual Pizzas Pizza { get; set; }
    }

    public class CustomDateRangeAttribute : RangeAttribute
    {
        public CustomDateRangeAttribute()
          : base(typeof(DateTime),
                  new DateTime(1750, 01, 01).ToString(),
                  DateTime.Now.Date.ToString())
        { }
    }
}
