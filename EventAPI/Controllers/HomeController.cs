using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EventAPI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            
            return View("Index");
        }

        public IActionResult Eventelem()
        {
            return View("eventelem");
        }
        public IActionResult Events()
        {
            return View("events");
        }
        public IActionResult Participants()
        {
            return View("participants");
        }
    }
}