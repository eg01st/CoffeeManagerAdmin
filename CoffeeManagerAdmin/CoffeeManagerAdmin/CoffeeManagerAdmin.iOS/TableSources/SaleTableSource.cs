using System;
using MvvmCross.Binding.iOS.Views;
using UIKit;

namespace CoffeeManagerAdmin.iOS
{
    public class SaleTableSource : MvxSimpleTableViewSource
    {
        public SaleTableSource(UITableView tableView) : base(tableView, SaleItemCell.Key)
        {

        }
    }
}
