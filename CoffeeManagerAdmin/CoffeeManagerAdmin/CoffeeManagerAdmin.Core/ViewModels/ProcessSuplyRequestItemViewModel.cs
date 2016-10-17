using Acr.UserDialogs;

namespace CoffeeManagerAdmin.Core.ViewModels
{
    public class ProcessSuplyRequestItemViewModel : RequestSuplyItemViewModel
    {
        protected override void DoSelect()
        {
            if (!IsSelected)
            {
                UserDialogs.Prompt(new PromptConfig
                {
                    Message = "Введите цену",
                    OnAction = OnAction,
                    InputType = InputType.Number,
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
