using System;
using System.Threading.Tasks;
using CoffeeManager.Models;

namespace CoffeeManagerAdmin.Core
{
    public class SuplyProductsManager
    {
        private SuplyProductsServiceProvider provider = new SuplyProductsServiceProvider();

        public SuplyProductsManager()
        {
        }

        public async Task<SupliedProduct[]> GetSupliedProducts()
        {
            return await provider.GetSupliedProducts();
        }
    }
}
