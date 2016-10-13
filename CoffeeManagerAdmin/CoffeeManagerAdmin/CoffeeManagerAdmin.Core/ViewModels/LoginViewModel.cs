using System;
using System.Net.Http;
using System.Diagnostics.Contracts;
using System.Runtime.InteropServices;
using System.Windows.Input;
using Acr.UserDialogs;
using CoffeeManagerAdmin.Models;
using MvvmCross.Core.ViewModels;

namespace CoffeeManagerAdmin.Core
{
	public class LoginViewModel : ViewModelBase
	{
	    private string _name;
	    private string _password;
	    private ICommand _loginCommand;
	    public string Name
        {
	        get { return _name; }
	        set
	        {
	            _name = value;
	            RaisePropertyChanged(nameof(Name));
	        }
        }
        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                RaisePropertyChanged(nameof(Password));
            }
        }
        public LoginViewModel ()
        {
            _loginCommand = new MvxCommand(DoLogin);

            var userinfo = LocalStorage.GetUserInfo();
            Name = userinfo.Login;
            Password = userinfo.Password;
        }

	    private async void DoLogin()
	    {
	        try
	        {
                var accessToken = await UserManager.Login(Name, Password);
                LocalStorage.SetUserInfo(new UserInfo() {Login = Name, Password = Password});
	            ShowViewModel<MainViewModel>(new { accessToken = accessToken });
	        }
	        catch (Exception ex)
	        {
	            UserDialogs.Alert(ex.ToString()); 
	        }       
	    }
	}
}
