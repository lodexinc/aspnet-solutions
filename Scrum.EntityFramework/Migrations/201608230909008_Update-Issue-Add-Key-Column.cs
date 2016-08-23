namespace Scrum.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateIssueAddKeyColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("Scrum.Issues", "Key", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("Scrum.Issues", "Key");
        }
    }
}
