using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Threading.Tasks;

namespace BlazorAuthDemo
{
    public class RemoteAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly IAuthenticationStateService authenticationStateService;

        public RemoteAuthenticationStateProvider(IAuthenticationStateService authenticationStateService)
        {
            this.authenticationStateService = authenticationStateService;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            Console.WriteLine($"Start RemoteAuthenticationStateProvider.GetAuthenticationStateAsync");

            var state = await authenticationStateService.Get();

            Console.WriteLine($"End RemoteAuthenticationStateProvider.GetAuthenticationStateAsync");

            return state;
        }
    }
}
