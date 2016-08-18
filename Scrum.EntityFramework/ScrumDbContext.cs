using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scrum.EntityFramework
{
    public class ScrumDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public ScrumDbContext() : base("ScrumDbContext")
        {
                
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Scrum");
            base.OnModelCreating(modelBuilder);
        }
    }
}
