using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductApp.API.Models
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public System.DateTime OrderDate { get; set; }
        public string OrderNumber { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public Nullable<decimal> TotalAmount { get; set; }
    }
}