using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeManager.Models;
using CoffeeManagerAdmin.Core.Managers;

namespace CoffeeManagerAdmin.Core.ViewModels
{
    public class ShiftDetailsViewModel : ViewModelBase
    {
        private int _shiftId;
        private ShiftManager shiftManager = new ShiftManager();
        private PaymentManager paymentManager = new PaymentManager();
        private CupsManager cupsManager = new CupsManager();
        private string _c110;
        private string _c170;
        private string _c250;
        private string _c400;
        private string _plastic;
        private List<ExpenseItemViewModel> _expenseItems = new List<ExpenseItemViewModel>();
        private List<SaleItemViewModel> _saleItems = new List<SaleItemViewModel>();

        public async void Init(int id)
        {
            _shiftId = id;

            await cupsManager.GetShiftUsedCups(_shiftId).ContinueWith(task =>
            {
                var cups = task.Result;
                C110 = cups.C110.ToString();
                C170 = cups.C170.ToString();
                C250 = cups.C250.ToString();
                C400 = cups.C400.ToString();
                Plastic = cups.Plastic.ToString();
            });

            var items = await paymentManager.GetShiftExpenses(_shiftId);
            ExpenseItems = items.Select(s => new ExpenseItemViewModel(s)).ToList();

            var saleItems = await shiftManager.GetShiftSales(_shiftId);
            SaleItems = saleItems.Select(s => new SaleItemViewModel(s)).ToList();
        }

        public List<ExpenseItemViewModel> ExpenseItems
        {
            get { return _expenseItems; }
            set
            {
                _expenseItems = value;
                RaisePropertyChanged(nameof(ExpenseItems));
            }
        }

        public List<SaleItemViewModel> SaleItems
        {
            get { return _saleItems; }
            set
            {
                _saleItems = value;
                RaisePropertyChanged(nameof(SaleItems));
            }
        }

        public string C110
        {
            get { return _c110; }
            set
            {
                _c110 = value;
                RaisePropertyChanged(nameof(C110));
            }
        }
        public string C170
        {
            get { return _c170; }
            set
            {
                _c170 = value;
                RaisePropertyChanged(nameof(C170));
            }
        }
        public string C250
        {
            get { return _c250; }
            set
            {
                _c250 = value;
                RaisePropertyChanged(nameof(C250));
            }
        }
        public string C400
        {
            get { return _c400; }
            set
            {
                _c400 = value;
                RaisePropertyChanged(nameof(C400));
            }
        }
        public string Plastic
        {
            get { return _plastic; }
            set
            {
                _plastic = value;
                RaisePropertyChanged(nameof(Plastic));
            }
        }
    }
}
