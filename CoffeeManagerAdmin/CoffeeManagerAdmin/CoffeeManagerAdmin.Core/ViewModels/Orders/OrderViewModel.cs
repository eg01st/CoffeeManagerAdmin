using System.Windows.Input;
using Acr.UserDialogs;
using CoffeeManager.Models;
using CoffeeManagerAdmin.Core.Managers;
using CoffeeManagerAdmin.Core.Messages;
using MvvmCross.Core.ViewModels;

namespace CoffeeManagerAdmin.Core.ViewModels.Orders
{
    public class OrderViewModel : ViewModelBase
    {
        private SuplyOrderManager _manager = new SuplyOrderManager();
        private Order _order;


        private bool _isPromt;
        public OrderViewModel(Order order)
        {
            _order = order;
            DeleteOrderCommand = new MvxCommand(DoDeleteOrder);
            ShowDelailsCommand = new MvxCommand(DoShowDetails);
        }

        private void DoShowDetails()
        {
            var id = ParameterTransmitter.PutParameter(_order);
            ShowViewModel<OrderItemsViewModel>(new {id = id });
        }


        private void DoDeleteOrder()
        {
            if (!_isPromt)
            {
                _isPromt = true;
                UserDialogs.Confirm(new ConfirmConfig
                {
                    Message = "Удалить заказ?",
                    OnAction = OnDeleteOrder
                });
            }
        }

        private async void OnDeleteOrder(bool ok)
        {
            if (ok)
            {
                await _manager.DeleteOrder(_order.Id);
                Publish(new OrderListChangedMessage(this));
            }
            _isPromt = false;
        }

        public decimal Price => _order.Price;

        public string Date => _order.Date.ToString("MM dddd");

        public bool IsDone => _order.IsDone;

        public ICommand DeleteOrderCommand { get; set; }

        public ICommand ShowDelailsCommand { get; set; }
    }
}
