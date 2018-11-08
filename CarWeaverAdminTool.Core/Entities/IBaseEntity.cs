using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWeaverAdminTool.Core.Entities
{
    public interface IBaseEntity
    {
        Guid Id { get; set; }
        string CreatedBy { get; set; }
        DateTime? CreatedDateTime { get; set; }
        string UpdatedBy { get; set; }
        DateTime? UpdatedDateTime { get; set; }
    }
}
