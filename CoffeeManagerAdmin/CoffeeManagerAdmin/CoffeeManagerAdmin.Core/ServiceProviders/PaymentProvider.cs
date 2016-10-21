using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeManager.Models;

namespace CoffeeManagerAdmin.Core.ServiceProviders
{
    public class PaymentProvider : BaseServiceProvider
    {
        public async Task<Expense[]> GetShiftExpenses(int id)
        {
            return await Get<Expense[]>("payment/getShiftExpenses", new Dictionary<string, string>() { { nameof(id), id.ToString() } });
        }
    }
}
