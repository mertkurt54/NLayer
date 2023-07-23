using Nlayer.Core.DTOs;
using Nlayer.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nlayer.Core.Services
{
    public interface IProductServiceWithDto:IServiceWithDto<Product, ProductDto>
    {
        Task<CustomResponseDto<List<ProductWithCategoryDto>>> GetPorductWithCategory();

        Task<CustomResponseDto<NoContentDto>> UpdateAsync(ProductUpdateDto dto);

        Task<CustomResponseDto<ProductDto>> AddAsync(ProductCreateDto dto);
    }
}
