using System;
using System.Windows.Input;
using CoffeeManagerAdmin.Core.ViewModels;
using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using MvvmCross.Binding.iOS.Views.Gestures;
using UIKit;

namespace CoffeeManagerAdmin.iOS.Views.Cells
{
    public partial class RequestSuplyProductCell : MvxTableViewCell
    {
        public static readonly NSString Key = new NSString("RequestSuplyProductCell");
        public static readonly UINib Nib;

        static RequestSuplyProductCell()
        {
            Nib = UINib.FromName("RequestSuplyProductCell", NSBundle.MainBundle);
        }

        private ICommand _selectActionCommand;
        public ICommand SelectActionCommand
        {
            get { return _selectActionCommand; }
            set
            {
                _selectActionCommand = value;

            }
        }

        private ICommand _longPressCommand;
        public ICommand DeleteRequestCommand
        {
            get { return _longPressCommand; }
            set
            {
                _longPressCommand = value;

            }
        }

        protected RequestSuplyProductCell(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
            var longPressGesture = new UILongPressGestureRecognizer(() => DeleteRequestCommand?.Execute(null));
            AddGestureRecognizer(longPressGesture);
        }

        public override void AwakeFromNib()
        {
            base.AwakeFromNib();

            this.DelayBind(() =>
            {
                var set = this.CreateBindingSet<RequestSuplyProductCell, ProcessSuplyRequestItemViewModel>();
                set.Bind(NameLabel).To(vm => vm.Name);
                set.Bind(PriceLabel).To(vm => vm.Price);
                set.Bind(AmountLabel).To(vm => vm.ItemCount);
                set.Bind(IsSelected).To(vm => vm.IsSelected);
                set.Bind(this).For(t => t.SelectActionCommand).To(vm => vm.SelectCommand);
                set.Bind(this).For(t => t.DeleteRequestCommand).To(vm => vm.DeleteRequestCommand);
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
            AmountLabel.ShouldReturn += (textField) =>
            {
                textField.ResignFirstResponder();
                return true;
            };
        }
    }
}
