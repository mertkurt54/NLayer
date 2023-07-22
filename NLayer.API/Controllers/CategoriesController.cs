using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Nlayer.Core.DTOs;
using Nlayer.Core.Services;
using NLayer.API.Filters;

namespace NLayer.API.Controllers
{
    public class CategoriesController : CustomBaseController
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        public CategoriesController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() 
        {
            var categories = await _categoryService.GetAllAsync();

            var categoriesDto = _mapper.Map<List<CategoryDto>>(categories.ToList());

            return CreateActionResult(CustomResponseDto<List<CategoryDto>>.Success(200, categoriesDto));

        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetsingleCategoryWithProductsAsync(int categoryId)
        {
            return CreateActionResult(await _categoryService.GetsingleCategoryWithProductsAsync(categoryId));
        }
    }
}
