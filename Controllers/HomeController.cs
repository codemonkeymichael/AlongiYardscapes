using alongiYardscapes.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace alongiYardscapes.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        DirectoryInfo di = new DirectoryInfo("wwwroot/images/HomeSlideShow");
        FileInfo[] fi = di.GetFiles();
        Array.Sort(fi, (f1, f2) => f1.Name.CompareTo(f2.Name));
        var ss = new SlideShow()
        {
            Images = new List<string>()
        };

        for (int i = 0; i < fi.Length; i++)
        {
            string fileName = "";
            fileName = fi[i].ToString();
            string[] fileNameArray = new string[3];
            char[] splitter = { '.' };
            fileNameArray = fileName.Split(splitter);
            int startOfId = fileName.LastIndexOf("\\") + 1;
            string id = fileName.Substring(startOfId, 2);
            ss.Images.Add($"/images/HomeSlideShow/{id}.{fileNameArray[1]}.jpg");
        }
        return View(ss);
    }
}