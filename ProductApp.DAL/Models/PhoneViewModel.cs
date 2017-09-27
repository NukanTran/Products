using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductApp.DAL
{
    public class PhoneViewModel : ProductViewModel
    {
        public string Size { get; set; }
        public string Color { get; set; }
        public string Weight { get; set; }
        public string Chipset { get; set; }
        public string Ram { get; set; }
        public string Storage { get; set; }
    }
}