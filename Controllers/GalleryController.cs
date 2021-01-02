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
                //FileInfo[] images = folder.GetFiles();
                //foreach (var image in images) {

                //    var name = image.ToString();
                //    if(name.ToLower() == "thumb.jpg")
                //    {
                //        gi.Thumb = image.DirectoryName;
                //    }
                //}
                int startOfFolderNumber = folder.FullName.LastIndexOf("\\") + 1;
                string folderNumber = folder.FullName.Substring(startOfFolderNumber, 2);
                gi.Thumb = $"/images/Gallery/{folderNumber}/thumb.jpg";
                gi.Image = $"/images/Gallery/{folderNumber}/image.jpg";
                gis.Images.Add(gi);
            }
         
            //Array.Sort(fi, (f1, f2) => f1.Name.CompareTo(f2.Name));
            //var ss = new SlideShow()
            //{
            //    Images = new List<string>()
            //};

            //for (int i = 0; i < fi.Length; i++)
            //{
            //    string fileName = "";
            //    fileName = fi[i].ToString();
            //    string[] fileNameArray = new string[3];
            //    char[] splitter = { '.' };
            //    fileNameArray = fileName.Split(splitter);
            //    int startOfId = fileName.LastIndexOf("\\") + 1;
            //    string id = fileName.Substring(startOfId, 2);
            //    ss.Images.Add($"/images/HomeSlideShow/{id}.{fileNameArray[1]}.jpg");
            //}

            return View(gis);
        } 
    }
}
