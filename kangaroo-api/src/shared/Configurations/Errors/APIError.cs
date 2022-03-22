using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kangaroo_api.shared.Configurations.Errors
{
    public class APIError
    {
        public DateTime timestamp = DateTime.Now;
        public int status_code = 500;
        public string message = string.Empty;

        public APIError(int status_code, string message)
        {
            this.status_code = status_code;
            this.message = message;
        }
        public APIError() { }

    }
}