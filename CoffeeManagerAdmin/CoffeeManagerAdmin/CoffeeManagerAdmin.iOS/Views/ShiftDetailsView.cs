using System;

using UIKit;
using MvvmCross.iOS.Views;
using MvvmCross.Binding.BindingContext;
using CoffeeManagerAdmin.Core.ViewModels;
using CoffeeManagerAdmin.Core;
using System.Collections.Generic;
using MvvmCross.Binding.ExtensionMethods;
using CoffeeManager.Models;

namespace CoffeeManagerAdmin.iOS
{
    public partial class ShiftDetailsView : MvxViewController
    {
        public ShiftDetailsView() : base("ShiftDetailsView", null)
        {
        }

        private SaleTableSource tableSource;

        List<SaleItemViewModel> _saleItems;

        public List<SaleItemViewModel> SaleItems
        {
            get { return _saleItems; }
            set
            {
                _saleItems = value;
                if (tableSource.ItemsSource.Count() < 1)
                {
                    tableSource.ItemsSource = _saleItems;
                    SalesTableView.ReloadData();
                }
            }
        }


        List<Entity> _groupedSaleItems;

        public List<Entity> GroupedSaleItems
        {
            get { return _groupedSaleItems; }
            set
            {
                _groupedSaleItems = value;
                if (tableSource.ItemsSource.Count() < 1)
                {
                    tableSource.ItemsSource = _groupedSaleItems;
                    SalesTableView.ReloadData();
                }
            }
        }



        public override void ViewDidLoad()
        {
            base.ViewDidLoad();


            var g = new UITapGestureRecognizer((obj) =>
            {
                tableSource.ItemsSource = _saleItems;
                SalesTableView.ReloadData();
            });
            ByTimeButton.AddGestureRecognizer(g);

            var g1 = new UITapGestureRecognizer((obj) =>
            {
                tableSource.ItemsSource = _groupedSaleItems;
                SalesTableView.ReloadData();
            });
            ByProductButton.AddGestureRecognizer(g1);


            // Perform any additional setup after loading the view, typically from a nib.
            var source = new ExpenseTableSource(ExpenseTableView);
            ExpenseTableView.Source = source;

            tableSource = new SaleTableSource(SalesTableView);
            SalesTableView.Source = tableSource;

            var set = this.CreateBindingSet<ShiftDetailsView, ShiftDetailsViewModel>();
            set.Bind(CopSalePercentageLabel).To(vm => vm.CopSalePercentage);
            set.Bind(this).For(i => i.SaleItems).To(vm => vm.SaleItems);
            set.Bind(this).For(i => i.GroupedSaleItems).To(vm => vm.GroupedSaleItems);
            set.Bind(source).To(vm => vm.ExpenseItems);
            set.Bind(NameLabel).To(vm => vm.Name);
            set.Bind(DateLabel).To(vm => vm.Date);
            set.Bind(CoffeeCounter).To(vm => vm.Counter);
            set.Bind(CoffeeSaleCounter).To(vm => vm.UsedCoffee);
            set.Bind(RejectedSalesLabel).To(vm => vm.RejectedSales);
            set.Bind(UtilizedSalesLabel).To(vm => vm.UtilizedSales);
            set.Apply();
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}

