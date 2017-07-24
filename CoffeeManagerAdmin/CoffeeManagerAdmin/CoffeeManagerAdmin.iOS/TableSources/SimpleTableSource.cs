using CoffeeManagerAdmin.Core;
using Foundation;
using UIKit;

namespace CoffeeManagerAdmin.iOS
{
    public class SimpleTableSource : BaseTableSource<ListItemViewModelBase>
    {
        public SimpleTableSource(UITableView tableView, NSString reuseIdentifier) : base(tableView, reuseIdentifier)
        {
        }
    }
}
    