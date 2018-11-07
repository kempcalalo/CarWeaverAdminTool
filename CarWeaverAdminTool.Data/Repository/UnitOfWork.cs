using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarWeaverAdminTool.Data.Interfaces;

namespace CarWeaverAdminTool.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private bool _disposed = false;
        private CarWeaverAdminToolAppContext _context;

        public CarWeaverAdminToolAppContext DbContext => _context ?? (_context = new CarWeaverAdminToolAppContext());

        protected void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    DbContext.Dispose();
                }
            }
            this._disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
