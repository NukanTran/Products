using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductApp.API.Models
{
    public class ClotheViewModel : ProductViewModel
    {
        public string Size { get; set; }
        public string Color { get; set; }
        public string Material { get; set; }
    }
}