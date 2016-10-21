using System;

using Foundation;
using UIKit;
using MvvmCross.Binding.iOS.Views;
using MvvmCross.Binding.BindingContext;
using CoffeeManagerAdmin.Core;

namespace CoffeeManagerAdmin.iOS
{
    public partial class SaleItemCell : MvxTableViewCell
    {
        public static readonly NSString Key = new NSString("SaleItemCell");
        public static readonly UINib Nib;

        static SaleItemCell()
        {
            Nib = UINib.FromName("SaleItemCell", NSBundle.MainBundle);
        }

        protected SaleItemCell(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public override void AwakeFromNib()
        {
            base.AwakeFromNib();

            this.DelayBind(() =>
            {
                var set = this.CreateBindingSet<SaleItemCell, SaleItemViewModel>();
                set.Bind(NameLabel).To(vm => vm.Name);
                set.Bind(AmountLabel).To(vm => vm.Amount);
                set.Bind(TimeLabel).To(vm => vm.Time);
                set.Apply();
            });
        }
    }
}
