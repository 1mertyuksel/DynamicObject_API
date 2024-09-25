﻿using BusinessLayer_BL_.Abstract;
using DataAccesLayer_DAL_.DbContexts;
using EntityLayer.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer_BL_.Concrete
{
    public class DynamicFieldService<T> : Service<T>, IDynamicObjectService<T>
   where T : BaseEntity, new()
    {
        public DynamicFieldService(AppDbContext context) : base(context)
        {
        }
    }
}
