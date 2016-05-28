namespace FlatRent.Migrations
{
    using Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<FlatRent.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "FlatRent.Models.ApplicationDbContext";
        }

        protected override void Seed(FlatRent.Models.ApplicationDbContext context)
        {
            //Kitchen, Bathroom, WiFi, TV, Hairdryer, Iron, Fridge, Microwave, Kettle, Dishes, Linens
            context.Facilities.AddOrUpdate(
              p => p.Type,
              new Facility { Type = "Kitchen", Description = "Special room to cook" },
              new Facility { Type = "Bathroom", Description = "Special room where you can freshen up yourself and have a rest after hard day" },
              new Facility { Type = "WiFi", Description = "WiFi connection is available, so you can get to the Internet" },
              new Facility { Type = "TV", Description = "There is televisor with some possibilities - to watch some casual programms, or even to watch YouTobe or NetFlix (etc.)" },
              new Facility { Type = "Hairdryer", Description = "There is hairdryer, so you can be sure that you can dry your hair in short period of time" },
              new Facility { Type = "Iron", Description = "There is a iron, so you can pat your clothes whenever you need tha." },
              new Facility { Type = "Fridge", Description = "There is a fridge, you can buy some eating, like milk products and store it in fridge" },
              new Facility { Type = "Microwave", Description = "There is a microwave, so you can heat up food that are needing this" },
              new Facility { Type = "Kettle", Description = "There you always can heat up water - to make coffee/tea for example" },
              new Facility { Type = "Dishes", Description = "There are some dishes, so you dont have to buy one-time dish to eat" },
              new Facility { Type = "Linens", Description = "There are linens, so you can be sure about hygiene while sleeping in flat's bad" }
              );

        }
    }
}
