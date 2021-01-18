using alongiYardscapes.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace alongiYardscapes.Controllers
{
    public class ContactController : Controller
    {
        private readonly ILogger<AboutController> _logger;

        public ContactController(ILogger<AboutController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {           
            return View();
        } 
    }
}
