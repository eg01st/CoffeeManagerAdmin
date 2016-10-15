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
	[Register ("MainView")]
	partial class MainView
	{
		[Outlet]
		UIKit.UILabel CurrentAmountLabel { get; set; }

		[Outlet]
		UIKit.UIButton ShiftButton { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (CurrentAmountLabel != null) {
				CurrentAmountLabel.Dispose ();
				CurrentAmountLabel = null;
			}

			if (ShiftButton != null) {
				ShiftButton.Dispose ();
				ShiftButton = null;
			}
		}
	}
}
