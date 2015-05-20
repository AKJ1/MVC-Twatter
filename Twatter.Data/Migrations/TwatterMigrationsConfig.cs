using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace Twatter.Data.Migrations
{
    public class TwatterMigrationsConfig : DbMigrationsConfiguration<TwatterDbContext>
    {
        public TwatterMigrationsConfig()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = false;
        }
    }
}