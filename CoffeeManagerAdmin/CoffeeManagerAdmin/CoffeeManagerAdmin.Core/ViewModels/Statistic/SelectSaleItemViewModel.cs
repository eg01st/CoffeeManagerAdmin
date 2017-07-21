using System;
namespace CoffeeManagerAdmin.Core
{
    public class SelectSaleItemViewModel : ViewModelBase
    {
        public string Name {get;set;}
        public bool IsSelected {get;set;}

        public SelectSaleItemViewModel(string name)
        {
            Name = name;
        }
    }
}
