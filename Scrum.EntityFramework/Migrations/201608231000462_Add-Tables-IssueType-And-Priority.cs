namespace Scrum.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTablesIssueTypeAndPriority : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Scrum.IssueTypes",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "Scrum.Priorities",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("Scrum.Priorities");
            DropTable("Scrum.IssueTypes");
        }
    }
}
