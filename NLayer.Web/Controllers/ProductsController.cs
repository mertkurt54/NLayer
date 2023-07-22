using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Nlayer.Core.DTOs;
using Nlayer.Core.Models;
using Nlayer.Core.Services;
using NLayer.Web.Services;

namespace NLayer.Web.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ProductApiService _ProductApiService;

        public ProductsController(ProductApiService apiService, CategoryApiService categoryApiService)
        {
            _ProductApiService = apiService;
            _categoryApiService = categoryApiService;
        }

        private readonly CategoryApiService _categoryApiService;

        public async Task<IActionResult> Index()
        {
            return View(await _ProductApiService.GetProductsWithCategoryAsync());
        }

        public async Task<IActionResult> Save()
        {
            var categoriesDto = await _categoryApiService.GetAllAsync();

            ViewBag.categories = new SelectList(categoriesDto, "Id", "Name");

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Save(ProductDto productDto)
        {


            if (ModelState.IsValid)
            {
                await _ProductApiService.SaveAsync(productDto);

                return RedirectToAction(nameof(Index));
            }
            var categoriesDto = await _categoryApiService.GetAllAsync();

            ViewBag.categories = new SelectList(categoriesDto, "Id", "Name");
            return View();
        }
        
        [ServiceFilter(typeof(NotFoundFilter<Product>))]
        public async Task<IActionResult> Update(int id)
        {
            var product = await _ProductApiService.GetByIdAsync(id);

            var categoriesDto = await _categoryApiService.GetAllAsync();

            ViewBag.categories = new SelectList(categoriesDto, "Id", "Name", product.CategoryId);
            return View(product);
        }
        [HttpPost]
        public async Task<IActionResult> Update(ProductDto productDto)
        {
            if (ModelState.IsValid)
            {
                await _ProductApiService.UpdateAsync(productDto);
                return RedirectToAction(nameof(Index));
            }

            var categoriesDto = await _categoryApiService.GetAllAsync();

            ViewBag.categories = new SelectList(categoriesDto, "Id", "Name", productDto.CategoryId);
            return View(productDto);
        }


        public async Task<IActionResult> Remove(int id)
        {
            await _ProductApiService.RemoveAsync(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
