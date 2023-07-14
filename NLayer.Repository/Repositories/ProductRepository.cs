﻿using Microsoft.EntityFrameworkCore;
using Nlayer.Core.Models;
using Nlayer.Core.Repositories;

namespace NLayer.Repository.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<Product>> GetPorductWithCategory()
        {
            //Eager Loading
            return await _context.Products.Include(x => x.Category).ToListAsync();
        }
    }
}
