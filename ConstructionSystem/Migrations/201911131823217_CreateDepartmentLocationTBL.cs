namespace ConstructionSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateDepartmentLocationTBL : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DepartmentLocation",
                c => new
                    {
                        DepartmentID = c.Int(nullable: false),
                        Location = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.DepartmentID, t.Location })
                .ForeignKey("dbo.Department", t => t.DepartmentID, cascadeDelete: true)
                .Index(t => t.DepartmentID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DepartmentLocation", "DepartmentID", "dbo.Department");
            DropIndex("dbo.DepartmentLocation", new[] { "DepartmentID" });
            DropTable("dbo.DepartmentLocation");
        }
    }
}
