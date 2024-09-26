using AutoMapper;
using BusinessLayer_BL_.DTOs;
using EntityLayer.Models.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BusinessLayer_BL_.MapperConfig
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<DynamicObject, DynamicObjectDTO>().ReverseMap();
            CreateMap<DynamicField, DynamicFieldDTO>().ReverseMap();
            CreateMap<TransactionLog, TransactionLogDTO>().ReverseMap();
        }
    }
}
