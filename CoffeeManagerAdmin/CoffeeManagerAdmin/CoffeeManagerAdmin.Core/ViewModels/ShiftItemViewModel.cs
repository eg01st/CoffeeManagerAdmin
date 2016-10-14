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

        public DateTime Date => _info.Date;

        public string UserName => _info.UserName;

        public string StartAmount => _info.StartMoney.ToString();

        public string EarnedAmount => _info.ShiftEarnedMoney.ToString();

        public string TotalAmount => _info.TotalAmount.ToString();

        public string RealAmount => _info.RealAmount.ToString();

        public string ExpenseAmount => _info.ExpenseAmount.ToString();
    }
}
