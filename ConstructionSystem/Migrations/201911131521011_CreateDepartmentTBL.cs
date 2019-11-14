namespace ConstructionSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateDepartmentTBL : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Department",
                c => new
                    {
                        DepartmentID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        NumberOfEmps = c.Int(),
                        StartDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.DepartmentID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Department");
        }
    }
}
