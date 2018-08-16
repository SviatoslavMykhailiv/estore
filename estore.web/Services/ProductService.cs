using System;
using System.Threading.Tasks;
using estore.contracts.Models;
using estore.contracts.Services;

namespace estore.web.Services
{
    public class ProductService : IProductService
    {
        public Task<ProductModel> GetProductByIdAsync(long id) {
            throw new NotImplementedException();
        }
    }
}
