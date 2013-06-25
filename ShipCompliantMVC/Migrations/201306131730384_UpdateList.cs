namespace ShipCompliantMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateList : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Steps",
                c => new
                    {
                        StepId = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Num = c.Int(nullable: false),
                        Recipe_Id = c.Int(),
                    })
                .PrimaryKey(t => t.StepId)
                .ForeignKey("dbo.Recipes", t => t.Recipe_Id)
                .Index(t => t.Recipe_Id);
            
            DropPrimaryKey("dbo.Ingredients", new[] { "Id" });
            DropColumn("dbo.Ingredients", "Id");
            AddColumn("dbo.Ingredients", "IngredientId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Ingredients", "IngredientId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Ingredients", "Id", c => c.Int(nullable: false, identity: true));
            DropIndex("dbo.Steps", new[] { "Recipe_Id" });
            DropForeignKey("dbo.Steps", "Recipe_Id", "dbo.Recipes");
            DropPrimaryKey("dbo.Ingredients", new[] { "IngredientId" });
            DropColumn("dbo.Ingredients", "IngredientId");
            DropTable("dbo.Steps");
        }
    }
}
