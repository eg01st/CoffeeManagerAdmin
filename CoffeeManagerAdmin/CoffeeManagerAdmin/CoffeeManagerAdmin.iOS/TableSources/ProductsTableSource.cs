using System;
using MvvmCross.Binding.iOS.Views;
using UIKit;
using Foundation;

namespace CoffeeManagerAdmin.iOS
{
    public class ProductsTableSource : MvxSimpleTableViewSource
    {
        public ProductsTableSource(UITableView tableView, NSString cellKey) : base(tableView, cellKey)
        {

        }
    }
}
