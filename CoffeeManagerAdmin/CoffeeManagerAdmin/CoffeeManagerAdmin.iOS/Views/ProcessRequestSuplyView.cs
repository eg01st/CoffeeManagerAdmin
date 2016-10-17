using System;
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
        }
    }
}