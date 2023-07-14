using Nlayer.Core.Models;

namespace Nlayer.Core.Repositories
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        Task<Category> GetsingleCategoryWithProductsAsync(int categoryId);
    }
}
