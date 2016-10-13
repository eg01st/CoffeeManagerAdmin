using System;
namespace CoffeeManagerAdmin.Core
{
	public class MainViewModel : ViewModelBase
	{
	    private string _accessToken;
		public MainViewModel ()
		{
		}

	    public void Init(string accessToken)
	    {
	        _accessToken = accessToken;
	    }
	}
}
