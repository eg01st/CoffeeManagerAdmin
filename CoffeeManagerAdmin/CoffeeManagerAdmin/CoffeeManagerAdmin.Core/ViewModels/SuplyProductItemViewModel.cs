using System.Windows.Input;
using Acr.UserDialogs;
using CoffeeManager.Models;
using MvvmCross.Core.ViewModels;
using System.Threading.Tasks;
using System;

namespace CoffeeManagerAdmin.Core.ViewModels
{
    public class SuplyProductItemViewModel : ViewModelBase
    {
        private SupliedProduct _item;
        private ICommand _selectCommand;
        private ICommand _requestSuplyCommand;

        public ICommand SelectCommand => _selectCommand;
        public ICommand RequestSuplyCommand => _requestSuplyCommand;

        private bool isDialodShown;

        public SuplyProductItemViewModel(SupliedProduct product)
        {
            _item = product;
            _selectCommand = new MvxCommand(DoShowDetails);
            _requestSuplyCommand = new MvxCommand(DoRequestSuply);
        }

        private void DoShowDetails()
        {
            ShowViewModel<SuplyProductDetailsViewModel>(new { id = _item.Id });
        }

        public string Name => _item.Name;

        public decimal Price => _item.Price;

        public string Quatity => _item.Quatity?.ToString("F");

        protected virtual void DoRequestSuply()
        {
            if (!isDialodShown)
            {
                isDialodShown = true;
                UserDialogs.Prompt(new PromptConfig
                {
                    Title = "Заказать товар",
                    Message = "Введите количество",
                    OnAction = OnAction,
                    InputType = InputType.DecimalNumber
                });
            }

        }

        private void OnAction(PromptResult promptResult)
        {
            if (promptResult.Ok)
            {
                var manager = new SuplyProductsManager();
                Task.Run(async () => await manager.AddNewSuplyRequest(new[] { new SupliedProduct() { Id = _item.Id, CoffeeRoomNo = Config.CoffeeRoomNo, Quatity = decimal.Parse(promptResult.Text) } }));
            }
            isDialodShown = false;
        }
    }
}
