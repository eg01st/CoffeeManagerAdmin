using System;

using UIKit;
using MvvmCross.iOS.Views;

namespace CoffeeManagerAdmin.iOS
{
    public partial class StatisticView : MvxViewController
    {
        public StatisticView() : base("StatisticView", null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}

