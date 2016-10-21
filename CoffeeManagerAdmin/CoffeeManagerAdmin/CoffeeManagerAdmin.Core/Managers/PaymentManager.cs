﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeManager.Models;
using CoffeeManagerAdmin.Core.ServiceProviders;

namespace CoffeeManagerAdmin.Core.Managers
{
    public class PaymentManager : BaseManager
    {
        PaymentProvider provider = new PaymentProvider();
        public async Task<Expense[]> GetShiftExpenses(int id)
        {
            return await provider.GetShiftExpenses(id);
        }
    }
}