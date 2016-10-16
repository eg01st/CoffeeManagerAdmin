﻿using System;

using Foundation;
using UIKit;
using MvvmCross.Binding.iOS.Views;
using MvvmCross.Binding.BindingContext;
using CoffeeManagerAdmin.Core;
using MvvmCross.Platform.Converters;

namespace CoffeeManagerAdmin.iOS
{
    public partial class SuplyProductCell : MvxTableViewCell
    {
        public static readonly NSString Key = new NSString("SuplyProductCell");
        public static readonly UINib Nib;

        static SuplyProductCell()
        {
            Nib = UINib.FromName("SuplyProductCell", NSBundle.MainBundle);
        }

        protected SuplyProductCell(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public override void AwakeFromNib()
        {
            base.AwakeFromNib();

            this.DelayBind(() =>
            {
                var set = this.CreateBindingSet<SuplyProductCell, SuplyProductItemViewModel>();
                set.Bind(NameLabel).To(vm => vm.Name);
                set.Bind(AmountLabel).To(vm => vm.Amount);
                set.Bind(PriceLabel).To(vm => vm.Price).WithConversion(new DecimalToStringConverter());

                set.Apply();

            });
        }
    }
}