using Lab2.CommonModules.Entity;
using Lab2.CommonModules.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.Services.Services
{
    public class ProductServices : IProduct
    {
        private readonly IProduct _iProduct;

        public ProductServices(IProduct IProduct)
        {
            _iProduct = IProduct;
        }
        public async Task<bool> Add(Product product)
        {
            return await _iProduct.Add(product);
        }

        public async Task<bool> Delete(Product product)
        {
           return await _iProduct.Delete(product);
        }

        public async Task<bool> Get(Product product)
        {
           return await _iProduct.Get(product);
        }

        public async Task<bool> Update(Product product)
        {
            return await _iProduct.Update(product);
        }
    }
}
