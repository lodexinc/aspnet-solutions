using LogiGear.Infrastructure.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using LogiGear.Infrastructure.Persistence.Identity;

namespace LogiGear.Infrastructure.Persistence
{
    public class EBoxDbContext : IdentityDbContext
        <EboxApplicationUser, 
        EboxApplicationRole, 
        int, 
        EboxApplicationUserLogin, 
        EboxApplicationUserRole, 
        EboxApplicationUserClaim>
    {
        public EBoxDbContext()
            : base("EBoxDbContext")
        {
            this.Configuration.LazyLoadingEnabled = true;
            this.Configuration.ProxyCreationEnabled = true;
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<EBoxDbContext, Migrations.Configuration>("EBoxDbContext"));
        }

        public static EBoxDbContext Create()
        {
            return new EBoxDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.HasDefaultSchema("Ebox");
            modelBuilder.Entity<EboxApplicationUserLogin>().Map(c =>
            {
                c.ToTable("UserLogin");
                c.Properties(p => new
                {
                    p.UserId,
                    p.ProviderKey,
                    p.LoginProvider
                });
            }).HasKey(p => new { p.UserId, p.ProviderKey, p.LoginProvider });

            modelBuilder.Entity<EboxApplicationRole>().Map(c =>
            {
                c.ToTable("Role");
                c.Property(p => p.Id).HasColumnName("RoleId");
                c.Properties(p => new
                {
                    p.Name
                });
            })
            .HasKey(p => p.Id);
            modelBuilder.Entity<EboxApplicationRole>()
                .HasMany(p => p.Users)
                .WithRequired()
                .HasForeignKey(p => p.RoleId);

            modelBuilder.Entity<EboxApplicationUser>().Map(c =>
            {
                c.ToTable("User");
                c.Property(p => p.Id).HasColumnName("UserId");
                c.Properties(p => new
                {
                    p.UserName,
                    p.Email,
                    p.EmailConfirmed,
                    p.PasswordHash,
                    p.LockoutEnabled,
                    p.LockoutEndDateUtc,
                    p.PhoneNumber,
                    p.PhoneNumberConfirmed,
                    p.SecurityStamp,
                    p.TwoFactorEnabled,                 
                    p.AccessFailedCount
                });
            }).HasKey(p => p.Id);

            modelBuilder.Entity<EboxApplicationUser>().HasMany(c => c.Logins).WithOptional().HasForeignKey(c => c.UserId);
            modelBuilder.Entity<EboxApplicationUser>().HasMany(c => c.Claims).WithOptional().HasForeignKey(c => c.UserId);
            modelBuilder.Entity<EboxApplicationUser>().HasMany(c => c.Roles).WithRequired().HasForeignKey(c => c.UserId);

            modelBuilder.Entity<EboxApplicationUserClaim>().Map(c =>
            {
                c.ToTable("UserClaim");
                c.Property(p => p.Id).HasColumnName("UserClaimId");
                c.Properties(p => new
                {
                    p.UserId,
                    p.ClaimValue,
                    p.ClaimType
                });
            }).HasKey(c => c.Id);

            modelBuilder.Entity<EboxApplicationUserRole>().Map(c => 
            {
                c.ToTable("UserRole");
                c.Properties(p => new
                {
                    p.UserId,
                    p.RoleId
                });
            })
            .HasKey(c => new { c.UserId, c.RoleId });
        }
    }
}
