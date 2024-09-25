using EntityLayer.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer_BL_.Abstract
{
 
    public interface ITransactionLogService<T> : IService<T> where T : BaseEntity, new()
    {
    }

}
