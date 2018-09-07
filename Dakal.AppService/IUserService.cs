using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Dakal.Models;

namespace Dakal.AppService
{
    public interface IUserService
    {
        Task<bool> IsUserExist(string username, string appName);
        Task<bool> CreateUser(string username, string appName, uint age, Gender gender);
        Task<User> CreateUserAndGet(string username, string appName, uint age, Gender gender, long firmId);
        Task<User> GetUser(string username, string appName);
    }
}
