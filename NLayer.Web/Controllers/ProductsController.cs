﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Nlayer.Core.DTOs;
using Nlayer.Core.Models;
using Nlayer.Core.Services;

namespace NLayer.Web.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _services;
        private readonly ICategoryService _categoryServices;
        private readonly IMapper _mapper;

        public ProductsController(IProductService services, ICategoryService categoryServices, IMapper mapper)
        {
            _services = services;
            _categoryServices = categoryServices;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _services.GetPorductWithCategory());
        }

        public async Task<IActionResult> Save()
        {
            var categories = await _categoryServices.GetAllAsync();

            var categoriesDto = _mapper.Map<List<CategoryDto>>(categories);

            ViewBag.categories = new SelectList(categoriesDto, "Id", "Name");

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Save(ProductDto productDto)
        {


            if (ModelState.IsValid)
            {
                await _services.AddAsync(_mapper.Map<Product>(productDto));
                return RedirectToAction(nameof(Index));
            }
            var categories = await _categoryServices.GetAllAsync();

            var categoriesDto = _mapper.Map<List<CategoryDto>>(categories);

            ViewBag.categories = new SelectList(categoriesDto, "Id", "Name");
            return View();
        }
    }
}
