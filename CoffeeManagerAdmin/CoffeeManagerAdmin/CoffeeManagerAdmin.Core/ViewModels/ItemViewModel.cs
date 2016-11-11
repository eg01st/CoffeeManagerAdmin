using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CoffeeManager.Models;
using MvvmCross.Core.ViewModels;

namespace CoffeeManagerAdmin.Core.ViewModels
{
    public class ItemViewModel : ViewModelBase
    {
        private Product _prod;
        private ICommand _selectCommand;
        public ItemViewModel(Product prod)
        {
            _prod = prod;
            _selectCommand = new MvxCommand(DoSelect);
        }

        private void DoSelect()
        {
            ShowViewModel<CalculationViewModel>(new { id = _prod.Id });
        }

        public int Id => _prod.Id;

        public ICommand SelectCommand => _selectCommand;
        public string Name => _prod.Name + " : " + _prod.Price.ToString("F1");


    }
}
