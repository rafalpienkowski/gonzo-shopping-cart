using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Polly;
using ShoppingCart.Contract;
using ShoppingCart.Domain;

namespace ShoppingCart.Concrete
{
    public class ProductCatalogClient: IProductCatalogClient
    {
        private readonly string _baseUrl = "https://localhost:5002";

        public async Task<IEnumerable<Item>> GetProductCartItemsAsync(IEnumerable<int> productCatalogIds)
        {
            var response = await RequestProductFromProductCataloge(productCatalogIds);
            return await ConvertToItem(response);
        }

        private async Task<HttpResponseMessage> RequestProductFromProductCataloge(IEnumerable<int> productIds)
        {
            var expotentialRetryPolicy = Policy.Handle<Exception>()
                .WaitAndRetryAsync(3, attempt => TimeSpan.FromMilliseconds(100 * Math.Pow(2, attempt)));
            
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(_baseUrl);

                return await expotentialRetryPolicy.ExecuteAsync(async () =>
                {
                    var response = await httpClient.GetAsync($"/products?productIds=[{string.Join(",", productIds)}]");
                    response.EnsureSuccessStatusCode();
                    return response;
                });
            }
        }

        private static async Task<IEnumerable<Item>> ConvertToItem(HttpResponseMessage responseMessage)
        {
            var products = JsonConvert.DeserializeObject<List<ProductCatalogProduct>>(
                await responseMessage.Content.ReadAsStringAsync()
            );

            return products.Select(p => new Item(int.Parse(p.ProductId), p.ProductName, p.ProductDescription, p.Price));
        }

        private class ProductCatalogProduct
        {
            public string ProductId { get; set; }
            public string ProductName { get; set; }
            public string ProductDescription { get; set; }
            public Money Price { get; set; }
        }
    }
}