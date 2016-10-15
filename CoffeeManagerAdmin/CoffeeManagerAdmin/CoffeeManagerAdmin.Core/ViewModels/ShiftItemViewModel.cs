using System;
using CoffeeManager.Models;

namespace CoffeeManagerAdmin.Core.ViewModels
{
    public class ShiftItemViewModel : ViewModelBase
    {
        private readonly ShiftInfo _info;

        public ShiftItemViewModel(ShiftInfo info)
        {
            _info = info;
        }

        public string Date => _info.Date.Date.ToString("dd-MM");

        public string UserName => _info.UserName;

        public string StartAmount => ((int)_info.StartMoney).ToString();

        public string EarnedAmount => ((int)_info.ShiftEarnedMoney).ToString();

        public string TotalAmount => ((int)_info.TotalAmount).ToString();

        public string RealAmount => ((int)_info.RealAmount).ToString();

        public string ExpenseAmount => ((int)_info.ExpenseAmount).ToString();
    }
}
