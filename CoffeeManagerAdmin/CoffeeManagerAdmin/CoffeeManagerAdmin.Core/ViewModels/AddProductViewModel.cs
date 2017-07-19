using System.Collections.Generic;
using System.Windows.Input;
using CoffeeManager.Models;
using MvvmCross.Core.ViewModels;

namespace CoffeeManagerAdmin.Core.ViewModels
{
    public class AddProductViewModel : ViewModelBase
    {
        private ProductManager manager = new ProductManager();
        private SuplyProductsManager suplyManager = new SuplyProductsManager();

        private string _name;

        private string _price;

        private string _policePrice;

        private int _cupType;

        private string _cupTypeName;

        private int _productType;

        private string _productTypeName;

        private ICommand _addProductCommand;

        private Entity _selectedCupType;
        private Entity _selectedProductType;


        public List<Entity> CupTypesList => TypesLists.CupTypesList;

        public List<Entity> ProductTypesList => TypesLists.ProductTypesList;

        public ICommand AddProductCommand => _addProductCommand;

        public AddProductViewModel()
        {
            _addProductCommand = new MvxCommand(DoAddProduct);
        }

        private void DoAddProduct()
        {
            UserDialogs.Confirm(new Acr.UserDialogs.ConfirmConfig()
            {
                Message = $"Добавить продукт \"{Name}\"?",
                OnAction = async (obj) =>
                {
                    if (obj)
                    {
                        await manager.AddProduct(Name, Price, PolicePrice, CupType, ProductTypeId);
                        Name = Price = PolicePrice = CupTypeName = ProductTypeName = string.Empty;
                        Publish(new ProductListChangedMessage(this));
                        Close(this);
                    }
                }
            });


        }

        public async void Init()
        {
            var types = await suplyManager.GetSupliedProducts();
        }


        public bool IsAddEnabled => !string.IsNullOrEmpty(Name) && !string.IsNullOrEmpty(Price) && !string.IsNullOrEmpty(PolicePrice) && !string.IsNullOrEmpty(CupTypeName) && !string.IsNullOrEmpty(ProductTypeName);


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
