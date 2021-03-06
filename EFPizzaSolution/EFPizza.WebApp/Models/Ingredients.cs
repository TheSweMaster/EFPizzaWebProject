﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EFPizza.WebApp.Models
{
    public partial class Ingredients
    {
        public Ingredients()
        {
            PizzaIngredients = new HashSet<PizzaIngredients>();
        }

        public int Id { get; set; }

        [Range(0, 1)]
        public int Gluten { get; set; }

        [StringLength(100, MinimumLength = 2)]
        [RegularExpression("([a-zA-Z0-9 .&'-]+)", ErrorMessage = "The field Name should only include letters and number.")]
        [Required]
        public string Name { get; set; }

        [Range(0, 10)]
        public Types Type { get; set; }

        [DisplayName("Pizza Ingredients")]
        public virtual ICollection<PizzaIngredients> PizzaIngredients { get; set; }
    }

    public enum Types
    {
        Other,
        Meat,
        Vegetable,
        Fruit
    }

}
