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

        public async Task<User> CreateUserAndGet(string username, string appName, uint age, Gender gender, long firmId)
        {
            if (!await IsUserExist(username, appName))
            {
                var user = new User(username.ToLower(), appName.ToLower(), age, gender, firmId);
                var res = await userRepository.Insert(user);
                return res;
            }
            return null;
        }

        public async Task<bool> IsUserExist(string username, string appName)
        {
            var user = await userRepository.Queryable().
                FirstOrDefaultAsync(x => x.Username == username.ToLower() && x.FirmPackageName == appName.ToLower());
            if (user == null)
                return false;
            return true;
        }

        public async Task<User> GetUser(string username, string appName)
        {
            var user = await userRepository.Queryable().FirstOrDefaultAsync(x => x.Username == username.ToLower() && x.FirmPackageName == appName.ToLower());
            return user;
        }

        Task<bool> IUserService.CreateUser(string username, string appName, uint age, Gender gender)
        {
            throw new NotImplementedException();
        }
    }
}
