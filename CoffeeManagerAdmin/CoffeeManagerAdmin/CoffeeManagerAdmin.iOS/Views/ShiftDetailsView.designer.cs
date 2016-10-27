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
		UIKit.UILabel CopSalePercentageLabel { get; set; }

		[Outlet]
		UIKit.UITableView ExpenseTableView { get; set; }

		[Outlet]
		UIKit.UITableView GroupedSalesTableView { get; set; }

		[Outlet]
		UIKit.NSLayoutConstraint GroupedSaleTableViewHeightConstraint { get; set; }

		[Outlet]
		UIKit.UILabel Label110 { get; set; }

		[Outlet]
		UIKit.UILabel Label170 { get; set; }

		[Outlet]
		UIKit.UILabel Label250 { get; set; }

		[Outlet]
		UIKit.UILabel Label400 { get; set; }

		[Outlet]
		UIKit.UILabel LabelPlastic { get; set; }

		[Outlet]
		UIKit.UITableView SalesTableView { get; set; }

		[Outlet]
		UIKit.NSLayoutConstraint SaleTableViewHeightConstraint { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (ExpenseTableView != null) {
				ExpenseTableView.Dispose ();
				ExpenseTableView = null;
			}

			if (Label110 != null) {
				Label110.Dispose ();
				Label110 = null;
			}

			if (Label170 != null) {
				Label170.Dispose ();
				Label170 = null;
			}

			if (Label250 != null) {
				Label250.Dispose ();
				Label250 = null;
			}

			if (Label400 != null) {
				Label400.Dispose ();
				Label400 = null;
			}

			if (LabelPlastic != null) {
				LabelPlastic.Dispose ();
				LabelPlastic = null;
			}

			if (SalesTableView != null) {
				SalesTableView.Dispose ();
				SalesTableView = null;
			}

			if (GroupedSalesTableView != null) {
				GroupedSalesTableView.Dispose ();
				GroupedSalesTableView = null;
			}

			if (SaleTableViewHeightConstraint != null) {
				SaleTableViewHeightConstraint.Dispose ();
				SaleTableViewHeightConstraint = null;
			}

			if (GroupedSaleTableViewHeightConstraint != null) {
				GroupedSaleTableViewHeightConstraint.Dispose ();
				GroupedSaleTableViewHeightConstraint = null;
			}

			if (CopSalePercentageLabel != null) {
				CopSalePercentageLabel.Dispose ();
				CopSalePercentageLabel = null;
			}

			if (ByTimeButton != null) {
				ByTimeButton.Dispose ();
				ByTimeButton = null;
			}

			if (ByProductButton != null) {
				ByProductButton.Dispose ();
				ByProductButton = null;
			}
		}
	}
}
