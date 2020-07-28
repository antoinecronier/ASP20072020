namespace Demo_Module6_P2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Conducteurs",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Firstname = c.String(),
                        Lastname = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Trajets",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        Voiture_Id = c.Long(),
                        Voiture_Id1 = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Voitures", t => t.Voiture_Id)
                .ForeignKey("dbo.Voitures", t => t.Voiture_Id1)
                .Index(t => t.Voiture_Id)
                .Index(t => t.Voiture_Id1);
            
            CreateTable(
                "dbo.Voitures",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        Kilometers = c.Int(nullable: false),
                        Driver_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Conducteurs", t => t.Driver_Id)
                .Index(t => t.Driver_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Trajets", "Voiture_Id1", "dbo.Voitures");
            DropForeignKey("dbo.Voitures", "Driver_Id", "dbo.Conducteurs");
            DropForeignKey("dbo.Trajets", "Voiture_Id", "dbo.Voitures");
            DropIndex("dbo.Voitures", new[] { "Driver_Id" });
            DropIndex("dbo.Trajets", new[] { "Voiture_Id1" });
            DropIndex("dbo.Trajets", new[] { "Voiture_Id" });
            DropTable("dbo.Voitures");
            DropTable("dbo.Trajets");
            DropTable("dbo.Conducteurs");
        }
    }
}
