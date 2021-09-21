using CommerceStore.Data.Entities;
using CommerceStore.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommerceStore.Data.Repositories
{
    public class CartRepository : ICartRepository
    {
        private readonly StoreContext _storeContext;

        public CartRepository(StoreContext storeContext)
        {
            _storeContext = storeContext;
        }

        public async Task<Cart> GetCart(int cartId)
        {
            return await _storeContext.Carts.Include(cart => cart.CartLines).ThenInclude(cartLine => cartLine.Product).FirstOrDefaultAsync(cart => cart.Id == cartId);
        }

        public async Task<Product> AddProduct(int cartId, int productId, int quantity)
        {
            var cartTask = GetCart(cartId);
            var productTask = _storeContext.Products.FindAsync(productId);

            Task.WaitAll(cartTask, productTask.AsTask());

            if (cartTask.Result == null || productTask.Result == null)
            {
                return null;
            }

            var cart = cartTask.Result;
            var product = productTask.Result;

            var cartLineWithProduct = cart.CartLines.FirstOrDefault(cartLine => cartLine.Product.Id == product.Id);

            if (cartLineWithProduct != null)
            {
                cartLineWithProduct.Quantity += quantity;
            } else
            {
                cartTask.Result.CartLines.Add(new CartLine { Product = productTask.Result, Quantity = quantity });
            }

            await _storeContext.SaveChangesAsync();

            return productTask.Result;
        }

        public async Task<Product> RemoveProduct(int cartId, int productId)
        {
            var cart = await GetCart(cartId);

            if (cart == null)
            {
                return null;
            }

            var cartLineWithProduct = cart.CartLines.FirstOrDefault(cartLine => cartLine.Product.Id == productId);

            if (cartLineWithProduct == null)
            {
                return null;
            }

            cart.CartLines.Remove(cartLineWithProduct);

            await _storeContext.SaveChangesAsync();

            return cartLineWithProduct.Product;
        }
    }
}
