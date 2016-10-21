using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeManager.Models;
using CoffeeManagerAdmin.Core.ServiceProviders;

namespace CoffeeManagerAdmin.Core.Managers
{
    public class ShiftManager
    {
        private ShiftServiceProvider provider = new ShiftServiceProvider();
        public async Task<Shift> GetCurrentShift()
        {
            return await provider.GetCurrentShift();
        }
        public async Task<decimal> GetEntireMoney()
        {
            return await provider.GetEntireMoney();
        }

        public async Task<ShiftInfo[]> GetShifts()
        {
            return await provider.GetShifts();
        }

        public async Task<Sale[]> GetShiftSales(int id)
        {
            return await provider.GetShiftSales(id);
        }
    }
}
