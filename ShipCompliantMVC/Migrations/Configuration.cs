using ShipCompliantMVC.Models;

namespace ShipCompliantMVC.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ShipCompliantMVC.Models.RecipeDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ShipCompliantMVC.Models.RecipeDbContext context)
        {
            context.Recipes.AddOrUpdate(i => i.Name,
                new Recipe
                {
                    Name = "Amber Ale",
                    DateAdded = DateTime.Parse("2011-03-01"),
                    Author = "Ted",
                    Rating = 4.2,
                    Style = "Amber",
                    MashType = "Extract",
                    Description = "OK Beer",
                    PrepTime = "3 hours",
                    Cost = 1,
                    PrimaryFermentDays = 5,
                    SecondaryFermentDays = 20,
                    Ingredients = null,
                    Steps = null
                },

                 new Recipe
                 {
                     Name = "IT IPA",
                     DateAdded = DateTime.Parse("2011-10-11"),
                     Author = "Bob",
                     Rating = 4.2,
                     Style = "IPA",
                     MashType = "Partial Mash",
                     Description = "IPA for IT people",
                     PrepTime = "9 hours",
                     Cost = 3,
                     PrimaryFermentDays = 5,
                     SecondaryFermentDays = 20,
                     Ingredients = null,
                     Steps = null
                 },

                 new Recipe
                 {
                     Name = "Double Java Porter",
                     DateAdded = DateTime.Parse("2009-03-11"),
                     Author = "Bill",
                     Rating = 4.2,
                     Style = "Porter",
                     MashType = "All Grain",
                     Description = "Heavy Porter",
                     PrepTime = "5 hours",
                     Cost = 6,
                     PrimaryFermentDays = 15,
                     SecondaryFermentDays = 10,
                     Ingredients = null,
                     Steps = null
                 },

               new Recipe
               {
                   Name = "Serious Stout",
                   DateAdded = DateTime.Parse("2009-07-17"),
                   Author = "Cybil",
                   Rating = 4.2,
                   Style = "Stout",
                   MashType = "Extract",
                   Description = "Stout that is serious",
                   PrepTime = "9 hours",
                   Cost = 3,
                   PrimaryFermentDays = 5,
                   SecondaryFermentDays = 20,
                   Ingredients = null,
                   Steps = null
               },

               new Recipe
               {
                   Name = "George Washington Apple Amber Ale",
                   DateAdded = DateTime.Parse("2009-07-17"),
                   Author = "Cybil",
                   Rating = 4.2,
                   Style = "Amber Ale",
                   MashType = "Extract",
                   Description = "Beer for fourth of July in rememberance of the first President.",
                   PrepTime = "9 hours",
                   Cost = 3,
                   PrimaryFermentDays = 5,
                   SecondaryFermentDays = 20,
                   Ingredients = null,
                   Steps = null
               }
           );
        }
    }
}
