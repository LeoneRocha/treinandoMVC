using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVC5_FastFood.Models.DataAcess
{
    public class Contexto : DbContext
    {
        //http://www.entityframeworktutorial.net/code-first/configure-one-to-many-relationship-in-code-first.aspx
        //https://docs.microsoft.com/en-us/aspnet/mvc/overview/getting-started/getting-started-with-ef-using-mvc/migrations-and-deployment-with-the-entity-framework-in-an-asp-net-mvc-application
        //https://msdn.microsoft.com/pt-br/library/jj856238.aspx
        //https://coding.abel.nu/2012/02/updating-a-table-with-ef-migrations/
        //https://stackoverflow.com/questions/23662755/how-to-add-new-table-to-existing-database-code-first
        public Contexto():base("ConnMVC") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //one-to-many 
            modelBuilder.Entity<Pessoa>()
                        .HasRequired<NaturalidadeCidade>(s => s.Naturalidade) // Student entity requires Standard 
                        .WithMany(s => s.Pessoas).HasForeignKey(s => s.NaturalidadeId); ; // Standard entity includes many Students entities

        }
        public DbSet<Pessoa> Pessoas { get; set; }

        public System.Data.Entity.DbSet<MVC5_FastFood.Models.NaturalidadeCidade> NaturalidadeCidades { get; set; }
    }
}