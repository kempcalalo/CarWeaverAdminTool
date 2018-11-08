using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWeaverAdminTool.Core.Entities
{
    public class BaseEntity : IBaseEntity
    {
        [Key]
        public Guid Id { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDateTime { get; set; }
    }
}
