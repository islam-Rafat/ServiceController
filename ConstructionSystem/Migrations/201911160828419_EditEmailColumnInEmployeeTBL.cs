namespace ConstructionSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditEmailColumnInEmployeeTBL : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Employee", "Email", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employee", "Email", c => c.String());
        }
    }
}
