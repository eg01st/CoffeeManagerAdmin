using System;
using CoffeeManagerAdmin.Core;
using MvvmCross.iOS.Views;
using UIKit;
using MvvmCross.Binding.BindingContext;

namespace CoffeeManagerAdmin.iOS
{
    public partial class SuplyProductsView : MvxViewController
    {
        public SuplyProductsView() : base("SuplyProductsView", null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.

            var source = new SuplyProductTableSource(TableView);
            TableView.Source = source;
            var set = this.CreateBindingSet<SuplyProductsView, SuplyProductsViewModel>();
            set.Bind(source).To(vm => vm.Items);
            set.Apply();
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}

