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
        public List<DynamicFieldDTO> DynamicFields { get; set; }
    }
}
