namespace LogiGear.Infrastructure.Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAspNetIdentityTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Ebox.Role",
                c => new
                    {
                        RoleId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.RoleId);
            
            CreateTable(
                "Ebox.UserRole",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("Ebox.Role", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("Ebox.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "Ebox.User",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "Ebox.UserClaim",
                c => new
                    {
                        UserClaimId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.UserClaimId)
                .ForeignKey("Ebox.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "Ebox.UserLogin",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.ProviderKey, t.LoginProvider })
                .ForeignKey("Ebox.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("Ebox.UserRole", "UserId", "Ebox.User");
            DropForeignKey("Ebox.UserLogin", "UserId", "Ebox.User");
            DropForeignKey("Ebox.UserClaim", "UserId", "Ebox.User");
            DropForeignKey("Ebox.UserRole", "RoleId", "Ebox.Role");
            DropIndex("Ebox.UserLogin", new[] { "UserId" });
            DropIndex("Ebox.UserClaim", new[] { "UserId" });
            DropIndex("Ebox.UserRole", new[] { "RoleId" });
            DropIndex("Ebox.UserRole", new[] { "UserId" });
            DropTable("Ebox.UserLogin");
            DropTable("Ebox.UserClaim");
            DropTable("Ebox.User");
            DropTable("Ebox.UserRole");
            DropTable("Ebox.Role");
        }
    }
}
