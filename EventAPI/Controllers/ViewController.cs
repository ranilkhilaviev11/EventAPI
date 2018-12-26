using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventAPI.Controllers
{
    [Route("view")]
    public class ViewController : Controller
    {
        [HttpGet]
        public IActionResult View()
        {
            return View();
        }
    }
}
