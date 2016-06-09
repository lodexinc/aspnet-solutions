using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations.History;
using System.Linq;
using System.Web;

namespace Me.Api.v1.Persistence
{
    [DbConfigurationType(typeof(MySqlConfiguration))]
    public class AuthDbContextMySql : IdentityDbContext<IdentityUser>
    {
        public AuthDbContextMySql() : base("MeApiV1Context")
        {

        }

        static AuthDbContextMySql()
        {
            Database.SetInitializer(new MySqlInitializer());
        }
    }

    public class MySqlInitializer : IDatabaseInitializer<AuthDbContextMySql>
    {
        public void InitializeDatabase(AuthDbContextMySql context)
        {
            if (!context.Database.Exists())
            {
                // if database did not exist before - create it
                context.Database.Create();
            }
            else
            {
                // query to check if MigrationHistory table is present in the database 
                var migrationHistoryTableExists = ((IObjectContextAdapter)context).ObjectContext.ExecuteStoreQuery<int>(
                string.Format(
                  "SELECT COUNT(*) FROM information_schema.tables WHERE table_schema = '{0}' AND table_name = '__MigrationHistory'", "Me.Api.V1.Database"));

                // if MigrationHistory table is not there (which is the case first time we run) - create it
                if (migrationHistoryTableExists.FirstOrDefault() == 0)
                {
                    context.Database.Delete();
                    context.Database.Create();
                }
            }
        }
    }
}