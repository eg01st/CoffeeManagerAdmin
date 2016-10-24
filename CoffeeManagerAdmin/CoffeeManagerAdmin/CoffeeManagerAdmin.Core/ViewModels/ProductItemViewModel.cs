using System;
using CoffeeManager.Models;
using System.Windows.Input;
using MvvmCross.Core.ViewModels;
namespace CoffeeManagerAdmin.Core
{
    public class ProductItemViewModel : ViewModelBase
    {
        private Product _prod;

        private ICommand _selectCommand;

        private ICommand _deleteProductCommand;


        public ICommand DeleteProductCommand => _deleteProductCommand;
        public ICommand SelectCommand => _selectCommand;

        private bool _isTapped;

        public ProductItemViewModel(Product prod)
        {
            _prod = prod;
            _selectCommand = new MvxCommand(DoSelect);
            _deleteProductCommand = new MvxCommand(DoDeleCommand);
        }

        private void DoDeleCommand()
        {
            if (!_isTapped)
            {
                _isTapped = true;

                UserDialogs.Confirm(new Acr.UserDialogs.ConfirmConfig()
                {
                    Message = $"Действительно удалить продукт \"{_prod.Name}\"?",
                    OnAction = async (bool obj) =>
                    {
                        if (obj)
                        {
                            var manager = new ProductManager();
                            await manager.DeleteProduct(_prod.Id);
                            Publish(new ProductListChangedMessage(this));
                        }
                        _isTapped = false;
                    },
                });
            }
        }

        private void DoSelect()
        {
            Publish(new ProductSelectedMessage(this, this));
        }

        public string Name => _prod.Name;

        public decimal Price => _prod.Price;

        public decimal PolicePrice => _prod.PolicePrice;

        public int CupType => _prod.CupType;

        public int ProductType => _prod.ProductType;

        public int Id => _prod.Id;

        public int? SuplyId => _prod.SuplyId;
    }
}
