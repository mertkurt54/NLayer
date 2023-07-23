using AutoMapper;
using Microsoft.AspNetCore.Http;
using Nlayer.Core.DTOs;
using Nlayer.Core.Models;
using Nlayer.Core.Repositories;
using Nlayer.Core.Services;
using Nlayer.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Service.Services
{
    public class ProductServiceWithDto : ServiceWithDto<Product, ProductDto>, IProductServiceWithDto
    {
        private readonly IProductRepository _productRepository;

        public ProductServiceWithDto(IGenericRepository<Product> repository, IUnitOfWork unitOfWork, IMapper mapper, IProductRepository productRepository) : base(repository, unitOfWork, mapper)
        {
            _productRepository = productRepository;
        }

        public async Task<CustomResponseDto<ProductDto>> AddAsync(ProductCreateDto dto)
        {
            var newEntity = _mapper.Map<Product>(dto);

            await _productRepository.AddAsync(newEntity);
            await _unitOfWork.CommitAsync();

            var newDto = _mapper.Map<ProductDto>(newEntity);

            return CustomResponseDto<ProductDto>.Success(StatusCodes.Status200OK, newDto);
        }

        public async Task<CustomResponseDto<List<ProductWithCategoryDto>>> GetPorductWithCategory()
        {
            var product = await _productRepository.GetPorductWithCategory();

            var productsDto = _mapper.Map<List<ProductWithCategoryDto>>(product);
            return CustomResponseDto<List<ProductWithCategoryDto>>.Success(200, productsDto);
        }

        public async Task<CustomResponseDto<NoContentDto>> UpdateAsync(ProductUpdateDto dto)
        {
            var entity = _mapper.Map<Product>(dto);
            _productRepository.Update(entity);
            await _unitOfWork.CommitAsync();

            return CustomResponseDto<NoContentDto>.Success(StatusCodes.Status204NoContent);
        }
    }
}
