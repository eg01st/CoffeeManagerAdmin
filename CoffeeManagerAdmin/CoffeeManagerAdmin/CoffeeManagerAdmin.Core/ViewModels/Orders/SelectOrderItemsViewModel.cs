using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CoffeeManagerAdmin.Core.Messages;
using MvvmCross.Core.ViewModels;

namespace CoffeeManagerAdmin.Core.ViewModels.Orders
{
    public class SelectOrderItemsViewModel : ViewModelBase
    {
        private SuplyProductsManager _manager = new SuplyProductsManager();
        public async void Init(int id)
        {
            var items = await _manager.GetSupliedProducts();
            Items = items.Select(s => new SelectOrderItemViewModel(id, s)).ToList();
            DoneCommand = new MvxCommand(DoDoneCommand);
        }

        private void DoDoneCommand()
        {
            Publish(new OrderItemsListChangedMessage(this));
            Close(this);
        }

        private List<SelectOrderItemViewModel> _items;

        public List<SelectOrderItemViewModel> Items
        {
            get { return _items; }
            set
            {
                _items = value;
                RaisePropertyChanged(nameof(Items));
            }
        }

        public ICommand DoneCommand { get; set; }
    }
}
