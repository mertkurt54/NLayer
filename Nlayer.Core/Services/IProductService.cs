using Nlayer.Core.DTOs;
using Nlayer.Core.Models;

namespace Nlayer.Core.Services
{
    public interface IProductService : IService<Product>
    {
        Task<List<ProductWithCategoryDto>> GetPorductWithCategory();
    }
}
