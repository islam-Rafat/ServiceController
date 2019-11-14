namespace ConstructionSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateDepartmentEmployeesTBLS : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employee", "DepartmentID", c => c.Int());
            CreateIndex("dbo.Employee", "DepartmentID");
            AddForeignKey("dbo.Employee", "DepartmentID", "dbo.Department", "DepartmentID");
            DropColumn("dbo.Department", "StartDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Department", "StartDate", c => c.DateTime());
            DropForeignKey("dbo.Employee", "DepartmentID", "dbo.Department");
            DropIndex("dbo.Employee", new[] { "DepartmentID" });
            DropColumn("dbo.Employee", "DepartmentID");
        }
    }
}
