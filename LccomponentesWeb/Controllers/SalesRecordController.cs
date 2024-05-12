using LccomponentesWeb.Models.ViewModels;
using LccomponentesWeb.Models;
using LccomponentesWeb.Services;
using Microsoft.AspNetCore.Mvc;

namespace LccomponentesWeb.Controllers
{
    public class SalesRecordController : Controller
    {
        private readonly SalesRecordService _salesRecordService;
        private readonly ProductService _productService;

        public SalesRecordController(SalesRecordService salesRecordService, ProductService productService)
        {
            _salesRecordService = salesRecordService;
            _productService = productService;
        }
        public async Task<IActionResult> Index()
        {           
           var list = await _salesRecordService.FindAllAsync();
           return View(list);
        }

        public async Task<IActionResult> Create()
        {
            var products = await _productService.FindAllAsync();
            var viewModel = new SalesRecordFormViewModel { Product = products };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SalesRecord salesRecord)
        {
            await _salesRecordService.InsertAsync(salesRecord);
            return RedirectToAction(nameof(Index));
        }
    }
}
