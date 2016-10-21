using System;
using CoffeeManager.Models;
namespace CoffeeManagerAdmin.Core
{
    public class SaleItemViewModel : ViewModelBase
    {
        private Sale _sale;
        public SaleItemViewModel(Sale sale)
        {
            _sale = sale;
        }

        public string Name => _sale.Product1.Name;
        public string Amount => _sale.Amount.ToString("F");
        public string Time => _sale.Time.ToString("HH:mm:ss");
    }
}
