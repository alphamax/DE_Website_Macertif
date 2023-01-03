﻿using Microsoft.AspNetCore.Mvc;
using WebCom.Data;
using WebCom.Services.Interfaces;

namespace WebCom.Controllers
{
    public class ProductController : Controller
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IProductService _productService;

        public ProductController(ILogger<ProductController> logger, WebComContext context,
            IProductService productService)
        {
            _productService = productService;
            _logger = logger;
        }

        public IActionResult List()
        {
            var products = _productService.GetProducts();
            return View(products);
        }
    }
}