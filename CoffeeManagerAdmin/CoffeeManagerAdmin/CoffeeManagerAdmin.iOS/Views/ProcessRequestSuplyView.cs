using System;
using CoffeeManagerAdmin.Core.ViewModels;
using CoffeeManagerAdmin.iOS.TableSources;
using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Views;
using UIKit;

namespace CoffeeManagerAdmin.iOS.Views
{
    public partial class ProcessRequestSuplyView : MvxViewController
    {
        public ProcessRequestSuplyView() : base("ProcessRequestSuplyView", null)
        {
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();

            // Release any cached data, images, etc that aren't in use.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            // Perform any additional setup after loading the view, typically from a nib.

            var source = new RequestSuplyProductTableSource(TableView);
            TableView.Source = source;
            var set = this.CreateBindingSet<ProcessRequestSuplyView, ProcessRequestSuplyViewModel>();
            set.Bind(source).To(vm => vm.Items);
            set.Bind(DoneButton).To(vm => vm.DoneCommand);
            set.Apply();
        }
    }
}