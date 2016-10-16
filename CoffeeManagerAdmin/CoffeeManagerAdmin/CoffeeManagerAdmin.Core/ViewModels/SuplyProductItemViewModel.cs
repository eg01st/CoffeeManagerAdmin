using System;
using CoffeeManager.Models;

namespace CoffeeManagerAdmin.Core
{
    public class SuplyProductItemViewModel : ViewModelBase
    {
        private SupliedProduct _item;


        public SuplyProductItemViewModel(SupliedProduct product)
        {
            _item = product;
        }

        public string Name => _item.Name;

        public decimal Price => _item.Price;

        public string Amount => _item.Amount.ToString();
    }
}
