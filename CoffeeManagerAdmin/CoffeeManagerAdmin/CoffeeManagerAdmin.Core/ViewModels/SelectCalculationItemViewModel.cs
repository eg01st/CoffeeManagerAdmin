using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Acr.UserDialogs;
using CoffeeManager.Models;
using CoffeeManagerAdmin.Core.Messages;
using MvvmCross.Core.ViewModels;

namespace CoffeeManagerAdmin.Core.ViewModels
{
    public class SelectCalculationItemViewModel : ViewModelBase
    {
        private int _productId;
        private SupliedProduct _prod;

        private ICommand _addCalculationProductItemCommand;
        public SelectCalculationItemViewModel(int productId, SupliedProduct prod)
        {
            _prod = prod;
            _productId = productId;
            _addCalculationProductItemCommand = new MvxCommand(DoAddCalculationItem);
        }

        private void DoAddCalculationItem()
        {
            UserDialogs.Prompt(new PromptConfig()
            {
                InputType = InputType.DecimalNumber,
                Message = "Укажите сколько тратится на одну порцию продукта (в килограммах, литрах, штуках)",
                OnAction = AddItem,

            });


        }

        private async void AddItem(PromptResult obj)
        {
            if (obj.Ok)
            {
                var manager = new SuplyProductsManager();
                await manager.AddProductCalculationItem(_productId, _prod.Id, decimal.Parse(obj.Text));
                Publish(new CalculationListChangedMessage(this));
            }
        }

        public ICommand AddCalculationProductItemCommand => _addCalculationProductItemCommand;

        public string Name => _prod.Name;
    }
}
