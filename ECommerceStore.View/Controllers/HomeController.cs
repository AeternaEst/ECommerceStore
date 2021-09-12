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

        public IActionResult Index()
        {
            return View(_productRepository.GetProducts());
        }

        public IActionResult Cart(int id)
        {
            return View(_cartRepository.GetCart(id));
        }

    }
}
