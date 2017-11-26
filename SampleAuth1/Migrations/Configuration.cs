namespace SampleAuth1.Migrations
{
    using SampleAuth1.DBService;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SampleAuth1.DBService.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SampleAuth1.DBService.ApplicationDbContext context)
        {
            SeedMyDb seed = new SeedMyDb();
            seed.FillDB(context);
        }
    }
}
