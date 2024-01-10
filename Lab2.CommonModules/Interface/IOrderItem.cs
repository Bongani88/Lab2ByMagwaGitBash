using Lab2.CommonModules.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.CommonModules.Interface
{
    public interface IOrderItem
    {
        Task<bool> Add(OrderItem orderItem);
        Task<bool> Get(OrderItem orderItem);
        Task<bool> Update(OrderItem orderItem);
        Task<bool> Delete(OrderItem orderItem);
    }
}
