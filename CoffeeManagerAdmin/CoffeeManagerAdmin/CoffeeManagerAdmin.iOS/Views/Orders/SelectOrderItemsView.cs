using System;

using UIKit;
using MvvmCross.iOS.Views;
using MvvmCross.Binding.BindingContext;
using CoffeeManagerAdmin.Core.ViewModels.Orders;
using System.Collections.Generic;

namespace CoffeeManagerAdmin.iOS
{
    public partial class SelectOrderItemsView : MvxViewController
    {
        public SelectOrderItemsView() : base("SelectOrderItemsView", null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            NavigationItem.SetHidesBackButton(true, false);

            var btn = new UIBarButtonItem()
            {
                Title = "Готово"
            };


            NavigationItem.SetRightBarButtonItem(btn, false);
            this.AddBindings(new Dictionary<object, string>
            {
                {btn, "Clicked DoneCommand"}

            });

            // Perform any additional setup after loading the view, typically from a nib.
            var source = new ProductsTableSource(ProductsTableView, SelectOrderItemViewCell.Key);
            ProductsTableView.Source = source;

            var set = this.CreateBindingSet<SelectOrderItemsView, SelectOrderItemsViewModel>();
            set.Bind(source).To(vm => vm.Items);
            set.Bind(NewProductText).To(vm => vm.NewProductName);
            set.Bind(AddProdButton).To(vm => vm.AddNewProductCommand);
            set.Apply();
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }


    }
}

