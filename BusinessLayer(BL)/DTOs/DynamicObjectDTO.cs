using EntityLayer.Models.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer_BL_.DTOs
{
    public class DynamicObjectDTO
    {
        public string ObjectName { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public virtual ICollection<DynamicField> DynamicFields { get; set; }

        public virtual ICollection<TransactionLog> TransactionLogs { get; set; }
    }
}
