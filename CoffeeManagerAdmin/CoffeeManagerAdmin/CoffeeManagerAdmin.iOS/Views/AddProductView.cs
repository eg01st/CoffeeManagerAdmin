using System;

using UIKit;
using MvvmCross.iOS.Views;
using MvvmCross.Binding.iOS.Views;
using MvvmCross.Binding.BindingContext;
using CoffeeManagerAdmin.Core;

namespace CoffeeManagerAdmin.iOS
{
    public partial class AddProductView : MvxViewController
    {
        public AddProductView() : base("AddProductView", null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.

            var g = new UITapGestureRecognizer(() => View.EndEditing(true));
            View.AddGestureRecognizer(g);

            var cupTypePicker = new UIPickerView();
            var cupPickerViewModel = new MvxPickerViewModel(cupTypePicker);
            cupTypePicker.Model = cupPickerViewModel;
            cupTypePicker.ShowSelectionIndicator = true;
            CupTypeCategoryText.InputView = cupTypePicker;



            var productTypePicker = new UIPickerView();
            var productTypePickerViewModel = new MvxPickerViewModel(productTypePicker);
            productTypePicker.Model = productTypePickerViewModel;
            productTypePicker.ShowSelectionIndicator = true;
            ProductTypeText.InputView = productTypePicker;

            var set = this.CreateBindingSet<AddProductView, AddProductViewModel>();
            set.Bind(NameText).To(vm => vm.Name);
            set.Bind(PriceText).To(vm => vm.Price);
            set.Bind(PolicePriceText).To(vm => vm.PolicePrice);
            set.Bind(CupTypeCategoryText).To(vm => vm.CupTypeName);
            set.Bind(ProductTypeText).To(vm => vm.ProductTypeName);
            set.Bind(AddProductButton).To(vm => vm.AddProductCommand);
            set.Bind(AddProductButton).For(b => b.Enabled).To(vm => vm.IsAddEnabled);
            set.Bind(cupPickerViewModel).For(p => p.ItemsSource).To(vm => vm.CupTypesList);
            set.Bind(cupPickerViewModel).For(p => p.SelectedItem).To(vm => vm.SelectedCupType);
            set.Bind(productTypePickerViewModel).For(p => p.ItemsSource).To(vm => vm.ProductTypesList);
            set.Bind(productTypePickerViewModel).For(p => p.SelectedItem).To(vm => vm.SelectedProductType);
            set.Apply();

        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}

