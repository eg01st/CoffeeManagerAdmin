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

            var suplyPicker = new UIPickerView();
            var suplyPickerViewModel = new MvxPickerViewModel(suplyPicker);
            suplyPicker.Model = suplyPickerViewModel;
            suplyPicker.ShowSelectionIndicator = true;
            SuplyBindingLabel.InputView = suplyPicker;


            var set = this.CreateBindingSet<ProductsView, ProductsViewModel>();
            set.Bind(NameText).To(vm => vm.Name);
            set.Bind(PriceText).To(vm => vm.Price);
            set.Bind(PolicePriceText).To(vm => vm.PolicePrice);
            set.Bind(CupTypeCategoryText).To(vm => vm.CupTypeName);
            set.Bind(ProductTypeText).To(vm => vm.ProductTypeName);
            set.Bind(SuplyBindingLabel).To(vm => vm.SuplyName);
            set.Bind(EditProductButton).To(vm => vm.EditProductCommand);
            set.Bind(EditProductButton).For(b => b.Enabled).To(vm => vm.IsAddEnabled);
            set.Bind(cupPickerViewModel).For(p => p.ItemsSource).To(vm => vm.CupTypesList);
            set.Bind(cupPickerViewModel).For(p => p.SelectedItem).To(vm => vm.SelectedCupType);
            set.Bind(productTypePickerViewModel).For(p => p.ItemsSource).To(vm => vm.ProductTypesList);
            set.Bind(productTypePickerViewModel).For(p => p.SelectedItem).To(vm => vm.SelectedProductType);
            set.Bind(suplyPickerViewModel).For(p => p.ItemsSource).To(vm => vm.SuplyProductItems);
            set.Bind(suplyPickerViewModel).For(p => p.SelectedItem).To(vm => vm.SelectedSupliedProduct);
            set.Bind(AddProductButton).To(vm => vm.AddProductCommand);


            var source = new ProductsTableSource(ProductsTableView);
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

