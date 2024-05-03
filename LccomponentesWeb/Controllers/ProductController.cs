using LccomponentesWeb.Services;
using Microsoft.AspNetCore.Mvc;

namespace LccomponentesWeb.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductService _productService;

        public ProductController(ProductService productService)
        {
            _productService = productService;
        }
        public async Task<IActionResult> Index()
        {
            var list = await _productService.FindAllAsync();
            return View(list);
        }
    }
}
