using System;
using System.Threading.Tasks;
using CoffeeManagerAdmin.Models;

namespace CoffeeManagerAdmin.Core
{
	public class UserServiceProvider : BaseServiceProvider
	{
	    private const string Users = "Users";
		public UserServiceProvider ()
		{
		}

	    public async Task<string> Login(string name, string password)
	    {
	       return await Post($"{Users}/login", new UserInfo() {Login = name, Password = password});
	    }
	}
}
