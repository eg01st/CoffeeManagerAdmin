﻿using System;
using System.Threading.Tasks;
using CoffeeManager.Models;
using CoffeeManagerAdmin.Core.ServiceProviders;
namespace CoffeeManagerAdmin.Core
{
    public class ProductProvider : BaseServiceProvider
    {
        public ProductProvider()
        {
        }

        public async Task AddProduct(Product product)
        {
            await Put("products/addproduct", product);
        }


        public async Task DeleteProduct(int id)
        {
            await Delete("products/deleteproduct", new System.Collections.Generic.Dictionary<string, string>() { { nameof(id), id.ToString() } });
        }
    }
}
