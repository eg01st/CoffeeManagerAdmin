using System.Windows.Input;
using Acr.UserDialogs;
using CoffeeManager.Models;
using MvvmCross.Core.ViewModels;
using System.Threading.Tasks;

namespace CoffeeManagerAdmin.Core.ViewModels
{
    public class SuplyProductItemViewModel : ViewModelBase
    {
        private SupliedProduct _item;
        private ICommand _selectCommand;

        public ICommand SelectCommand => _selectCommand;

        public SuplyProductItemViewModel(SupliedProduct product)
        {
            _item = product;
            _selectCommand = new MvxCommand(DoSelect);
        }
        public string Name => _item.Name;

        public decimal Price => _item.Price;

        public string Amount => _item.Amount.ToString();

        protected virtual void DoSelect()
        {

            UserDialogs.Prompt(new PromptConfig
            {
                Title = "Заказать товар",
                Message = "Введите количество",
                OnAction = OnAction,
                InputType = InputType.Number
            });

        }

        private void OnAction(PromptResult promptResult)
        {
            if (promptResult.Ok)
            {
                var manager = new SuplyProductsManager();
                Task.Run(async () => await manager.AddNewSuplyRequest(new[] { new SupliedProduct() { Id = _item.Id, CoffeeRoomNo = Config.CoffeeRoomNo, Amount = int.Parse(promptResult.Text) } }));
            }
        }
    }
}
