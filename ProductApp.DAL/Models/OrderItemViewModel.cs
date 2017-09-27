using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductApp.DAL
{
    public class OrderItemViewModel
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
    }
}