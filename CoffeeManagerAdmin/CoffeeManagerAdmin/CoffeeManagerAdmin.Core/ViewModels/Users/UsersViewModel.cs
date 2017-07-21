﻿using System;
using System.Windows.Input;
using MvvmCross.Core.ViewModels;
using CoffeeManagerAdmin.Core.Managers;
using System.Collections.Generic;
using CoffeeManager.Models;
using System.Linq;
namespace CoffeeManagerAdmin.Core
{
    public class UsersViewModel : ViewModelBase
    {
        UserManager manager = new UserManager();
        private string _name;
        private List<UserItemViewModel> users;
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

        public List<UserItemViewModel> Users
        {
            get { return users; }
            set
            {
                users = value;
                RaisePropertyChanged(nameof(Users));
            }
        }


        public async void Init()
        {
            var items = await manager.GetUsers();
            Users = items.Select(s => new UserItemViewModel{UserName = s.Name, IsActive = s.IsActive, Id = s.Id})
                    .OrderByDescending(o => o.IsActive).ToList();
        }

        public ICommand AddUserCommand => _addUserCommand;

        public UsersViewModel()
        {
            _addUserCommand = new MvxCommand(DoAddUser);
        }

        private async void DoAddUser()
        {
            if(string.IsNullOrEmpty(Name))
            {
                return;
            }
            var userId = await manager.AddUser(Name);
            Name = string.Empty;
            ShowViewModel<UserDetailsViewModel>(new {id = userId});
        }
    }
}
