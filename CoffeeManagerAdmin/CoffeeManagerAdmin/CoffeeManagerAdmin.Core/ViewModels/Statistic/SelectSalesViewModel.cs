using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using CoffeeManager.Models;
using MvvmCross.Core.ViewModels;

namespace CoffeeManagerAdmin.Core
{
    public class SelectSalesViewModel :ViewModelBase
    {
        public IEnumerable<SelectSaleItemViewModel> Items { get { return items;} set { items = value; RaisePropertyChanged(nameof(Items));}}
        IEnumerable<SelectSaleItemViewModel> items;
        IEnumerable<SaleInfo> saleItems;

        public SelectSalesViewModel()
        {
            ShowChartCommand = new MvxCommand(DoShowChart);
        }

        public ICommand ShowChartCommand {get;set;}

        public void Init(Guid id)
        {
            
            ParameterTransmitter.TryGetParameter(id, out saleItems);
            var groupedSales = saleItems.GroupBy(g => g.Name).Select(s => new SelectSaleItemViewModel(s.Key));
            Items = groupedSales;
        }

        private void DoShowChart()
        {
            var selectedItems = Items.Where(i => i.IsSelected).Select(s => s.Name);
            var id = ParameterTransmitter.PutParameter(selectedItems);
            ShowViewModel<SalesChartViewModel>(new {id});
        }
    }
}
