namespace ConstructionSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumnsInUserTBL : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "City", c => c.String());
            AddColumn("dbo.AspNetUsers", "Gender", c => c.Boolean());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Gender");
            DropColumn("dbo.AspNetUsers", "City");
        }
    }
}
