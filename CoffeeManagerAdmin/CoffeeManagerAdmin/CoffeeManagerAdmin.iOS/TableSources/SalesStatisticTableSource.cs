using System;
using CoffeeManagerAdmin.Core;
using UIKit;
namespace CoffeeManagerAdmin.iOS
{
    public class SalesStatisticTableSource : BaseTableSource<SaleItemViewModel>
    {
        public SalesStatisticTableSource(UITableView tableView) : base(tableView, SaleStatisticViewCell.Key)
        {
        }
    }
}
