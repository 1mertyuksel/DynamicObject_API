using EntityLayer.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EntityLayer.Models.Concrete
{
    public class DynamicField : BaseEntity
    {
            
        public string FieldName { get; set; }             
        public string FieldValue { get; set; }            

        public int? DynamicObjectId { get; set; }     
        public virtual DynamicObject DynamicObject { get; set; }
    }
}
