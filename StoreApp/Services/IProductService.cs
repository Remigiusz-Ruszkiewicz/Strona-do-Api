using StoreApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreApp.Services
{
    public interface IProductService
    {
        Task<ICollection<ProductsViewModel>> GetAllAsync();
    }
}
