using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nlayer.Core.DTOs;
using Nlayer.Core.Models;
using Nlayer.Core.Services;
using NLayer.API.Filters;
using System.Runtime.CompilerServices;

namespace NLayer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductWithDtoController : CustomBaseController
    {
        private readonly IProductServiceWithDto _productServiceWithDto;

        public ProductWithDtoController(IProductServiceWithDto productServiceWithDto)
        {
            _productServiceWithDto = productServiceWithDto;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetProductsWithCategory()
        {
            return CreateActionResult(await _productServiceWithDto.GetPorductWithCategory());
        }


        [HttpGet]
        public async Task<IActionResult> All()
        {
            return CreateActionResult(await _productServiceWithDto.GetAllAsync());
        }

        [ServiceFilter(typeof(NotFoundFilter<Product>))]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {


            return CreateActionResult(await _productServiceWithDto.GetByIdAsnc(id));
        }

        [HttpPost]
        public async Task<IActionResult> Save(ProductCreateDto productDto)
        {
            
            return CreateActionResult(await _productServiceWithDto.AddAsync(productDto));
        }

        [HttpPut]
        public async Task<IActionResult> Update(ProductUpdateDto productDto)
        {

            return CreateActionResult(await _productServiceWithDto.UpdateAsync(productDto));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {

            return CreateActionResult(await _productServiceWithDto.RemoveAsync(id));
        }

        [HttpPost("SaveAll")]
        public async Task<IActionResult> Save(List<ProductDto> productDtos)
        {
            return CreateActionResult(await _productServiceWithDto.AddRangeAsync(productDtos));
        }

        [HttpDelete("RemoveAll")]
        public async Task<IActionResult> RemoveAll(List<int> idList)
        {
            return CreateActionResult(await _productServiceWithDto.RemoveRangeAsync(idList));
        }

        [HttpGet("Any")]
        public async Task<IActionResult> Any(int id)
        {
            return CreateActionResult(await _productServiceWithDto.AnyAsync(x => x.Id == id));
        }
    }
}
