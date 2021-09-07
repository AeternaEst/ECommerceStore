using CommerceStore.Data.Entities;
using CommerceStore.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommerceStore.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public IEnumerable<Product> GetProducts()
        {
            return new List<Product>
            {
                new Product
                {
                    Id = 1,
                    Name = "Macbook Pro",
                    Description = "For pretentious douchebags"
                },
                new Product
                {
                    Id = 2,
                    Name = "Football",
                    Description = "Leather ball"
                },
                new Product
                {
                    Id = 3,
                    Name = "WGExternal Harddrive",
                    Description = "500GB storage"
                }
            };
        }
    }
}
