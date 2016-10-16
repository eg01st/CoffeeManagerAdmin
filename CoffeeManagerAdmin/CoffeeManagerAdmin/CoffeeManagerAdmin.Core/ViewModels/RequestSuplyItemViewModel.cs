﻿using System.Windows.Input;
using Acr.UserDialogs;
using MvvmCross.Core.ViewModels;

namespace CoffeeManagerAdmin.Core.ViewModels
{
    public class RequestSuplyItemViewModel : ViewModelBase
    {
        private int _id;
        private bool _isSelected;
        private string _name;
        private string _price;
        private string _itemCount;

        private ICommand _selectCommand;

        public ICommand SelectCommand => _selectCommand;
        public int Id
        {
            get { return _id; }
            set
            {
                _id = value;
                RaisePropertyChanged(nameof(Id));
            }
        }
        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                _isSelected = value;
                RaisePropertyChanged(nameof(IsSelected));
            }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                RaisePropertyChanged(nameof(Name));
            }
        }
        public string Price
        {
            get { return _price; }
            set
            {
                _price = value;
                RaisePropertyChanged(nameof(Price));
            }
        }
        public string ItemCount
        {
            get { return _itemCount; }
            set
            {
                _itemCount = value;
                RaisePropertyChanged(nameof(ItemCount));
            }
        }

        public RequestSuplyItemViewModel()
        {
            _selectCommand = new MvxCommand(DoSelect);
        }

        private async void DoSelect()
        {
            IsSelected = !IsSelected;
            if (IsSelected)
            {
                await
                    UserDialogs.PromptAsync(new PromptConfig
                    {
                        Message = "Введите количество",
                        OnAction = OnAction,
                        Title = "Введите количество",
                        InputType = InputType.Number
                    });
            }
        }

        private void OnAction(PromptResult promptResult)
        {
            ItemCount = promptResult.Text;
        }
    }
}
