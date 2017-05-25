using System.Web.Http;
using NNShop.Service;
using NNShop.Web.Infrastructure.Core;

namespace NNShop.Web.Api
{
    [RoutePrefix("api/home")]
    [Authorize]
    public class HomeController : ApiControllerBase
    {
        IErrorService _errorService;
        public HomeController(IErrorService errorService): base(errorService)
        {
            this._errorService = errorService;
        }
        [HttpGet]
        [Route("TestMethod")]
        public string TestMethod()
        {
            return "Hello, NnShop Member";
        }
    }
}