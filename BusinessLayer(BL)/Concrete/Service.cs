using BusinessLayer_BL_.Abstract;
using DataAccesLayer_DAL_.Abstract;
using EntityLayer.Models.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer_BL_.Concrete
{
    public class Service<T> : Repository<T>, IService<T>
         where T : BaseEntity, new()
    {
        public Service(DbContext context) : base(context)
        {

        }
    }
}
