using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Services;
using System;
using System.Threading.Tasks;

namespace SalesWebMvc.Controllers
{
    public class SalesRecordsController : Controller
    {
        private readonly SalesRecordService _salesRecordService;

        public SalesRecordsController(SalesRecordService salesRecordService)
        {
            _salesRecordService = salesRecordService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> SimpleSearch(DateTime? minDate, DateTime? maxDate)
        {
            ViewData["minDate"] = null;
            ViewData["maxDate"] = null;

            if (minDate.HasValue)
            {
                ViewData["minDate"] = minDate.Value.ToString("yyyy-MM-dd");
            }
            if (maxDate.HasValue)
            {
                ViewData["maxDate"] = maxDate.Value.ToString("yyyy-MM-dd");
            }

            var salesRecords = await _salesRecordService.FindByDateAsync(minDate, maxDate);
            return View(salesRecords);
        }

        public async Task<IActionResult> GroupingSearch(DateTime? minDate, DateTime? maxDate)
        {
            ViewData["minDate"] = null;
            ViewData["maxDate"] = null;

            if (minDate.HasValue)
            {
                ViewData["minDate"] = minDate.Value.ToString("yyyy-MM-dd");
            }
            if (maxDate.HasValue)
            {
                ViewData["maxDate"] = maxDate.Value.ToString("yyyy-MM-dd");
            }

            var salesRecords = await _salesRecordService.FindByDateGroupingAsync(minDate, maxDate);
            return View(salesRecords);
        }
    }
}