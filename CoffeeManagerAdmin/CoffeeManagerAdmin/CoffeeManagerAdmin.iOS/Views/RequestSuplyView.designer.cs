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
	[Register ("RequestSuplyView")]
	partial class RequestSuplyView
	{
		[Outlet]
		UIKit.UIButton AddNewProductButton { get; set; }

		[Outlet]
		UIKit.UIButton DoneButton { get; set; }

		[Outlet]
		UIKit.UITextField NewProductLabel { get; set; }

		[Outlet]
		UIKit.UITableView TableView { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (TableView != null) {
				TableView.Dispose ();
				TableView = null;
			}

			if (NewProductLabel != null) {
				NewProductLabel.Dispose ();
				NewProductLabel = null;
			}

			if (AddNewProductButton != null) {
				AddNewProductButton.Dispose ();
				AddNewProductButton = null;
			}

			if (DoneButton != null) {
				DoneButton.Dispose ();
				DoneButton = null;
			}
		}
	}
}
