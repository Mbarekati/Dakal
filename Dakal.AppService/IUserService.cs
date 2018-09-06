using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Dakal.AppService
{
    public interface IUserService
    {
        Task<bool> IsUserExist(string username, string appName);
    }
}
