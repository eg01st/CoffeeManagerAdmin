using System;
using MvvmCross.Binding.iOS.Views;
using UIKit;

namespace CoffeeManagerAdmin.iOS
{
    public class ProductsTableSource : MvxSimpleTableViewSource
    {
        public ProductsTableSource(UITableView tableView) : base(tableView, ProductItemCell.Key)
        {

        }
    }
}
