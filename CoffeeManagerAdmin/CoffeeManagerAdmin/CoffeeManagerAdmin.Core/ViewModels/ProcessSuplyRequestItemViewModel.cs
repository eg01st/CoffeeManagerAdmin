using Acr.UserDialogs;

namespace CoffeeManagerAdmin.Core.ViewModels
{
    public class ProcessSuplyRequestItemViewModel : RequestSuplyItemViewModel
    {
        protected override async void DoSelect()
        {
            IsSelected = !IsSelected;
            if (IsSelected)
            {
                await
                    UserDialogs.PromptAsync(new PromptConfig
                    {
                        Message = "Введите цену",
                        OnAction = OnAction,
                        InputType = InputType.Number,
                        Text = Price
                    });
            }
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
