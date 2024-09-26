using DataAccesLayer_DAL_.Abstract;
using DataAccesLayer_DAL_.Concrete;
using EntityLayer.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer_BL_.Abstract
{
    public interface IService<T> : IRepository<T> where T : BaseEntity, new()
    {
    }
}
