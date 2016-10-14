using System.Windows.Input;
using CoffeeManagerAdmin.Core.Managers;
using MvvmCross.Core.ViewModels;

namespace CoffeeManagerAdmin.Core.ViewModels
{
	public class MainViewModel : ViewModelBase
	{
        private ShiftManager _shiftManager = new ShiftManager();


	    private ICommand _showShiftsCommand;
	    private string _currentBalance;

	    public ICommand ShowShiftsCommand => _showShiftsCommand;

        public string CurrentBalance
	    {
	        get { return _currentBalance; }
	        set
	        {
	            _currentBalance = value;
	            RaisePropertyChanged(nameof(CurrentBalance));
	        }
	    }
		public MainViewModel ()
		{
            _showShiftsCommand = new MvxCommand(DoShowShifts);

        }

	    private void DoShowShifts()
	    {
	        ShowViewModel<ShiftsViewModel>();
	    }

	    public async void Init()
	    {
	        var currentBalance = await _shiftManager.GetEntireMoney();
	        CurrentBalance = currentBalance.ToString();
	    }
	}
}
