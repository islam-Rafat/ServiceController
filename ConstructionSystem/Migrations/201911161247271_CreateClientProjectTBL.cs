namespace ConstructionSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateClientProjectTBL : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ClientProject",
                c => new
                    {
                        ClientID = c.Int(nullable: false),
                        ProjectID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ClientID, t.ProjectID })
                .ForeignKey("dbo.Client", t => t.ClientID, cascadeDelete: true)
                .ForeignKey("dbo.Project", t => t.ProjectID, cascadeDelete: true)
                .Index(t => t.ClientID)
                .Index(t => t.ProjectID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ClientProject", "ProjectID", "dbo.Project");
            DropForeignKey("dbo.ClientProject", "ClientID", "dbo.Client");
            DropIndex("dbo.ClientProject", new[] { "ProjectID" });
            DropIndex("dbo.ClientProject", new[] { "ClientID" });
            DropTable("dbo.ClientProject");
        }
    }
}
