using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using MvvmCross.Core.ViewModels;
using MvvmCross.Plugins.Messenger;

namespace CoffeeManagerAdmin.Core.ViewModels
{
    public class ProcessRequestSuplyViewModel : ViewModelBase
    {
        MvxSubscriptionToken token;

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
            token = Subscribe<ProcessRequestSuplyListChangedMessage>(async (obj) => await LoadData());
        }

        public async void Init()
        {
            await LoadData();
        }

        private async Task LoadData()
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
                            ItemCount = s.Quatity.ToString()
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
                                Quatity = decimal.Parse(s.ItemCount),
                                Price = decimal.Parse(s.Price)
                            });
            await manager.ProcessSuplyRequests(items);
            Close(this);
        }
    }
}
