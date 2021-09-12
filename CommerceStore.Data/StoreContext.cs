using CommerceStore.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace CommerceStore.Data
{
    public class StoreContext : DbContext
    { 
        public StoreContext(DbContextOptions<StoreContext> options): base(options) {}
    
        public DbSet<Product> Products { get; set; }

        public DbSet<Cart> Carts { get; set; }

        public DbSet<CartLine> CartLines { get; set; }

    }
}
