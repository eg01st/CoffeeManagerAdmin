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
    public class RequestSuplyViewModel : ViewModelBase
    {
        private SuplyProductsManager manager = new SuplyProductsManager();
        private List<RequestSuplyItemViewModel> _items = new List<RequestSuplyItemViewModel>();
        private ICommand _addNewProductCommand;
        private ICommand _submitRequestCommand;
        private string _newProduct;

        public ICommand AddNewProductCommand => _addNewProductCommand;
        public ICommand SubmitRequestCommand => _submitRequestCommand;
        public string NewProduct
        {
            get { return _newProduct; }
            set
            {
                _newProduct = value;
                RaisePropertyChanged(nameof(NewProduct));
            }
        }
        public List<RequestSuplyItemViewModel> Items
        {
            get { return _items; }
            set
            {
                _items = value;
                RaisePropertyChanged(nameof(Items));
            }
        }

        public RequestSuplyViewModel()
        {
            _addNewProductCommand = new MvxCommand(DoAddNewProduct);
            _submitRequestCommand = new MvxCommand(DoSubmitRequest);
        }

        private async void DoSubmitRequest()
        {
            var items = Items.Where(i => i.IsSelected).Select(s => new SupliedProduct() {Id = s.Id, Amount = int.Parse(s.ItemCount)});
            await manager.AddNewSuplyRequest(items);
            Close(this);
        }

        private async void DoAddNewProduct()
        {
            await manager.AddNewProduct(NewProduct);
            NewProduct = string.Empty;
            await LoadData();
        }

        public async void Init()
        {
            await LoadData();
        }

        private async Task LoadData()
        {
            var items = await manager.GetSupliedProducts();
            Items = items.Select(s => new RequestSuplyItemViewModel() { Id = s.Id, Name = s.Name, Price = s.Price.ToString("F") }).ToList();

        }
    }
}
