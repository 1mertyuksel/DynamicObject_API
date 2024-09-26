using EntityLayer.Models.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer_BL_.DTOs
{
    public class DynamicFieldDTO
    {
        public string FieldName { get; set; }
        public string FieldValue { get; set; }
        public int DynamicObjectId { get; set; }
        public virtual DynamicObject DynamicObject { get; set; }
    }
}
