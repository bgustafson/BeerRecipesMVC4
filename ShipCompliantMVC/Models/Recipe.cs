using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShipCompliantMVC.Models
{
    public class Recipe
    {
        public int Id { get; set; }

        [Display(Name = "Date Added")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime DateAdded { get; set; }

        public string Author { get; set; }

        [Range(0.0, 5.0)]
        public double Rating { get; set; }

        public string Name { get; set; }

        public string Style { get; set; }

        [Display(Name = "Mash Type")]
        public string MashType { get; set; }

        public string Description { get; set; }

        [Display(Name = "Prep Time")]
        public string PrepTime { get; set; }

        [Range(1, 1000)]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:c}")]
        public int Cost { get; set; }

        [Range(1, 1000)]
        [Display(Name = "Primary Days")]
        public int PrimaryFermentDays { get; set; }

        [Range(1, 1000)]
        [Display(Name = "Secondary Days")]
        public int SecondaryFermentDays { get; set; }

        public virtual ICollection<Ingredient> Ingredients { get; set; }

        public virtual ICollection<Step> Steps { get; set; }
    }
}