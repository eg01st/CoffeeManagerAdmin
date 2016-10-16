using System;
using System.Windows.Input;
using CoffeeManagerAdmin.Core.Managers;
using MvvmCross.Core.ViewModels;
using System.Threading.Tasks;

namespace CoffeeManagerAdmin.Core.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private ShiftManager _shiftManager = new ShiftManager();


        private ICommand _showShiftsCommand;
        private ICommand _showSupliedProductsCommand;
        private ICommand _updateEntireMoneyCommand;
        private string _currentBalance;

        public ICommand ShowShiftsCommand => _showShiftsCommand;
        public ICommand ShowSupliedProductsCommand => _showSupliedProductsCommand;
        public ICommand UpdateEntireMoneyCommand => _updateEntireMoneyCommand;

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
