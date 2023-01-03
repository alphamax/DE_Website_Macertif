using Microsoft.AspNetCore.Mvc;
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
            var isAuthenticated = HttpContext.Session.GetString("IsAuthenticated");
            if (isAuthenticated != null)
            {
                ViewData["IsAuthenticated"] = true;
                var products = _productService.GetProducts();
                return View(products);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

        }
    }
}