namespace Scrum.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Scrum.Users",
                c => new
                    {
                        ID = c.Guid(nullable: false, identity: true),
                        Email = c.String(),
                        PasswordHash = c.String(),
                        FirsName = c.String(),
                        LastName = c.String(),
                        DateOfBirth = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID);            
        }
        
        public override void Down()
        {
            DropTable("Scrum.Users");
        }
    }
}
