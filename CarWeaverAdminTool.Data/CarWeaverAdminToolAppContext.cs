using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWeaverAdminTool.Data
{
    public class CarWeaverAdminToolAppContext : DbContext
    {
        #region Constructor
        public CarWeaverAdminToolAppContext()
            : base("name=CarWeaverAdminAppContextConnectionString")
        { }
        #endregion
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            //Add code for actual entity

            base.OnModelCreating(modelBuilder);
        }
    }
}
