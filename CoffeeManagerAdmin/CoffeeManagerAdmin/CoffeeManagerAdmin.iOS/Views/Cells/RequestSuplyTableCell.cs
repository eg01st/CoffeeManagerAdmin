using System;

using Foundation;
using UIKit;
using MvvmCross.Binding.iOS.Views;
using MvvmCross.Binding.BindingContext;
using CoffeeManagerAdmin.Core.ViewModels;
using MvvmCross.Binding.iOS.Views.Gestures;
using System.Windows.Input;

namespace CoffeeManagerAdmin.iOS
{
    public partial class RequestSuplyTableCell : MvxTableViewCell
    {
        public static readonly NSString Key = new NSString("RequestSuplyTableCell");
        public static readonly UINib Nib;

        private ICommand _selectActionCommand;
        public ICommand SelectActionCommand
        {
            get { return _selectActionCommand; }
            set
            {
                _selectActionCommand = value;

            }
        }

        static RequestSuplyTableCell()
        {
            Nib = UINib.FromName("RequestSuplyTableCell", NSBundle.MainBundle);
        }

        protected RequestSuplyTableCell(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public override void AwakeFromNib()
        {
            base.AwakeFromNib();

            this.DelayBind(() =>
            {
                var set = this.CreateBindingSet<RequestSuplyTableCell, RequestSuplyItemViewModel>();
                set.Bind(NameLabel).To(vm => vm.Name);
                set.Bind(IsSelected).To(vm => vm.IsSelected);
                set.Bind(this).For(t => t.SelectActionCommand).To(vm => vm.SelectCommand);
                set.Bind(CountLabel).To(vm => vm.ItemCount);
                set.Bind(this.Tap()).For(tap => tap.Command).To(vm => vm.SelectCommand);
                set.Apply();

                IsSelected.ValueChanged += (sender, e) =>
                 {
                     if (!IsSelected.Selected)
                     {
                         SelectActionCommand.Execute(null);
                     }
                 };
            });
        }
    }
}
