using System.Net.Http;
using MvvmCross.Core.ViewModels;

namespace CoffeeManagerAdmin.Core.ViewModels
{
	public class FirstViewModel
		: MvxViewModel
	{
		private string _hello = "Hello MvvmCross";
		public string Hello {
			get { return _hello; }
			set { SetProperty (ref _hello, value); }
		}

		public FirstViewModel ()
		{
			var client = new HttpClient ();
			var res = client.GetStringAsync ("http://coffeeroom.ddns.net:8082/api/users?coffeeroomno=1");
			Hello = res.Result;
		}
	}
}
