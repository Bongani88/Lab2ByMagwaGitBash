using Lab2.CommonModules.Entity;
using Lab2.CommonModules.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.Services.Services
{
    public class CustomerServices : ICustomer
    {
        private readonly ICustomer _iCustomer;

        public CustomerServices(ICustomer customer)
        {
            _iCustomer = customer;

        }
        public async Task<bool> Add(Customer customer)
        {
            return await _iCustomer.Add(customer);
        }

        public async Task<List<Customer>> Get(Customer customer)
        {
           return await _iCustomer.Get(customer);
        }

        public async Task<bool> Update(Customer customer)
        {
            return await _iCustomer.Update(customer);
        }
        public async Task<bool> Delete(int customerID)
        {
            return await _iCustomer.Delete(customerID);
        }
    }
}
