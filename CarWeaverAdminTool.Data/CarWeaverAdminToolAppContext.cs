using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarWeaverAdminTool.Core.Entities;

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

        public override Task<int> SaveChangesAsync()
        {
            ChangeTracker.DetectChanges();

            var auditable = ChangeTracker.Entries<IBaseEntity>().ToList();

            if (!auditable.Any()) return base.SaveChangesAsync();

            foreach (var record in auditable)
            {
                var userIdentity = "Test User"; //TODO: Whatever class you leverage to get the current username

                switch (record.State)
                {
                    case EntityState.Added:
                        if (record.Entity.Id == Guid.Empty)
                        {
                            record.Entity.Id = Guid.NewGuid();
                        }
                        record.Entity.CreatedDateTime = DateTime.Now;
                        record.Entity.CreatedBy = userIdentity;
                        break;
                    case EntityState.Modified:
                        if (string.IsNullOrEmpty(record.Entity.UpdatedBy))
                        {
                            record.Entity.UpdatedDateTime = DateTime.Now;
                            record.Entity.UpdatedBy = userIdentity;
                        }

                        record.Entity.UpdatedDateTime = DateTime.Now;
                        record.Entity.UpdatedBy = userIdentity;
                        break;
                }
            }
            return base.SaveChangesAsync();
        }
    }
}
