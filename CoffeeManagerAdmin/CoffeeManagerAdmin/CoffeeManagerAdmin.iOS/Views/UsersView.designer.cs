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
	[Register ("UsersView")]
	partial class UsersView
	{
		[Outlet]
		UIKit.UIButton AddButton { get; set; }

		[Outlet]
		UIKit.UITextField NameText { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (NameText != null) {
				NameText.Dispose ();
				NameText = null;
			}

			if (AddButton != null) {
				AddButton.Dispose ();
				AddButton = null;
			}
		}
	}
}
