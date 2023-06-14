using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NoCookBooks.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace NoCookBooks.Controllers
{
    public class HomeController : Controller
    {
       
        
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Admin()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();

        }

        public IActionResult User()
        {
            return View();

        }

        public IActionResult Login()
        {
            return View();

        }



    }

}
