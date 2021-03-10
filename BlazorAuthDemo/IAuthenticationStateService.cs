using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BlazorAuthDemo
{
    public interface IAuthenticationStateService
    {
        Task<AuthenticationState> Get();
    }

    public class FakeAuthenticationStateService : IAuthenticationStateService
    {
        public async Task<AuthenticationState> Get()
        {
            Console.WriteLine($"Start IAuthenticationStateService.Get");

            //Assume we attach the jwt token and validate it in server side
            await Task.Delay(2000);

            Console.WriteLine($"End IAuthenticationStateService.Get");

            return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity("jwt")));
        }
    }
}
