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
	[Register ("ShiftDetailsView")]
	partial class ShiftDetailsView
	{
		[Outlet]
		UIKit.UIButton ByProductButton { get; set; }

		[Outlet]
		UIKit.UIButton ByTimeButton { get; set; }

		[Outlet]
		UIKit.UILabel CoffeeCounter { get; set; }

		[Outlet]
		UIKit.UILabel CoffeeSaleCounter { get; set; }

		[Outlet]
		UIKit.UILabel CopSalePercentageLabel { get; set; }

		[Outlet]
		UIKit.UILabel DateLabel { get; set; }

		[Outlet]
		UIKit.UITableView ExpenseTableView { get; set; }

		[Outlet]
		UIKit.UILabel NameLabel { get; set; }

		[Outlet]
		UIKit.UILabel RejectedSalesLabel { get; set; }

		[Outlet]
		UIKit.UITableView SalesTableView { get; set; }

		[Outlet]
		UIKit.NSLayoutConstraint SaleTableViewHeightConstraint { get; set; }

		[Outlet]
		UIKit.UILabel UtilizedSalesLabel { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (ByProductButton != null) {
				ByProductButton.Dispose ();
				ByProductButton = null;
			}

			if (CoffeeCounter != null) {
				CoffeeCounter.Dispose ();
				CoffeeCounter = null;
			}

			if (UtilizedSalesLabel != null) {
				UtilizedSalesLabel.Dispose ();
				UtilizedSalesLabel = null;
			}

			if (RejectedSalesLabel != null) {
				RejectedSalesLabel.Dispose ();
				RejectedSalesLabel = null;
			}

			if (ByTimeButton != null) {
				ByTimeButton.Dispose ();
				ByTimeButton = null;
			}

			if (CoffeeSaleCounter != null) {
				CoffeeSaleCounter.Dispose ();
				CoffeeSaleCounter = null;
			}

			if (CopSalePercentageLabel != null) {
				CopSalePercentageLabel.Dispose ();
				CopSalePercentageLabel = null;
			}

			if (DateLabel != null) {
				DateLabel.Dispose ();
				DateLabel = null;
			}

			if (ExpenseTableView != null) {
				ExpenseTableView.Dispose ();
				ExpenseTableView = null;
			}

			if (NameLabel != null) {
				NameLabel.Dispose ();
				NameLabel = null;
			}

			if (SalesTableView != null) {
				SalesTableView.Dispose ();
				SalesTableView = null;
			}

			if (SaleTableViewHeightConstraint != null) {
				SaleTableViewHeightConstraint.Dispose ();
				SaleTableViewHeightConstraint = null;
			}
		}
	}
}
