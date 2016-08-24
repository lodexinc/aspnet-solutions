namespace Scrum.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIssueStatusTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Scrum.IssueStatus",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("Scrum.IssueStatus");
        }
    }
}
