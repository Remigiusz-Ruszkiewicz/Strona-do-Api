using System;
using System.Collections.Generic;
using System.Linq;

using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using StoreApp.Helpers;
using StoreApp.Models;

namespace StoreApp.Services
{
    public class ProductService : IProductService
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly HttpClient httpClient;


        public ProductService(IHttpContextAccessor httpContextAccessor,IHttpClientFactory httpClientFactory,IOptions<StoreApi> options)
        {
            this.httpContextAccessor = httpContextAccessor;
            this.httpClient = httpClientFactory.CreateClient();
            httpClient.BaseAddress = new Uri(options.Value.Address);
        }


        public async Task<ICollection<ProductsViewModel>> GetAllAsync()
        {
            var token = httpContextAccessor.HttpContext.Request.Cookies["Token"];
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",token);
            var response = await httpClient.GetAsync("/api/v1/products");
            var products = await response.Content.ReadAsAsync<ICollection<ProductsViewModel>>();
            return products;
        }
    }
}
