using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWeaverAdminTool.Data.Migrations
{
    internal  sealed class Configuration : DbMigrationsConfiguration<CarWeaverAdminToolAppContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(CarWeaverAdminToolAppContext context)
        {
            //Add Initial data if needed
        }


    }
}
