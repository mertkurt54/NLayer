using Nlayer.Core.DTOs;
using Nlayer.Core.Models;

namespace Nlayer.Core.Services
{
    public interface ICategoryService : IService<Category>
    {
        Task<CustomResponseDto<CategoryWithProductsDto>> GetsingleCategoryWithProductsAsync(int categoryId);
    }
}
