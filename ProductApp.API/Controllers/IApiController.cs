
using System.Web.Http;

namespace ProductApp.API.Controllers
{
    public interface IApiController<T> where T : class
    {
        ResultObject Get(int id);

        ResultObject GetAll();
        ResultObject GetListPaging(int page, int size);

        ResultObject Insert([FromBody]T req);

        ResultObject Update([FromBody]T req);

        ResultObject Delete(int id);
    }
}
