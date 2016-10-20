using System;

using UIKit;
using MvvmCross.iOS.Views;
using MvvmCross.Binding.BindingContext;
using CoffeeManagerAdmin.Core.ViewModels;

namespace CoffeeManagerAdmin.iOS
{
    public partial class MainView : MvxViewController
    {
        public MainView() : base("MainView", null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            var set = this.CreateBindingSet<MainView, MainViewModel>();
            set.Bind(CurrentAmountLabel).To(vm => vm.CurrentBalance);
            set.Bind(UpdateButton).To(vm => vm.UpdateEntireMoneyCommand);
            set.Bind(ShiftButton).To(vm => vm.ShowShiftsCommand);
            set.Bind(SupliedProductsButton).To(vm => vm.ShowSupliedProductsCommand);
            set.Bind(CreateSuplyRequest).To(vm => vm.RequestSuplyCommand);
            set.Bind(ProcessSuplyRequestButton).To(vm => vm.ProcessRequestSuplyCommand);
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

