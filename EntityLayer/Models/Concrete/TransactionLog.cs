using EntityLayer.Models.Abstract;
using System;

namespace EntityLayer.Models.Concrete
{
    public class TransactionLog : BaseEntity
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
