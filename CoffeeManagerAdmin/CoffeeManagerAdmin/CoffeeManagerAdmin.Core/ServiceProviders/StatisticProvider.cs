using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CoffeeManager.Models;

namespace CoffeeManagerAdmin.Core.ServiceProviders
{
    public class StatisticProvider : BaseServiceProvider
    {
        private const string Statistic = "statistic";

        public StatisticProvider()
        {
        }

        public async Task<IEnumerable<Expense>> GetExpenses(DateTime from, DateTime to)
        {
            return await Get<Expense[]>($"{Statistic}/getExpenses", new Dictionary<string, string>()
            {
                { nameof(from), from.ToString()},
                { nameof(to), to.ToString()}
            });
        }

        public async Task<IEnumerable<SaleInfo>> GetSales(DateTime from, DateTime to)
        {
            return await Get<SaleInfo[]>($"{Statistic}/getAllSales", new Dictionary<string, string>()
            {
                { nameof(from), from.ToString()},
                { nameof(to), to.ToString()}
            });
        }
    }
}
