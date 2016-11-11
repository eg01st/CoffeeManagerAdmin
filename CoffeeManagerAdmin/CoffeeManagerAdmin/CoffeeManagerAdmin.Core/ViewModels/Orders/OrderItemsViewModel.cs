using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Acr.UserDialogs;
using CoffeeManager.Models;
using CoffeeManagerAdmin.Core.Managers;
using CoffeeManagerAdmin.Core.Messages;
using MvvmCross.Core.ViewModels;

namespace CoffeeManagerAdmin.Core.ViewModels.Orders
{
    public class OrderItemsViewModel : ViewModelBase
    {
        private SuplyOrderManager _manager = new SuplyOrderManager();
        private MvxSubscriptionToken _token;
        private MvxSubscriptionToken _itemsSelectedtoken;

        private bool _isPromt;
        private Order _order;
        private decimal _price;
        private List<OrderItemViewModel> _items = new List<OrderItemViewModel>();

        public OrderItemsViewModel()
        {
            _token = Subscribe<OrderItemChangedMessage>((a) => ReloadPrice());
            _itemsSelectedtoken = Subscribe<OrderItemsListChangedMessage>(async (s) => await LoadData());
            CloseOrder = new MvxCommand(DoCloseOrder);
            AddOrderItems = new MvxCommand(DoAddOrderItems);
        }

        private void DoAddOrderItems()
        {
            ShowViewModel<SelectOrderItemsViewModel>(new {id = _order.Id});
        }

        private void DoCloseOrder()
        {
            if (!_isPromt)
            {
                _isPromt = true;
                UserDialogs.Confirm(new ConfirmConfig
                {
                    Message = "Закрыть заявку? Сумма заказа будет списана с кассы",
                    OnAction = OnCloseOrder
                });
            }

        }

        private async void OnCloseOrder(bool ok)
        {
            if (ok)
            {
                await _manager.CloseOrder(new Order
                {
                    Id = _order.Id,
                    Price = Price
                });
                Publish(new OrderListChangedMessage(this));
            }
            _isPromt = false;
        }

        private void ReloadPrice()
        {
            Price = Items.Where(s => s.IsDone).Sum(orderItemViewModel => orderItemViewModel.Price*orderItemViewModel.Quantity);
        }

        public async void Init(Guid id)
        {
            ParameterTransmitter.TryGetParameter<Order>(id, out _order);
            Price = _order.Price;
            await LoadData();
            ReloadPrice();
        }

        private async Task LoadData()
        {
            var items = await _manager.GetOrderItems(_order.Id);
            Items = items.Select(s => new OrderItemViewModel(s)).ToList();
            ReloadPrice();
        } 

        public ICommand CloseOrder { get; set; }

        public ICommand AddOrderItems { get; set; }

        public List<OrderItemViewModel> Items
        {
            get { return _items; }
            set
            {
                _items = value;
                RaisePropertyChanged(nameof(Items));
            }
        }

        public decimal Price
        {
            get { return _price; }
            set
            {
                _price = value;
                RaisePropertyChanged(nameof(Price));
            }
        }
    }
}
