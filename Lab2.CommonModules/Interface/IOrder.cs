using Lab2.CommonModules.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.CommonModules.Interface
{
    public interface IOrder
    {
        Task<bool> Add(Order order);
        Task<bool> Get(Order order);
        Task<bool> Update(Order order);
        Task<bool> Delete(Order order);

    }
}
