using System;
using System.Threading.Tasks;
using CoffeeManager.Models;
using CoffeeManagerAdmin.Core.ServiceProviders;
namespace CoffeeManagerAdmin.Core
{
    public class SuplyProductsServiceProvider : BaseServiceProvider
    {
        private const string SuplyProducts = "suplyproducts";
        public SuplyProductsServiceProvider()
        {
        }

        public async Task<SupliedProduct[]> GetSupliedProducts()
        {
            return await Get<SupliedProduct[]>($"{SuplyProducts}/getproducts");
        }
    }
}
