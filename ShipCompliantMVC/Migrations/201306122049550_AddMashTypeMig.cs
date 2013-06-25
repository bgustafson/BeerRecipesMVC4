namespace ShipCompliantMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMashTypeMig : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Recipes", "MashType", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Recipes", "MashType");
        }
    }
}
