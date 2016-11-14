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

        private string _newProductName;
        private int _orderId;

        public SelectOrderItemsViewModel()
        {
            DoneCommand = new MvxCommand(DoDoneCommand);
            AddNewProductCommand = new MvxCommand(DoAddNewProduct);
        }

        public async void Init(int id)
        {
            _orderId = id;
            await LoadData();
        }

        private async Task LoadData()
        {
            var items = await _manager.GetSupliedProducts();
            Items = items.Select(s => new SelectOrderItemViewModel(_orderId, s)).ToList();
        }

        private async void DoAddNewProduct()
        {
            var manager = new SuplyProductsManager();
            await manager.AddNewProduct(NewProductName);
            await LoadData();
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

        public string NewProductName
        {
            get { return _newProductName; }
            set
            {
                _newProductName = value;
                RaisePropertyChanged(nameof(NewProductName));
            }
        }

        public ICommand DoneCommand { get; set; }

        public ICommand AddNewProductCommand { get; set; }
    }
}
