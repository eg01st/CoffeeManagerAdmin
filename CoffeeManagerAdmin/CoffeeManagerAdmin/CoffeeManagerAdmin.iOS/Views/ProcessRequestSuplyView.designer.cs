// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace CoffeeManagerAdmin.iOS.Views
{
	[Register ("ProcessRequestSuplyView")]
	partial class ProcessRequestSuplyView
	{
		[Outlet]
		UIKit.UIButton DoneButton { get; set; }

		[Outlet]
		UIKit.UITableView TableView { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (DoneButton != null) {
				DoneButton.Dispose ();
				DoneButton = null;
			}

			if (TableView != null) {
				TableView.Dispose ();
				TableView = null;
			}
		}
	}
}
