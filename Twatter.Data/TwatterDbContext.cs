using System.Configuration;
using Microsoft.AspNet.Identity.EntityFramework;
using Twatter.Data.Migrations;
using Twatter.Models;

namespace Twatter.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;
        // Your context has been configured to use a 'TwatterModel' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'Twatter.Data.TwatterModel' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'TwatterModel' 
        // connection string in the application configuration file.

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }

    public class TwatterDbContext : IdentityDbContext<User>
    {
        public TwatterDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<TwatterDbContext,TwatterMigrationsConfig>());
        }
        
        public static TwatterDbContext Create()
        {
            return new TwatterDbContext();
        }
        public IDbSet<Trend> Trends { get; set; }
        public IDbSet<Twatt> Twatts { get; set; }
    }

}