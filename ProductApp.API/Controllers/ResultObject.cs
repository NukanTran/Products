using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace ProductApp.API.Controllers
{
    public class ResultObject
    {
        public bool success { get; set; }
        public string message { get; set; }
        public int total { get; set; }
        public object element { get; set; }

        public ResultObject(bool success, object element, string message = "", int total = 1)
        {
            this.success = success;
            this.message = message;
            this.total = total;
            this.element = element;
        }

        public ResultObject(bool success, object element, int total, string message = "")
        {
            this.success = success;
            this.message = message;
            this.total = total;
            this.element = element;
        }
        
    }
}