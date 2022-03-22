using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace kangaroo_api.shared.Configurations.Errors.Exceptions
{
    public class HttpException : Exception
    {
        public HttpStatusCode Status { get; set; }

        public HttpException(HttpStatusCode status, string msg) : base(msg)
        {
            Status = status;
        }
    }
}