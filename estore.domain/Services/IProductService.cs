using estore.domain.Models;
using System.Threading.Tasks;

namespace estore.domain.Services
{
    public interface IProductService
    {
        Task<Product> GetProductByIdAsync(long id);
    }
}
