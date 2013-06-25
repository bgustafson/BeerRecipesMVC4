namespace ShipCompliantMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Recipes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateAdded = c.DateTime(nullable: false),
                        Author = c.String(),
                        Rating = c.Double(nullable: false),
                        Name = c.String(),
                        Style = c.String(),
                        Description = c.String(),
                        PrepTime = c.String(),
                        Cost = c.Int(nullable: false),
                        PrimaryFermentDays = c.Int(nullable: false),
                        SecondaryFermentDays = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Ingredients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Unit = c.String(),
                        Amount = c.Double(nullable: false),
                        Recipe_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Recipes", t => t.Recipe_Id)
                .Index(t => t.Recipe_Id);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Ingredients", new[] { "Recipe_Id" });
            DropForeignKey("dbo.Ingredients", "Recipe_Id", "dbo.Recipes");
            DropTable("dbo.Ingredients");
            DropTable("dbo.Recipes");
        }
    }
}
