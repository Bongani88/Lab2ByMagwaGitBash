using Lab2.CommonModules.Entity;
using Lab2.CommonModules.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.Services.Services
{
    public class OrderServices : IOrder
    {
        private readonly IOrder _iOrderServices;

        public OrderServices(IOrder _IOrderServices)
        {
            _iOrderServices = _IOrderServices;
        }
        public async Task<bool> Add(Order order)
        {
           return await _iOrderServices.Add(order);
        }

        public async Task<bool> Delete(Order order)
        {
            return await _iOrderServices.Delete(order);
        }

        public async Task<bool> Get(Order order)
        {
            return await _iOrderServices.Get(order);
        }

        public async Task<bool> Update(Order order)
        {
            return await _iOrderServices.Update(order);
        }
    }
}
