using System;

using UIKit;
using MvvmCross.iOS.Views;
using MvvmCross.Binding.iOS.Views;
using MvvmCross.Binding.BindingContext;
using CoffeeManagerAdmin.Core;
using CoffeeManager.Models;

namespace CoffeeManagerAdmin.iOS
{
    public partial class ProductsView : MvxViewController
    {
        public ProductsView() : base("ProductsView", null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.

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



            var set = this.CreateBindingSet<ProductsView, ProductsViewModel>();
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

            var g = new UITapGestureRecognizer(() => CupTypeCategoryText.ResignFirstResponder());
            View.AddGestureRecognizer(g);

            var g1 = new UITapGestureRecognizer(() => ProductTypeText.ResignFirstResponder());
            View.AddGestureRecognizer(g1);

        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}

