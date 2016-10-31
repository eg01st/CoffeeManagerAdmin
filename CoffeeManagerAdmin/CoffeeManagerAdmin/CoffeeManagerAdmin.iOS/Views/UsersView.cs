using System;

using UIKit;
using MvvmCross.iOS.Views;
using MvvmCross.Binding.BindingContext;
using CoffeeManagerAdmin.Core;

namespace CoffeeManagerAdmin.iOS
{
    public partial class UsersView : MvxViewController
    {
        public UsersView() : base("UsersView", null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            var g = new UITapGestureRecognizer(() => View.EndEditing(true));
            View.AddGestureRecognizer(g);

            var set = this.CreateBindingSet<UsersView, UsersViewModel>();
            set.Bind(NameText).To(vm => vm.Name);
            set.Bind(AddButton).To(vm => vm.AddUserCommand);
            set.Apply();
            // Perform any additional setup after loading the view, typically from a nib.
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

    }
}

