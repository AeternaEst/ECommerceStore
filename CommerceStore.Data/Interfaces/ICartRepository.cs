using CommerceStore.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommerceStore.Data.Interfaces
{
    public interface ICartRepository
    {
        Task<Cart> GetCart(int cartId);

        Task<Product> AddProduct(int cartId, int productId, int quantity);

        Task<Product> RemoveProduct(int cartId, int productId);
    }
}
