using EntityLayer.Models.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer_BL_.DTOs
{
    public class TransactionLogDTO
    {
        public string OperationType { get; set; }         
        public string ObjectType { get; set; }            
        public string? Description { get; set; }          

        public int? DynamicObjectId { get; set; }         
        public virtual DynamicObject? DynamicObject { get; set; }

        public int? DynamicFieldId { get; set; }         

        public virtual DynamicField? DynamicField { get; set; }
    }
}
