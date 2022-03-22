using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using kangaroo_api.shared.Configurations.Errors.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace kangaroo_api.shared.Configurations.Errors.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ErrorController : ControllerBase
    {
        [Route("/error")]
        public ActionResult<String> Error()
        {
            var exception = HttpContext.Features.Get<IExceptionHandlerFeature>();
            HttpException error = (HttpException)exception.Error;
            var statusCode = (int)error.Status;
            APIError errorObject = new APIError(statusCode, error.Message);
            return StatusCode((int)statusCode, Newtonsoft.Json.JsonConvert.SerializeObject(errorObject));
        }
    }
}