using LccomponentesWeb.Models;
using LccomponentesWeb.Models.ViewModels;
using LccomponentesWeb.Services;
using LccomponentesWeb.Services.Exeptions;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

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
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Error", "Product", new { message = "Id não Fornecido" });
            }
            var obj = await _productService.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction("Error", "Product", new { message = "Id não Encontrado" });
            }
            return View(obj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _productService.RemoveAsync(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Error", "Product", new { message = "Id não Fornecido" });
            }
            var obj = await _productService.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction("Error", "Product", new { message = "Id não Encontrado" });
            }

            List<Category> category = await _categoriesService.FindAllAsync();
            ProductFormViewModel viewModel = new ProductFormViewModel { Product = obj, Category = category };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Product product)
        {
            if (id != product.Id)
            {
                return RedirectToAction("Error", "Product", new { message = " id não incompatível" });
            }
            try
            {
                _productService.UpdateAsync(product);
                return RedirectToAction(nameof(Index));
            }
            catch (NotFoundException)
            {
                return RedirectToAction("Error", "Product", new { message = "Id não Fornecido" });
            }
            catch (DbConcurrencyException)
            {
                return RedirectToAction("Error", "Product", new { message = "Id não Encontrado" });
            }
        }

        public async Task<IActionResult> Details(int? id)
        {

            if (id == null)
            {
                return RedirectToAction("Error", "Product", new { message = "Id não Fornecido" });
            }
            var obj = await _productService.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction("Error", "Product", new { message = "Id não Encontrado" });
            }
            return View(obj);
        }

        public IActionResult Error(string message)
        {
            var viewModel = new ErrorViewModel
            {
                Message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };
            return View(viewModel);
        }
    }
}

