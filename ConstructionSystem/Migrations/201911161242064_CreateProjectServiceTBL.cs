namespace ConstructionSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateProjectServiceTBL : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProjectService",
                c => new
                    {
                        ProjectID = c.Int(nullable: false),
                        ServiceID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProjectID, t.ServiceID })
                .ForeignKey("dbo.Project", t => t.ProjectID, cascadeDelete: true)
                .ForeignKey("dbo.Service", t => t.ServiceID, cascadeDelete: true)
                .Index(t => t.ProjectID)
                .Index(t => t.ServiceID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProjectService", "ServiceID", "dbo.Service");
            DropForeignKey("dbo.ProjectService", "ProjectID", "dbo.Project");
            DropIndex("dbo.ProjectService", new[] { "ServiceID" });
            DropIndex("dbo.ProjectService", new[] { "ProjectID" });
            DropTable("dbo.ProjectService");
        }
    }
}
