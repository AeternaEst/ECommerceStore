using CommerceStore.Data.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommerceStore.Data.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static void UseMockData(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                using (var storeContext = serviceScope.ServiceProvider.GetService<StoreContext>())
                {
                    storeContext.Database.EnsureCreated();

                    if (storeContext.Products.Any())
                    {
                        return;
                    }

                    var product1 = new Product
                    {
                        Name = "Macbook Pro",
                        Price = 150000,
                        Description = "For pretentious douchebags"
                    };
                    var product2 = new Product
                    {
                        Name = "Football",
                        Price = 100,
                        Description = "Leather ball"
                    };
                    var product3 = new Product
                    {
                        Name = "WGExternal Harddrive",
                        Price = 750,
                        Description = "500GB storage"
                    };

                    storeContext.Products.Add(product1);
                    storeContext.Products.Add(product2);
                    storeContext.Products.Add(product3);

                    storeContext.Carts.Add(new Cart
                    {
                        CartLines = new List<CartLine>
                        {
                            new CartLine
                            {
                                Product = product1,
                                Quantity = 1
                            },
                            new CartLine
                            {
                                Product = product2,
                                Quantity = 3
                            }
                        }
                    });

                    storeContext.Carts.Add(new Cart
                    {
                        CartLines = new List<CartLine>
                        {
                            new CartLine
                            {
                                Product = product2,
                                Quantity = 2
                            },
                        }
                    });

                    storeContext.SaveChanges();
                }
            }
        }
    }
}
