using alongiYardscapes.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace alongiYardscapes.Controllers
{
    public class GalleryController : Controller
    {
        private readonly ILogger<AboutController> _logger;

        public GalleryController(ILogger<AboutController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var gis = new GalleryImages() { 
                Images = new List<GalleryImage>()
            };
            DirectoryInfo di = new DirectoryInfo("wwwroot/images/Gallery");
            var folders = di.GetDirectories();
            foreach(var folder in folders)
            {
                var gi = new GalleryImage(); 
                int startOfFolderNumber = folder.FullName.LastIndexOf("\\") + 1;
                string folderNumber = folder.FullName.Substring(startOfFolderNumber, 2);
                var files = folder.GetFiles();
                var img = System.Drawing.Image.FromFile(files[0].FullName);
                gi.Portrait = false;
                if (img.Height > img.Width) gi.Portrait = true;
                int fCount = folder.GetFiles().Length;
                gi.Id = folderNumber;
                gi.Thumb = $"/images/Gallery/{folderNumber}/thumb.jpg";
                if (fCount == 2)
                {
                    gi.BeforeAndAfter = false;
                    gi.Image = $"/images/Gallery/{folderNumber}/image.jpg";
                }
                else
                {
                    gi.BeforeAndAfter = true;
                    gi.Image = $"/images/Gallery/{folderNumber}/before.jpg";
                    gi.ImageAfter = $"/images/Gallery/{folderNumber}/after.jpg";
                }           
                gis.Images.Add(gi);
            }    

            return View(gis);
        } 
    }
}
