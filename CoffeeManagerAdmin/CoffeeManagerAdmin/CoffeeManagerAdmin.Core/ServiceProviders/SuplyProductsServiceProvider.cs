using System;
using System.Collections.Generic;
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

        public async Task AddNewProduct(string newProduct)
        {
            await
                Put($"{SuplyProducts}/addproduct",
                    new SupliedProduct() {CoffeeRoomNo = CoffeeRoomNo, Amount = 0, Price = 0, Name = newProduct});
        }

        public async Task AddNewSuplyRequest(IEnumerable<SupliedProduct> items)
        {
            await Post($"{SuplyProducts}/addsuplyrequest", items);
        }
    }
}
