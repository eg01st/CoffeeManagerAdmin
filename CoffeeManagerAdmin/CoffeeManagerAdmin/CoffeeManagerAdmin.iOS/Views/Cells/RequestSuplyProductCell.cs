using System;

using Foundation;
using MvvmCross.Binding.iOS.Views;
using UIKit;

namespace CoffeeManagerAdmin.iOS.Views.Cells
{
    public partial class RequestSuplyProductCell : MvxTableViewCell
    {
        public static readonly NSString Key = new NSString("RequestSuplyProductCell");
        public static readonly UINib Nib;

        static RequestSuplyProductCell()
        {
            Nib = UINib.FromName("RequestSuplyProductCell", NSBundle.MainBundle);
        }

        protected RequestSuplyProductCell(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }
    }
}
