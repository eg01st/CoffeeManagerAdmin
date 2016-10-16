﻿using System;
using System.Collections.Generic;
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

        public async Task AddNewProduct(string newProduct)
        {
            await provider.AddNewProduct(newProduct);
        }

        public async Task AddNewSuplyRequest(IEnumerable<SupliedProduct> items)
        {
            await provider.AddNewSuplyRequest(items);
        }
    }
}
