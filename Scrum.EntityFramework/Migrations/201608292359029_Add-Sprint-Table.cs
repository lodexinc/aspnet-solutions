namespace Scrum.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSprintTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Scrum.Sprints",
                c => new
                    {
                        ID = c.Guid(nullable: false, identity: true),
                        ProjectID = c.Guid(nullable: false),
                        Name = c.String(),
                        Goal = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("Scrum.Sprints");
        }
    }
}
