using System;

using UIKit;
using MvvmCross.iOS.Views;
using MvvmCross.Binding.BindingContext;
using CoffeeManagerAdmin.Core.ViewModels;

namespace CoffeeManagerAdmin.iOS
{
    public partial class ShiftDetailsView : MvxViewController
    {
        public ShiftDetailsView() : base("ShiftDetailsView", null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
            var source = new ExpenseTableSource(ExpenseTableView);
            ExpenseTableView.Source = source;

            var saleSource = new SaleTableSource(SalesTableView);
            SalesTableView.Source = saleSource;


            var set = this.CreateBindingSet<ShiftDetailsView, ShiftDetailsViewModel>();
            set.Bind(saleSource).To(vm => vm.SaleItems);
            set.Bind(source).To(vm => vm.ExpenseItems);
            set.Bind(Label110).To(vm => vm.C110);
            set.Bind(Label170).To(vm => vm.C170);
            set.Bind(Label250).To(vm => vm.C250);
            set.Bind(Label400).To(vm => vm.C400);
            set.Bind(LabelPlastic).To(vm => vm.Plastic);
            set.Apply();
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}

