using System;
using System.Windows.Input;
using MvvmCross.Core.ViewModels;
using CoffeeManagerAdmin.Core.Managers;
namespace CoffeeManagerAdmin.Core
{
    public class UsersViewModel : ViewModelBase
    {
        UserManager manager = new UserManager();
        private string _name;
        private ICommand _addUserCommand;

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                RaisePropertyChanged(nameof(Name));
            }
        }

        public ICommand AddUserCommand => _addUserCommand;

        public UsersViewModel()
        {
            _addUserCommand = new MvxCommand(DoAddUser);
        }

        private async void DoAddUser()
        {
            await manager.AddUser(Name);
            Name = string.Empty;
        }
    }
}
