using CommerceStore.Data;
using CommerceStore.Data.Entities;
using CommerceStore.Data.Interfaces;
using CommerceStore.Data.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;

namespace ECommerceStore.View
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddDbContext<StoreContext>(opt => opt.UseInMemoryDatabase("ecommerce-store"));

            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICartRepository, CartRepository>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
           /* Servces files from the wwwwroot folder */
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                using (var storeContext = serviceScope.ServiceProvider.GetService<StoreContext>())
                {
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
