using System;
using System.Collections.Generic;
using CoffeeManager.Models;
using System.Windows.Input;
using MvvmCross.Core.ViewModels;
using MvvmCross.Plugins.Messenger;
using System.Linq;
using System.Threading.Tasks;
namespace CoffeeManagerAdmin.Core
{
    public class ProductsViewModel : ViewModelBase
    {
        private ProductManager manager = new ProductManager();
        private SuplyProductsManager suplyManager = new SuplyProductsManager();

        private MvxSubscriptionToken _productSelectedToken;

        private MvxSubscriptionToken _productListChangedToken;

        private int _id;

        private string _name;

        private string _price;

        private string _policePrice;

        private int _cupType;

        private string _cupTypeName;

        private int _productType;

        private string _productTypeName;

        private ICommand _editProductCommand;

        private ICommand _addProductCommand;

        private bool _isTapped = false;

        private List<ProductItemViewModel> _items = new List<ProductItemViewModel>();

        private Entity _selectedCupType;
        private Entity _selectedProductType;

        public List<Entity> CupTypesList => TypesLists.CupTypesList;



        public List<Entity> ProductTypesList => TypesLists.ProductTypesList;

        public List<ProductItemViewModel> Items
        {
            get { return _items; }
            set
            {
                _items = value;
                RaisePropertyChanged(nameof(Items));
            }
        }


        public ProductsViewModel()
        {
            _editProductCommand = new MvxCommand(DoEditProduct);
            _addProductCommand = new MvxCommand(DoAddProduct);
            _productSelectedToken = Subscribe<ProductSelectedMessage>(DoSetFields);
            _productListChangedToken = Subscribe<ProductListChangedMessage>(async (obj) =>
            {
                await LoadProducts();
                Name = Price = PolicePrice = CupTypeName = ProductTypeName = string.Empty;
                ProductTypeId = -1;
                CupType = -1;
            });
        }

        public async void Init()
        {
            await LoadProducts();
        }


        private async Task LoadProducts()
        {
            var items = await manager.GetProducts();
            Items = items.Select(s => new ProductItemViewModel(s)).ToList();
        }

        private void DoAddProduct()
        {
            ShowViewModel<AddProductViewModel>();
        }

        private void DoSetFields(ProductSelectedMessage obj)
        {
            Name = obj.Data.Name;
            Price = obj.Data.Price.ToString("F");
            PolicePrice = obj.Data.PolicePrice.ToString("F");
            SelectedCupType = TypesLists.CupTypesList.First(i => i.Id == obj.Data.CupType);
            SelectedProductType = TypesLists.ProductTypesList.First(i => i.Id == obj.Data.ProductType);

            _id = obj.Data.Id;
        }

        private void DoEditProduct()
        {
            if (!_isTapped)
            {
                _isTapped = true;
                UserDialogs.Confirm(new Acr.UserDialogs.ConfirmConfig()
                {
                    Message = $"Сохранить изменения в продукте \"{Name}\"?",
                    OnAction = async (obj) =>
                    {
                        if (obj)
                        {
                            await manager.EditProduct(_id, Name, Price, PolicePrice, CupType, ProductTypeId);
                            Name = Price = PolicePrice = CupTypeName = ProductTypeName  = string.Empty;
                            ProductTypeId = -1;
                            CupType = -1;
                            await LoadProducts();
                        }
                        _isTapped = false;
                    }
                });
            }
        }

        public bool IsAddEnabled => !string.IsNullOrEmpty(Name) && !string.IsNullOrEmpty(Price) && !string.IsNullOrEmpty(PolicePrice) && !string.IsNullOrEmpty(CupTypeName) && !string.IsNullOrEmpty(ProductTypeName);

        public ICommand EditProductCommand => _editProductCommand;

        public ICommand AddProductCommand => _addProductCommand;


        public Entity SelectedCupType
        {
            get { return _selectedCupType; }
            set
            {
                if (_selectedCupType != value)
                {
                    _selectedCupType = value;
                    RaisePropertyChanged(nameof(SelectedCupType));
                    RaisePropertyChanged(nameof(IsAddEnabled));
                    CupType = _selectedCupType.Id;
                    CupTypeName = _selectedCupType.Name;
                }
            }
        }

        public Entity SelectedProductType
        {
            get { return _selectedProductType; }
            set
            {
                if (_selectedProductType != value)
                {
                    _selectedProductType = value;
                    RaisePropertyChanged(nameof(SelectedProductType));
                    RaisePropertyChanged(nameof(IsAddEnabled));
                    ProductTypeId = _selectedProductType.Id;
                    ProductTypeName = _selectedProductType.Name;
                }
            }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                RaisePropertyChanged(nameof(Name));
                RaisePropertyChanged(nameof(IsAddEnabled));
            }
        }

        public string Price
        {
            get { return _price; }
            set
            {
                _price = value;
                RaisePropertyChanged(nameof(Price));
                RaisePropertyChanged(nameof(IsAddEnabled));
            }
        }

        public string PolicePrice
        {
            get { return _policePrice; }
            set
            {
                _policePrice = value;
                RaisePropertyChanged(nameof(PolicePrice));
                RaisePropertyChanged(nameof(IsAddEnabled));
            }
        }


        public int CupType
        {
            get { return _cupType; }
            set
            {
                _cupType = value;
                RaisePropertyChanged(nameof(CupType));
                RaisePropertyChanged(nameof(SelectedCupType));
            }
        }

        public string CupTypeName
        {
            get { return _cupTypeName; }
            set
            {
                _cupTypeName = value;
                RaisePropertyChanged(nameof(CupTypeName));
            }
        }

        public int ProductTypeId
        {
            get { return _productType; }
            set
            {
                _productType = value;
                RaisePropertyChanged(nameof(ProductTypeId));
                RaisePropertyChanged(nameof(SelectedProductType));
            }
        }

        public string ProductTypeName
        {
            get { return _productTypeName; }
            set
            {
                _productTypeName = value;
                RaisePropertyChanged(nameof(ProductTypeName));
            }
        }
    }
}
