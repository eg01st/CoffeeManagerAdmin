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

        private int? _suplyId;

        private string _suplyName;

        private ICommand _editProductCommand;

        private ICommand _addProductCommand;

        private bool _isTapped = false;

        private List<ProductItemViewModel> _items = new List<ProductItemViewModel>();
        private List<Entity> _suplyProductItems = new List<Entity>();

        private Entity _selectedCupType;
        private Entity _selectedProductType;
        private Entity _supliedProduct;

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

        public List<Entity> SuplyProductItems
        {
            get { return _suplyProductItems; }
            set
            {
                _suplyProductItems = value;
                RaisePropertyChanged(nameof(SuplyProductItems));
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
                Name = Price = PolicePrice = CupTypeName = ProductTypeName = SuplyName = string.Empty;
                SuplyId = -1;
                ProductTypeId = -1;
                CupType = -1;
            });
        }

        public async void Init()
        {
            await LoadProducts();
            var types = await suplyManager.GetSupliedProducts();
            SuplyProductItems = types.Select(s => new Entity { Id = s.Id, Name = s.Name }).ToList();
            SuplyProductItems.Insert(0, new Entity() { Name = "Нету" });
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
            if (obj.Data.SuplyId.HasValue)
            {
                SelectedSupliedProduct = SuplyProductItems.First(i => i.Id == obj.Data.SuplyId.Value);
            }
            else
            {
                SelectedSupliedProduct = null;
            }
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
                            await manager.EditProduct(_id, Name, Price, PolicePrice, CupType, ProductTypeId, SuplyId);
                            Name = Price = PolicePrice = CupTypeName = ProductTypeName = SuplyName = string.Empty;
                            SuplyId = -1;
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

        public Entity SelectedSupliedProduct
        {
            get { return _supliedProduct; }
            set
            {
                if (_supliedProduct != value)
                {
                    _supliedProduct = value;
                    RaisePropertyChanged(nameof(SelectedSupliedProduct));
                    SuplyId = _supliedProduct?.Id;
                    SuplyName = _supliedProduct?.Name;
                }
            }
        }

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

        public int? SuplyId
        {
            get { return _suplyId; }
            set
            {
                _suplyId = value;
                RaisePropertyChanged(nameof(SuplyId));
                RaisePropertyChanged(nameof(SelectedSupliedProduct));
            }
        }

        public string SuplyName
        {
            get { return _suplyName; }
            set
            {
                _suplyName = value;
                RaisePropertyChanged(nameof(SuplyName));
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
