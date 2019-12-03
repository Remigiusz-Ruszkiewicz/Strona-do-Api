using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StoreApp.Services;

namespace StoreApp.Controllers
{
    public class ProductsController : Controller
    {
        public ProductsController(IProductService productService)
        {
            ProductService = productService;
        }

        public IProductService ProductService { get; }

        public async Task<IActionResult>Index()
        {
            var products = await ProductService.GetAllAsync();
            return View(products);
        }
    }
}