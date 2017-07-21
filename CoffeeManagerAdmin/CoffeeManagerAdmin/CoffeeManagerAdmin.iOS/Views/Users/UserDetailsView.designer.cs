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
	[Register ("UserDetailsView")]
	partial class UserDetailsView
	{
		[Outlet]
		UIKit.UILabel CurrentSalaryLabel { get; set; }

		[Outlet]
		UIKit.UITextField DayPercentageTextField { get; set; }

		[Outlet]
		UIKit.UILabel EntireSalaryLabel { get; set; }

		[Outlet]
		UIKit.UITextField ExpenseTypeTextField { get; set; }

		[Outlet]
		UIKit.UILabel NameLabel { get; set; }

		[Outlet]
		UIKit.UITextField NightPercentageTextField { get; set; }

		[Outlet]
		UIKit.UIButton PaySalaryButton { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (NameLabel != null) {
				NameLabel.Dispose ();
				NameLabel = null;
			}

			if (CurrentSalaryLabel != null) {
				CurrentSalaryLabel.Dispose ();
				CurrentSalaryLabel = null;
			}

			if (EntireSalaryLabel != null) {
				EntireSalaryLabel.Dispose ();
				EntireSalaryLabel = null;
			}

			if (DayPercentageTextField != null) {
				DayPercentageTextField.Dispose ();
				DayPercentageTextField = null;
			}

			if (NightPercentageTextField != null) {
				NightPercentageTextField.Dispose ();
				NightPercentageTextField = null;
			}

			if (ExpenseTypeTextField != null) {
				ExpenseTypeTextField.Dispose ();
				ExpenseTypeTextField = null;
			}

			if (PaySalaryButton != null) {
				PaySalaryButton.Dispose ();
				PaySalaryButton = null;
			}
		}
	}
}
