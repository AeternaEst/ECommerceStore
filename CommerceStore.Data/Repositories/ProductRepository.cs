using CommerceStore.Data.Entities;
using CommerceStore.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CommerceStore.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly StoreContext _storeContext;

        public ProductRepository(StoreContext storeContext)
        {
            _storeContext = storeContext;
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _storeContext.Products.ToListAsync();
        }

        public async Task<Product> GetProduct(int productId)
        {
            return await _storeContext.Products.FindAsync(productId);
        }
    }
}
