using CoffeeManagerAdmin.iOS.Views.Cells;
using MvvmCross.Binding.iOS.Views;
using UIKit;

namespace CoffeeManagerAdmin.iOS.TableSources
{
    public class RequestSuplyProductTableSource : MvxSimpleTableViewSource
    {
        public RequestSuplyProductTableSource(UITableView tableView) : base(tableView, RequestSuplyProductCell.Key)
        {

        }
    }
}
