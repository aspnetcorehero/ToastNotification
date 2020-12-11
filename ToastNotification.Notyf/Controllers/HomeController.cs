using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ToastNotification.Notyf.Models;

namespace ToastNotification.Notyf.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly INotyfService _notyf;
        public HomeController(ILogger<HomeController> logger, INotyfService notyf)
        {
            _logger = logger;
            _notyf = notyf;
        }

        public IActionResult Index()
        {
            //_notyf.Success("Success Notification");
            //_notyf.Success("Success Notification that closes in 10 Seconds.", 10);
            //_notyf.Error("Some Error Message");
            //_notyf.Warning("Some Error Message");
            //_notyf.Information("Information Notification - closes in 4 seconds.", 4);
            //_notyf.Custom("Custom Notification <br><b><i>closes in 5 seconds.</i></b></p>", 5, "indigo", "fa fa-gear");
            _notyf.Custom("Custom Notification - closes in 5 seconds.", 5, "whitesmoke", "fa fa-gear");
            _notyf.Custom("Custom Notification - closes in 10 seconds.", 10, "#B600FF", "fa fa-home");
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
