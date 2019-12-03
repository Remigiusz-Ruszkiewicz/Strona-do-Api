using System;
using System.Collections.Generic;

using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using StoreApp.Models;

namespace StoreApp.Services
{
    public class UserService : IUserService
    {

        public async Task<string> LoginAsync(UserViewModel userViewModel)
        {
            var httpClient = new HttpClient();
            var response = await httpClient.PostAsJsonAsync("http://localhost:27527/api/v1/users/login", userViewModel);
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                return null;
            }
            var authSucces = await response.Content.ReadAsAsync<AuthSucces>();
            return authSucces.Token;
        }
        
    }
}
