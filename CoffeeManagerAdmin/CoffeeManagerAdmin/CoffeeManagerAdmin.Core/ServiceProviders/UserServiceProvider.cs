using System;
using System.Threading.Tasks;
using CoffeeManager.Models;

namespace CoffeeManagerAdmin.Core.ServiceProviders
{
    public class UserServiceProvider : BaseServiceProvider
    {
        private const string Users = "Users";
        public UserServiceProvider()
        {
        }

        public async Task<string> Login(string name, string password)
        {
            return await Post($"{Users}/login", new UserInfo() { Login = name, Password = password });
        }

        public async Task AddUser(string name)
        {
            await Put(Users, new User { Name = name, CoffeeRoomNo = Config.CoffeeRoomNo });
        }
    }
}
