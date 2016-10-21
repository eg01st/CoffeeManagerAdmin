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
	[Register ("SaleItemCell")]
	partial class SaleItemCell
	{
		[Outlet]
		UIKit.UILabel AmountLabel { get; set; }

		[Outlet]
		UIKit.UILabel NameLabel { get; set; }

		[Outlet]
		UIKit.UILabel TimeLabel { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (TimeLabel != null) {
				TimeLabel.Dispose ();
				TimeLabel = null;
			}

			if (NameLabel != null) {
				NameLabel.Dispose ();
				NameLabel = null;
			}

			if (AmountLabel != null) {
				AmountLabel.Dispose ();
				AmountLabel = null;
			}
		}
	}
}
