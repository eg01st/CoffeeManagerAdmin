using System;
using System.Collections.Generic;
using CoffeeManager.Models;
namespace CoffeeManagerAdmin.Core
{
    public class SalesChartViewModel : ViewModelBase
    {
        public SalesChartViewModel()
        {
        }

        public void Init(Guid id)
        {
            IEnumerable<string> itemsNames;
            ParameterTransmitter.TryGetParameter(id, out itemsNames);
            
        }
    }
}
