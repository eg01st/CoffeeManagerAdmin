using System;

using Foundation;
using UIKit;
using MvvmCross.Binding.iOS.Views;
using MvvmCross.Binding.BindingContext;
using CoffeeManagerAdmin.Core;
using MvvmCross.Platform.Converters;
using CoffeeManager.Models;
using System.Linq;
using MvvmCross.Binding.iOS.Views.Gestures;
using System.Windows.Input;

namespace CoffeeManagerAdmin.iOS
{
    public partial class ProductItemCell : MvxTableViewCell
    {
        public static readonly NSString Key = new NSString("ProductItemCell");
        public static readonly UINib Nib;

        static ProductItemCell()
        {
            Nib = UINib.FromName("ProductItemCell", NSBundle.MainBundle);
        }

        private ICommand _longPressCommand;
        public ICommand DeleteProductCommand
        {
            get { return _longPressCommand; }
            set
            {
                _longPressCommand = value;

            }
        }

        protected ProductItemCell(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
            var longPressGesture = new UILongPressGestureRecognizer(() => DeleteProductCommand?.Execute(null));
            AddGestureRecognizer(longPressGesture);
        }

        public override void AwakeFromNib()
        {
            base.AwakeFromNib();

            this.DelayBind(() =>
            {
                var set = this.CreateBindingSet<ProductItemCell, ProductItemViewModel>();
                set.Bind(NameLabel).To(vm => vm.Name);
                set.Bind(CategoryLabel).To(vm => vm.ProductType).WithConversion(new GenericConverter<int, string>((arg) =>
                 {
                     var type = TypesLists.ProductTypesList.First(i => i.Id == arg);
                     return type.Name;
                 }));
                set.Bind(this.Tap()).For(t => t.Command).To(vm => vm.SelectCommand);
                set.Bind(this).For(t => t.DeleteProductCommand).To(vm => vm.DeleteProductCommand);
                set.Apply();
            });
        }
    }
}
