namespace Scrum.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateIssueRemoveMyPropertyColumn : DbMigration
    {
        public override void Up()
        {
            DropColumn("Scrum.Issues", "MyProperty");
        }
        
        public override void Down()
        {
            AddColumn("Scrum.Issues", "MyProperty", c => c.String());
        }
    }
}
