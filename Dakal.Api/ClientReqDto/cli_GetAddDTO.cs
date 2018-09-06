using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dakal.Models;

namespace Dakal.Api.ClientReqDto
{
    public class cli_GetAdDTO
    {
        public string username { get; set; }
        public string appPackageName { get; set; }
        public uint age
        {
            get
            {
                return age;
            }
            set
            {
                if (value > 130)
                    throw new ArgumentException("The age can not be greater than 130");
                age = value;
            }
        }
        public Gender gender { get; set; }
    }
}