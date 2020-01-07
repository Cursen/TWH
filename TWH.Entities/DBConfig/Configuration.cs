using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Entity.Migrations;

namespace TWH.Entities.DBConfig
{
    public class Configuration : DbMigrationsConfiguration<DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }
    }
}
