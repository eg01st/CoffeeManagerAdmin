using System;

using UIKit;
using MvvmCross.iOS.Views;
using MvvmCross.Binding.BindingContext;
using CoffeeManagerAdmin.Core.ViewModels;

namespace CoffeeManagerAdmin.iOS
{
    public partial class ProductsCalculationView : MvxViewController
    {
        public ProductsCalculationView() : base("ProductsCalculationView", null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.


            var g = new UITapGestureRecognizer(() => View.EndEditing(true));
            View.AddGestureRecognizer(g);

            var set = this.CreateBindingSet<ProductsCalculationView, ProductsCalculationViewModel>();
            var source = new ProductsTableSource(ProductsTableView, ItemViewCell.Key);
            ProductsTableView.Source = source;
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

