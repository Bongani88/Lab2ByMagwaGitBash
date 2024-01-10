using Lab2.CommonModules.Entity;
using Lab2.CommonModules.Interface;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.Infrastructure.Repoistory
{
    public class OrderItemRepo : IOrderItem
    {
        public async Task<bool> Add(OrderItem orderItem)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(OrderItem orderItem)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Get(OrderItem orderItem)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(OrderItem orderItem)
        {
            throw new NotImplementedException();
        }
    }
}
