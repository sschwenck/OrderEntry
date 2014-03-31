namespace OrderEntry.Migrations
{
   using OrderEntry.Models;
   using System;
   using System.Data.Entity;
   using System.Data.Entity.Migrations;
   using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<OrderEntry.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "OrderEntry.Models.ApplicationDbContext";
        }

        protected override void Seed(OrderEntry.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

           //context.Lines.AddOrUpdate(
           //       l => l.Product,
           //       new Line { Product = "prod 1", Description = "test prod desc" }
           //     );
        }
    }
}
