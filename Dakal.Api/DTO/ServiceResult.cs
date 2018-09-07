using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dakal.Api.ClientResDto
{
    public class ServiceResult
    {
        public Object Result { get; set; }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}