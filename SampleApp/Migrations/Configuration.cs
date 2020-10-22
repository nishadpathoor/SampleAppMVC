namespace SampleApp.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SampleApp.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SampleApp.Models.ApplicationDbContext context)
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
            if (!context.Roles.Any(n => n.Name == "Admin"))
                context.Roles.AddOrUpdate(new Microsoft.AspNet.Identity.EntityFramework.IdentityRole() { Name = "Admin" });

            if (!context.Roles.Any(n => n.Name == "User"))
                context.Roles.AddOrUpdate(new Microsoft.AspNet.Identity.EntityFramework.IdentityRole() { Name = "User" });
        }
    }
}
