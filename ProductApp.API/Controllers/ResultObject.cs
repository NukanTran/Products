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
        public object elements { get; set; }

        public ResultObject(bool success, object elements, string message = "", int total = 1)
        {
            this.success = success;
            this.message = message;
            this.total = total;
            this.elements = elements;
        }

        public ResultObject(bool success, object elements, int total, string message = "")
        {
            this.success = success;
            this.message = message;
            this.total = total;
            this.elements = elements;
        }
        
    }
}