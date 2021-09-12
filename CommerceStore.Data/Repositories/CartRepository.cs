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

        public Cart GetCart(int cartId)
        {
            return _storeContext.Carts.Include(cart => cart.CartLines).ThenInclude(cartLine => cartLine.Product).FirstOrDefault(cart => cart.Id == cartId);
        }
    }
}
