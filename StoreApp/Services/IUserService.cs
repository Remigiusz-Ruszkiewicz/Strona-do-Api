using StoreApp.Models;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Threading.Tasks;

namespace StoreApp.Services
{
    public interface IUserService
    {
        Task<string> LoginAsync(UserViewModel userViewModel);
    }

}
