namespace MVC5_FastFood.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.NaturalidadeCidades",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Pessoas",
                c => new
                    {
                        Codigo = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        NaturalidadeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Codigo)
                .ForeignKey("dbo.NaturalidadeCidades", t => t.NaturalidadeId, cascadeDelete: true)
                .Index(t => t.NaturalidadeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pessoas", "NaturalidadeId", "dbo.NaturalidadeCidades");
            DropIndex("dbo.Pessoas", new[] { "NaturalidadeId" });
            DropTable("dbo.Pessoas");
            DropTable("dbo.NaturalidadeCidades");
        }
    }
}
