using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWeaverAdminTool.Data.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        CarWeaverAdminToolAppContext DbContext { get; }
    }
}
