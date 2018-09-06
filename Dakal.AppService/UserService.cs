using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dakal.Models;
using Dakal.Repositories;

namespace Dakal.AppService
{
    public class UserService : IUserService
    {
        private IUserRepository userRepository = null;
        public UserService(IUserRepository _userRepositroy)
        {
            userRepository = _userRepositroy;
        }

        public Task<bool> CreateUser(string username, string appName, string age, Gender gender)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> IsUserExist(string username, string appName)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(appName))
                throw new ArgumentNullException();
            var user = await userRepository.Queryable().FirstOrDefaultAsync(x => x.Username == username && x.FirmPackageName == appName);
            if (user == null)
                return false;
            return true;
        }
    }
}
