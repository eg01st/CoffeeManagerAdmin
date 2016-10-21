using System;

using UIKit;
using MvvmCross.iOS.Views;
using CoffeeManagerAdmin.Core.ViewModels;
using MvvmCross.Binding.BindingContext;

namespace CoffeeManagerAdmin.iOS
{
    public partial class RequestSuplyView : MvxViewController
    {
        public RequestSuplyView() : base("RequestSuplyView", null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.

            var source = new RequestSuplyTableSource(TableView);
            TableView.Source = source;
            var set = this.CreateBindingSet<RequestSuplyView, RequestSuplyViewModel>();
            set.Bind(source).To(vm => vm.Items);
            set.Bind(AddNewProductButton).To(vm => vm.AddNewProductCommand);
            set.Bind(NewProductLabel).To(vm => vm.NewProduct);
            set.Bind(DoneButton).To(vm => vm.SubmitRequestCommand);
            set.Apply();

            NewProductLabel.ShouldReturn += (textField) =>
            {
                textField.ResignFirstResponder();
                return true;
            };
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}

