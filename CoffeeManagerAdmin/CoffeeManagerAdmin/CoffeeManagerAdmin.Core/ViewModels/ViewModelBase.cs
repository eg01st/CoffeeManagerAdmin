using System;
using Acr.UserDialogs;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;

namespace CoffeeManagerAdmin.Core
{
	public class ViewModelBase : MvxViewModel
	{
        protected IUserDialogs UserDialogs
        {
            get
            {
                return Mvx.Resolve<IUserDialogs>();
            }
        }
        public ViewModelBase ()
		{
		}
	}
}
