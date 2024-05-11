using LccomponentesWeb.Services;
using Microsoft.AspNetCore.Mvc;

namespace LccomponentesWeb.Controllers
{
    public class SalesRecordController : Controller
    {
        private readonly SalesRecordService _salesRecordService;

        public SalesRecordController(SalesRecordService salesRecordService)
        {
            _salesRecordService = salesRecordService;
        }

        public async Task<IActionResult> Index()
        {           
           var list = await _salesRecordService.FindAllAsync();
           return View(list);
        }
    }
}
