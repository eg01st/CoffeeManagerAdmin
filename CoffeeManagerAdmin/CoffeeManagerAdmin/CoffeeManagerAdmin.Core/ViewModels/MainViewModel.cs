﻿using System;
using System.Windows.Input;
using CoffeeManagerAdmin.Core.Managers;
using MvvmCross.Core.ViewModels;
using System.Threading.Tasks;
using CoffeeManagerAdmin.Core.ViewModels.Orders;

namespace CoffeeManagerAdmin.Core.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private ShiftManager _shiftManager = new ShiftManager();


        private ICommand _showShiftsCommand;
        private ICommand _showSupliedProductsCommand;
        private ICommand _updateEntireMoneyCommand;
        private ICommand _showOrdersCommand;
        private ICommand _editProductsCommand;
        private ICommand _editUsersCommand;
        private ICommand _editProductCalculation;

        public void ShowErrorMessage(string v)
        {
            UserDialogs.Alert(v);
        }


        private string _currentBalance;

        public ICommand ShowShiftsCommand => _showShiftsCommand;
        public ICommand ShowSupliedProductsCommand => _showSupliedProductsCommand;
        public ICommand UpdateEntireMoneyCommand => _updateEntireMoneyCommand;
        public ICommand ShowOrdersCommand => _showOrdersCommand;
        public ICommand EditProductsCommand => _editProductsCommand;
        public ICommand EditUsersCommand => _editUsersCommand;
        public ICommand EditProductCalculation => _editProductCalculation;


        public string CurrentBalance
        {
            get { return _currentBalance; }
            set
            {
                _currentBalance = value;
                RaisePropertyChanged(nameof(CurrentBalance));
            }
        }
        public MainViewModel()
        {
            _showShiftsCommand = new MvxCommand(DoShowShifts);
            _showSupliedProductsCommand = new MvxCommand(DoShowSupliedProducts);
            _updateEntireMoneyCommand = new MvxCommand(DoGetEntireMoney);
            _showOrdersCommand = new MvxCommand(DoShowOrders);
            _editProductsCommand = new MvxCommand(DoEditProducts);
            _editUsersCommand = new MvxCommand(DoEditUsers);
            _editProductCalculation = new MvxCommand(DoEditCalculation);
        }

        private void DoEditCalculation()
        {
            ShowViewModel<ProductsCalculationViewModel>();
        }

        private void DoEditUsers()
        {
            ShowViewModel<UsersViewModel>();
        }

        private void DoEditProducts()
        {
            ShowViewModel<ProductsViewModel>();
        }

        private void DoShowOrders()
        {
            ShowViewModel<OrdersViewModel>();
        }

        private void DoShowSupliedProducts()
        {
            ShowViewModel<SuplyProductsViewModel>();
        }

        private void DoShowShifts()
        {
            ShowViewModel<ShiftsViewModel>();
        }

        public async void Init()
        {
            await GetEntireMoney();
        }

        private async void DoGetEntireMoney()
        {
            await GetEntireMoney();
        }

        private async Task GetEntireMoney()
        {
            var currentBalance = await _shiftManager.GetEntireMoney();
            CurrentBalance = currentBalance.ToString("F1");
        }
    }
}
