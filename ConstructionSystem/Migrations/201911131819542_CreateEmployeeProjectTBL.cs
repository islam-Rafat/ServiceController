namespace ConstructionSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateEmployeeProjectTBL : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EmployeeProject",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false),
                        ProjectId = c.Int(nullable: false),
                        Hours = c.Double(nullable: false),
                    })
                .PrimaryKey(t => new { t.EmployeeId, t.ProjectId })
                .ForeignKey("dbo.Employee", t => t.EmployeeId, cascadeDelete: true)
                .ForeignKey("dbo.Project", t => t.ProjectId, cascadeDelete: true)
                .Index(t => t.EmployeeId)
                .Index(t => t.ProjectId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EmployeeProject", "ProjectId", "dbo.Project");
            DropForeignKey("dbo.EmployeeProject", "EmployeeId", "dbo.Employee");
            DropIndex("dbo.EmployeeProject", new[] { "ProjectId" });
            DropIndex("dbo.EmployeeProject", new[] { "EmployeeId" });
            DropTable("dbo.EmployeeProject");
        }
    }
}
