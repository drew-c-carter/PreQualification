using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Andrew.Web.PreQualification.Models;

namespace Andrew.Web.PreQualification.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
			RedirectToPage("CardApplication");
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "About pre-qualification";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Get in contact!";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
