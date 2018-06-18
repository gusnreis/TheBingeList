namespace BingeList.Migrations.ASPNET
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class ConfigA : DbMigrationsConfiguration<BingeList.Models.ApplicationDbContext>
    {
        public ConfigA()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\ASPNET";
        }

        protected override void Seed(BingeList.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
