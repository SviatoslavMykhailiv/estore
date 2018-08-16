using System.Threading.Tasks;
using estore.contracts.Models;

namespace estore.contracts.Services
{
    public interface IProductService
    {
        Task<ProductModel> GetProductByIdAsync(long id);
    }
}
