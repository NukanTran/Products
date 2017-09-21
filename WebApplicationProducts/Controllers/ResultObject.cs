using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationProducts.Controllers
{
    public class ResultObject
    {
        public bool success { get; set; }
        public string message { get; set; }
        public object element { get; set; }

        public ResultObject(bool success, object element, string message = "")
        {
            this.success = success;
            this.element = element;
            this.message = message;
        }
    }
}