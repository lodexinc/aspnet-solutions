namespace Scrum.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addissuetable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Scrum.Issues",
                c => new
                    {
                        ID = c.Guid(nullable: false, identity: true),
                        IssueTypeID = c.String(),
                        ProjectID = c.String(),
                        MyProperty = c.String(),
                        Summary = c.String(),
                        ReporterID = c.String(),
                        Description = c.String(),
                        PriorityID = c.String(),
                        Attachment = c.String(),
                        AssigneeID = c.String(),
                        SprintID = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("Scrum.Issues");
        }
    }
}
