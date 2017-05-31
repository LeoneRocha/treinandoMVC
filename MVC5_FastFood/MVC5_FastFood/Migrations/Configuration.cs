namespace MVC5_FastFood.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MVC5_FastFood.Models.DataAcess.Contexto>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "MVC5_FastFood.Models.DataAcess.Contexto";
        }

        protected override void Seed(MVC5_FastFood.Models.DataAcess.Contexto context)
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
        }

    }

    public partial class Pessoa_Naturalidade : DbMigration
    {
        public override void Up()
        {
            AddColumn("Cars", "NaturalidadeID ", c => c.Int());
        }

        public override void Down()
        {
            DropColumn("Cars", "NaturalidadeID");

        }
    }
}
