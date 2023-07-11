using Nlayer.Core.DTOs;
using Nlayer.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nlayer.Core.Services
{
    public interface ICategoryService : IService<Category>
    {
       Task<CustomResponseDto<CategoryWithProductsDto>> GetsingleCategoryWithProductsAsync(int categoryId);
    }
}
