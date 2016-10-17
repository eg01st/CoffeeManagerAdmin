using MvvmCross.Binding.iOS.Views;
using UIKit;

namespace CoffeeManagerAdmin.iOS
{
    public class RequestSuplyTableSource : MvxSimpleTableViewSource
    {
        public RequestSuplyTableSource(UITableView tableView) : base(tableView, RequestSuplyTableCell.Key)
        {

        }
    }
}
