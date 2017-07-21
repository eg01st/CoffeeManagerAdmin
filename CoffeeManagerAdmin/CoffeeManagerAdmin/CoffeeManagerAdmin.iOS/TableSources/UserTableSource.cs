
using CoffeeManagerAdmin.Core;
using UIKit;


namespace CoffeeManagerAdmin.iOS
{
    public class UserTableSource : BaseTableSource<UserItemViewModel>
    { 
        public UserTableSource(UITableView tableView) : base(tableView, UserTableViewCell.Key)
        {

        }
    }
}
