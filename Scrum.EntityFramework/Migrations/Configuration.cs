namespace Scrum.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Scrum.EntityFramework.ScrumDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "Scrum.EntityFramework.ScrumDbContext";
        }

        protected override void Seed(Scrum.EntityFramework.ScrumDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            context.IssueTypes.AddOrUpdate(
              p => p.Name,
              new IssueType { ID = Guid.NewGuid().ToString(), Name = "Story" },
              new IssueType { ID = Guid.NewGuid().ToString(), Name = "Task" },
              new IssueType { ID = Guid.NewGuid().ToString(), Name = "Bug" }
            );

            context.Priorities.AddOrUpdate(
                p => p.Name,
                new Priority { ID = Guid.NewGuid().ToString(), Name = "Low" },
                new Priority { ID = Guid.NewGuid().ToString(), Name = "Medium" },
                new Priority { ID = Guid.NewGuid().ToString(), Name = "High" },
                new Priority { ID = Guid.NewGuid().ToString(), Name = "Highest" }
                );
            context.IssueStatuses.AddOrUpdate(
                p => p.Name,
                new IssueStatus { ID = Guid.NewGuid().ToString(), Name = "Todo" },
                new IssueStatus { ID = Guid.NewGuid().ToString(), Name = "In Coding" },
                new IssueStatus { ID = Guid.NewGuid().ToString(), Name = "In Review" },
                new IssueStatus { ID = Guid.NewGuid().ToString(), Name = "In QA/UAT" },
                new IssueStatus { ID = Guid.NewGuid().ToString(), Name = "Done" }
            );
        }
    }
}
