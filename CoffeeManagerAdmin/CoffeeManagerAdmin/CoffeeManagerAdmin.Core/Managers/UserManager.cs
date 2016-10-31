using System;
using System.Threading.Tasks;
using CoffeeManagerAdmin.Core.ServiceProviders;

namespace CoffeeManagerAdmin.Core.Managers
{
    public class UserManager : BaseManager
    {
        UserServiceProvider provider = new UserServiceProvider();
        public UserManager()
        {
        }

        public async Task<string> Login(string name, string password)
        {
            return await provider.Login(name, password);
        }

        public async Task AddUser(string name)
        {
            await provider.AddUser(name);
        }
    }
}
