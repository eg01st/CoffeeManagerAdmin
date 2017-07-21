using System;

using UIKit;
using MvvmCross.iOS.Views;
using MvvmCross.Binding.BindingContext;
using CoffeeManagerAdmin.Core;
using System.Windows.Input;

namespace CoffeeManagerAdmin.iOS
{
    public partial class UsersView : MvxViewController
    {
        private UITapGestureRecognizer addUserRegognizer;

        private ICommand _addUserCommand;
        public ICommand AddUserCommand
        {
            get { return _addUserCommand; }
            set
            {
                _addUserCommand = value;

            }
        }

        public UsersView() : base("UsersView", null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var source = new UserTableSource(UsersTableView);
            UsersTableView.RegisterNibForCellReuse(UserTableViewCell.Nib, UserTableViewCell.Key);
            UsersTableView.Source = source;
        
            var set = this.CreateBindingSet<UsersView, UsersViewModel>();
            set.Bind(NameText).To(vm => vm.Name);
            set.Bind(this).For(t => t.AddUserCommand).To(vm => vm.AddUserCommand);
            set.Bind(source).To(vm => vm.Users);
            set.Apply();
            
            addUserRegognizer = new UITapGestureRecognizer(() => 
            {
                View.EndEditing(true);
                AddUserCommand.Execute(null);
            });           
            AddButton.AddGestureRecognizer(addUserRegognizer);
        }

    }
}

