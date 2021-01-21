using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using Newtonsoft.Json;

using PensionsCalculator.DTOs;
using PensionsCalculator.Models;
using PensionsCalculator.Services;

using System.Diagnostics;

namespace PensionsCalculator.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly PensionCalculator _pensionCalculator;

        public HomeController(ILogger<HomeController> logger, PensionCalculator pensionCalculator)
        {
            _logger = logger;
            _pensionCalculator = pensionCalculator;
        }

        public IActionResult Index()
        {
            return View(nameof(PaymentInfo));
        }

        [HttpGet]
        public IActionResult PaymentInfo()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Pension(EmployeePaymentViewModel employeePayment)
        {
            decimal? pension = _pensionCalculator.CalculatePension(employeePayment.Deceased, employeePayment.LastFiveYearAverage ?? 0, employeePayment.MonthsWorked ?? 0);
            PensionViewModel pensionViewModel = new PensionViewModel(employeePayment);
            if (pensionViewModel != null)
            {
                pensionViewModel.Pension = pension ?? 0;
            }
            return View(pensionViewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
