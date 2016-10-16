using System;
using System.Collections.Generic;
using System.Linq;
namespace CoffeeManagerAdmin.Core
{
    public class SuplyProductsViewModel : ViewModelBase
    {
        private SuplyProductsManager manager = new SuplyProductsManager();
        private List<SuplyProductItemViewModel> _items;

        public List<SuplyProductItemViewModel> Items
        {
            get { return _items; }
            set
            {
                _items = value;
                RaisePropertyChanged(nameof(Items));
            }
        }

        public SuplyProductsViewModel()
        {
        }

        public async void Init()
        {
            var items = await manager.GetSupliedProducts();
            Items = items.Select(s => new SuplyProductItemViewModel(s)).ToList();
        }
    }
}
