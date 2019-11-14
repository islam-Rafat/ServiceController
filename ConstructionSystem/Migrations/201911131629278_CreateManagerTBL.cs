namespace ConstructionSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateManagerTBL : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DepartmentManager",
                c => new
                    {
                        ManagerID = c.Int(nullable: false, identity: true),
                        DepartmentID = c.Int(nullable: false),
                        EmployeeId = c.Int(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ManagerID)
                .ForeignKey("dbo.Department", t => t.DepartmentID, cascadeDelete: true)
                .ForeignKey("dbo.Employee", t => t.EmployeeId, cascadeDelete: true)
                .Index(t => t.DepartmentID)
                .Index(t => t.EmployeeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DepartmentManager", "EmployeeId", "dbo.Employee");
            DropForeignKey("dbo.DepartmentManager", "DepartmentID", "dbo.Department");
            DropIndex("dbo.DepartmentManager", new[] { "EmployeeId" });
            DropIndex("dbo.DepartmentManager", new[] { "DepartmentID" });
            DropTable("dbo.DepartmentManager");
        }
    }
}
