// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace CoffeeManagerAdmin.iOS
{
	[Register ("SuplyProductCell")]
	partial class SuplyProductCell
	{
		[Outlet]
		UIKit.UILabel AmountLabel { get; set; }

		[Outlet]
		UIKit.UILabel NameLabel { get; set; }

		[Outlet]
		UIKit.UILabel PriceLabel { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (AmountLabel != null) {
				AmountLabel.Dispose ();
				AmountLabel = null;
			}

			if (NameLabel != null) {
				NameLabel.Dispose ();
				NameLabel = null;
			}

			if (PriceLabel != null) {
				PriceLabel.Dispose ();
				PriceLabel = null;
			}
		}
	}
}
