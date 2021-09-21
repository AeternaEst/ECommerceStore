using CommerceStore.Data.Interfaces;
using CommerceStore.Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceStore.View.Controllers
{
    public class HomeController : Controller
    {

        private readonly IProductRepository _productRepository;
        private readonly ICartRepository _cartRepository;

        public HomeController(IProductRepository productRepository, ICartRepository cartRepository)
        {
            _productRepository = productRepository;
            _cartRepository = cartRepository;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _productRepository.GetProducts();
            return View(products);
        }

        public async Task<IActionResult> Cart(int id)
        {
            var cart = await _cartRepository.GetCart(id);
            return View(cart);
        }

    }
}
