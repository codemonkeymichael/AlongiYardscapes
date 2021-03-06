using System;
using System.Collections.Generic;

namespace alongiYardscapes.Models
{
    public class GalleryImage
    {
        public string Id { get; set; }
        public string Image { get; set; }
        public string ImageAfter { get; set; }
        public bool BeforeAndAfter { get; set; }
        public bool Portrait { get; set; }        
        public string Thumb { get; set; }
    }

    public class GalleryImages
    {
        public List<GalleryImage> Images { get; set; }  
    }
}
