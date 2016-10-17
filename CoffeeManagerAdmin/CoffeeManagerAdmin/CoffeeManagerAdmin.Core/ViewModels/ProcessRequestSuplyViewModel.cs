using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using MvvmCross.Core.ViewModels;

namespace CoffeeManagerAdmin.Core.ViewModels
{
    public class ProcessRequestSuplyViewModel : ViewModelBase
    {
        private SuplyProductsManager manager = new SuplyProductsManager();

        private ICommand _doneCommand;
        private List<ProcessSuplyRequestItemViewModel> _items = new List<ProcessSuplyRequestItemViewModel>();

        public ICommand DoneCommand => _doneCommand;
        public List<ProcessSuplyRequestItemViewModel> Items
        {
            get { return _items; }
            set
            {
                _items = value;
                RaisePropertyChanged(nameof(Items));
            }
        }

        public ProcessRequestSuplyViewModel()
        {
            _doneCommand = new MvxCommand(DoDoneRequest);
        }

        public async void Init()
        {
            var items = await manager.GetSuplyRequests();
            Items =
                items.Select(
                    s =>
                        new ProcessSuplyRequestItemViewModel()
                        {
                            Name = s.Name,
                            Id = s.Id,
                            Price = s.Price.ToString("F"),
                            ItemCount = s.Amount.ToString()
                        }).ToList();
        }

        private async void DoDoneRequest()
        {
            var items =
                Items.Where(i => i.IsSelected)
                    .Select(
                        s =>
                            new CoffeeManager.Models.SupliedProduct()
                            {
                                Id = s.Id,
                                Amount = int.Parse(s.ItemCount),
                                Price = decimal.Parse(s.Price)
                            });
            await manager.ProcessSuplyRequests(items);
            Close(this);
        }
    }
}
