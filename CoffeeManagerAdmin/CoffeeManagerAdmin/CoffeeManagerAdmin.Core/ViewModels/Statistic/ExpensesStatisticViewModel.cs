using System;
using System.Collections.Generic;
using CoffeeManager.Models;

namespace CoffeeManagerAdmin.Core.ViewModels.Statistic
{
    public class ExpensesStatisticViewModel : ViewModelBase
    {
        public IEnumerable<Expense> Items { get { return items;} set { items = value; RaisePropertyChanged(nameof(Items));}}

        private IEnumerable<Expense> items;

        public void Init(Guid id)
        {
            ParameterTransmitter.TryGetParameter(id, out items);
            RaisePropertyChanged(nameof(Items));
        }
    }
}
