using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffeeManagerAdmin.Core.Managers;
using CoffeeManagerAdmin.Core.Messages;

namespace CoffeeManagerAdmin.Core.ViewModels.Orders
{
    public class OrdersViewModel : ViewModelBase
    {
        private SuplyOrderManager _manager = new SuplyOrderManager();
        private MvxSubscriptionToken _token;

        private List<OrderViewModel> _items = new List<OrderViewModel>();

        public OrdersViewModel()
        {
            _token = Subscribe<OrderListChangedMessage>(async (a) => await LoadData());
        }

        public List<OrderViewModel> Items
        {
            get { return _items; }
            set
            {
                _items = value;
                RaisePropertyChanged(nameof(Items));
            }
        }

        public async void Init()
        {
            await LoadData();
        }

        private async Task LoadData()
        {
            var items = await _manager.GetOrders();
            Items = items.Select(s => new OrderViewModel(s)).ToList();
        }
    }
}
