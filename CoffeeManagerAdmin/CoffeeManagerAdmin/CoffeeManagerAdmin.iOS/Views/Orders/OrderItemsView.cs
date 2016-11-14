using System;

using UIKit;
using MvvmCross.iOS.Views;
using MvvmCross.Binding.BindingContext;
using CoffeeManagerAdmin.Core.ViewModels.Orders;
using System.Collections.Generic;
using MvvmCross.Binding.iOS.Views;

namespace CoffeeManagerAdmin.iOS
{
    public partial class OrderItemsView : MvxViewController
    {
        public OrderItemsView() : base("OrderItemsView", null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
            var g = new UITapGestureRecognizer(() => View.EndEditing(true));
            View.AddGestureRecognizer(g);

            var btn = new UIBarButtonItem()
            {
                Title = "Закрыть заявку"
            };


            NavigationItem.SetRightBarButtonItem(btn, false);
            this.AddBindings(new Dictionary<object, string>
            {
                {btn, "Clicked CloseOrderCommand"},

            });


            var expenseTypePicker = new UIPickerView();
            var expensePickerViewModel = new MvxPickerViewModel(expenseTypePicker);
            expenseTypePicker.Model = expensePickerViewModel;
            expenseTypePicker.ShowSelectionIndicator = true;
            ExpenseTypeText.InputView = expenseTypePicker;


            var source = new ProductsTableSource(OrdersTableView, OrderItemViewCell.Key);
            OrdersTableView.Source = source;

            var set = this.CreateBindingSet<OrderItemsView, OrderItemsViewModel>();
            set.Bind(AddProductButton).To(vm => vm.AddOrderItemsCommand);
            set.Bind(AddProductButton).For(b => b.Enabled).To(vm => vm.IsDone).WithConversion(new GenericConverter<bool, bool>((arg) => !arg));
            set.Bind(source).To(vm => vm.Items);
            set.Bind(PriceLabel).To(vm => vm.Price);
            set.Bind(StatusLabel).To(vm => vm.Status);
            set.Bind(ExpenseTypeText).To(vm => vm.ExpenseTypeName);
            set.Bind(expensePickerViewModel).For(p => p.ItemsSource).To(vm => vm.ExpenseItems);
            set.Bind(expensePickerViewModel).For(p => p.SelectedItem).To(vm => vm.SelectedExpenseType);
            set.Apply();
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}

