using System;

using UIKit;
using MvvmCross.iOS.Views;
using MvvmCross.Binding.BindingContext;
using CoffeeManagerAdmin.Core;

namespace CoffeeManagerAdmin.iOS
{
    public partial class SuplyProductDetailsView : MvxViewController
    {
        public SuplyProductDetailsView() : base("SuplyProductDetailsView", null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
            var set = this.CreateBindingSet<SuplyProductDetailsView, SuplyProductDetailsViewModel>();
            set.Bind(NameText).To(vm => vm.Name);
            set.Bind(SuplyPriceText).To(vm => vm.SupliedPrice);
            set.Bind(SalePriceLabel).To(vm => vm.SalePrice);
            set.Bind(ItemCountText).To(vm => vm.ItemCount);
            set.Bind(SaveButton).To(vm => vm.SaveCommand);
            set.Bind(DeleteButton).To(vm => vm.DeleteCommand);
            set.Apply();
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}

