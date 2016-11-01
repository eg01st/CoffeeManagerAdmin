using Acr.UserDialogs;
using System.Windows.Input;
using MvvmCross.Core.ViewModels;
using System;

namespace CoffeeManagerAdmin.Core.ViewModels
{
    public class ProcessSuplyRequestItemViewModel : RequestSuplyItemViewModel
    {
        private bool _isPromt = false;
        private ICommand _deleteRequestCommand;
        public ICommand DeleteRequestCommand => _deleteRequestCommand;

        public ProcessSuplyRequestItemViewModel()
        {
            _deleteRequestCommand = new MvxCommand(DoDeleteRequest);
        }

        private void DoDeleteRequest()
        {
            if (!_isPromt)
            {
                _isPromt = true;
                UserDialogs.Confirm(new ConfirmConfig
                {
                    Message = "Удалить заявку?",
                    OnAction = async (bool obj) =>
                    {
                        if (obj)
                        {
                            await new SuplyProductsManager().DeleteSuplyRequest(Id);
                            Publish(new ProcessRequestSuplyListChangedMessage(this));
                        }
                        _isPromt = false;
                    }
                });
            }

        }

        protected override void DoSelect()
        {
            if (!IsSelected)
            {
                UserDialogs.Prompt(new PromptConfig
                {
                    Message = "Введите цену",
                    OnAction = OnAction,
                    InputType = InputType.DecimalNumber,
                    Text = Price
                });
            }
            IsSelected = !IsSelected;
        }

        private void OnAction(PromptResult obj)
        {
            if (obj.Ok)
            {
                Price = obj.Text;
            }
        }
    }
}
