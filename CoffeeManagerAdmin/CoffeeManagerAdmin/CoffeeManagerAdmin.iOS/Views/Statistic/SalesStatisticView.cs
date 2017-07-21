using System;

using UIKit;
using MvvmCross.iOS.Views;
using CoffeeManagerAdmin.Core.ViewModels.Statistic;
using MvvmCross.Binding.BindingContext;

namespace CoffeeManagerAdmin.iOS
{
    public partial class SalesStatisticView : MvxViewController
    {
        public SalesStatisticView() : base("SalesStatisticView", null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            Title = "Продажи";
            var tableSource = new SalesStatisticTableSource(TableView);
            TableView.RegisterNibForCellReuse(SaleStatisticViewCell.Nib, SaleStatisticViewCell.Key);
            TableView.Source = tableSource;

            var set = this.CreateBindingSet<SalesStatisticView, SalesStatisticViewModel>();
            set.Bind(tableSource).For(i => i.ItemsSource).To(vm => vm.Items);
            set.Apply();
        }

    }
}

