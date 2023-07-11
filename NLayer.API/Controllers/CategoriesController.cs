using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Nlayer.Core.Services;

namespace NLayer.API.Controllers
{
    
    public class CategoriesController : CustomBaseController
    {
        private readonly ICategoryService __categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            __categoryService = categoryService;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetsingleCategoryWithProductsAsync(int categoryId)
        {
            return CreateActionResult(await __categoryService.GetsingleCategoryWithProductsAsync(categoryId));
        }
    }
}
