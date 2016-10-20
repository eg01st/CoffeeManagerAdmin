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
        private CupsManager cupsManager = new CupsManager();
        private string _c110;
        private string _c170;
        private string _c250;
        private string _c400;
        private string _plastic;

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
