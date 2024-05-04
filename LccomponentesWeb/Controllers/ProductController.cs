using LccomponentesWeb.Models;
using LccomponentesWeb.Models.ViewModels;
using LccomponentesWeb.Services;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Plugins;

namespace LccomponentesWeb.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductService _productService;
        private readonly CategoriesService _categoriesService; 

        public ProductController(ProductService productService,CategoriesService categoriesService)
        {
            _productService = productService;
            _categoriesService = categoriesService;
        }
        public async Task<IActionResult> Index()
        {
            var list = await _productService.FindAllAsync();
            return View(list);
        }
        public async Task<IActionResult> Create()
        {
            var category = await _categoriesService.FindAllAsync();
            var viewModel = new ProductFormViewModel { Category = category };
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product)
        {
           await _productService.InsertAsync(product);
           return RedirectToAction(nameof(Index));
        }

    }
}
