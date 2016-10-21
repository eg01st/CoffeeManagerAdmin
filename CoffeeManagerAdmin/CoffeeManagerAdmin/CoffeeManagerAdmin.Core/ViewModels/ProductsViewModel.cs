using System;
using System.Collections.Generic;
using CoffeeManager.Models;
using System.Windows.Input;
using MvvmCross.Core.ViewModels;
namespace CoffeeManagerAdmin.Core
{
    public class ProductsViewModel : ViewModelBase
    {
        private ProductManager manager = new ProductManager();

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

        public List<Entity> CupTypesList => new List<Entity>()
        {
            new Entity { Name = "Нету", Id = (int)CupTypeEnum.Unknown},
            new Entity { Name = "110", Id = (int)CupTypeEnum.c110},
            new Entity { Name = "170", Id = (int)CupTypeEnum.c170},
            new Entity { Name = "250", Id = (int)CupTypeEnum.c250},
            new Entity { Name = "400", Id = (int)CupTypeEnum.c400},
            new Entity { Name = "Пластик", Id = (int)CupTypeEnum.Plastic},
        };

        public List<Entity> ProductTypesList => new List<Entity>()
        {
            new Entity { Name = "Кофе", Id = (int)ProductType.Coffee},
            new Entity { Name = "Чай", Id = (int)ProductType.Tea},
            new Entity { Name = "Вода", Id = (int)ProductType.Water},
            new Entity { Name = "Сладости", Id = (int)ProductType.Sweets},
            new Entity { Name = "Еда", Id = (int)ProductType.Meals},
            new Entity { Name = "Добавки", Id = (int)ProductType.Adds},
            new Entity { Name = "Хол. напитки", Id = (int)ProductType.ColdDrinks},
            new Entity { Name = "Мороженое", Id = (int)ProductType.IceCream},
        };

        public ProductsViewModel()
        {
            _addProductCommand = new MvxCommand(DoAddProduct);
        }

        private async void DoAddProduct()
        {
            await manager.AddProduct(Name, Price, PolicePrice, CupType, ProductTypeId);
            Name = Price = PolicePrice = CupTypeName = ProductTypeName = string.Empty;
        }

        public bool IsAddEnabled => !string.IsNullOrEmpty(Name) && !string.IsNullOrEmpty(Price) && !string.IsNullOrEmpty(PolicePrice) && !string.IsNullOrEmpty(CupTypeName) && !string.IsNullOrEmpty(ProductTypeName);

        public ICommand AddProductCommand => _addProductCommand;

        public Entity SelectedCupType
        {
            get { return _selectedCupType; }
            set
            {
                _selectedCupType = value;
                RaisePropertyChanged(nameof(SelectedCupType));
                RaisePropertyChanged(nameof(IsAddEnabled));
                CupType = _selectedCupType.Id;
                CupTypeName = _selectedCupType.Name;
            }
        }

        public Entity SelectedProductType
        {
            get { return _selectedProductType; }
            set
            {
                _selectedProductType = value;
                RaisePropertyChanged(nameof(SelectedProductType));
                RaisePropertyChanged(nameof(IsAddEnabled));
                ProductTypeId = _selectedProductType.Id;
                ProductTypeName = _selectedProductType.Name;
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
