using EntityLayer.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Models.Concrete
{
    public class DynamicObject : BaseEntity
    {
        public string ObjectName { get; set; }            
        public DateTime? UpdatedAt { get; set; }            
        public virtual ICollection<DynamicField>? DynamicFields { get; set; }

        public virtual ICollection<TransactionLog>? TransactionLogs { get; set; }
    }
}
