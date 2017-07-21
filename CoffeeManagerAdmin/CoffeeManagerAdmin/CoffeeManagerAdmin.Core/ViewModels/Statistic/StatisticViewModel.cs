using System;
using System.Collections.Generic;
using System.Windows.Input;
using Acr.UserDialogs;
using CoffeeManager.Models;
using CoffeeManagerAdmin.Core.Managers;
using CoffeeManagerAdmin.Core.ViewModels.Statistic;
using MvvmCross.Core.ViewModels;

namespace CoffeeManagerAdmin.Core
{
    public class StatisticViewModel : ViewModelBase
    {
        StatisticManager sm = new StatisticManager();

        private DateTime from = DateTime.Now.AddMonths(-1);
        private DateTime to = DateTime.Now;
    

        public ICommand ShowExpensesCommand { get; set; }
        public ICommand ShowSalesCommand { get; set; }
        public ICommand GetDataCommand { get; set; }

        public DateTime From { get { return from; }  set { from = value;  RaisePropertyChanged(nameof(From));} }
        public DateTime To { get { return to; } set { to = value; RaisePropertyChanged(nameof(To)); } }

        private IEnumerable<Expense> expenses;
        private IEnumerable<SaleInfo> sales;

        public StatisticViewModel()
        {
            ShowExpensesCommand = new MvxCommand(DoShowExpenses);
            ShowSalesCommand = new MvxCommand(DoShowSales);
            GetDataCommand = new MvxCommand(DoGetData);
        }

        private void DoShowSales()
        {
            var id = ParameterTransmitter.PutParameter(sales);
            ShowViewModel<SalesStatisticViewModel>(new {id = id});
        }

        private void DoShowExpenses()
        {
            var id = ParameterTransmitter.PutParameter(expenses);
            ShowViewModel<ExpensesStatisticViewModel>(new { id = id });
        }

        private async void DoGetData()
        {
            expenses = await sm.GetExpenses(From, To);
            sales = await sm.GetSales(From, To);

            UserDialogs.ActionSheet(new Acr.UserDialogs.ActionSheetConfig()
            {
                Options = new List<ActionSheetOption>()
                {
                    new ActionSheetOption("Траты", () => DoShowExpenses()),
                    new ActionSheetOption("Продажи", () => DoShowSales()),
                }
            });
        }
    }
}
