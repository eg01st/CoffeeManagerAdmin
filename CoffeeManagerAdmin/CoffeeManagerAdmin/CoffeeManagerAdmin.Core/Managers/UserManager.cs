using System;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;

namespace CoffeeManagerAdmin.Core
{
	public class UserManager : BaseManager
	{
        UserServiceProvider provider = new UserServiceProvider();
		public UserManager ()
		{
		}

	    public async Task<string> Login(string name, string password)
	    {
	        return await provider.Login(name, password);
	    }
	}
}
