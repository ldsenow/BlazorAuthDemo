using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BlazorAuthDemo
{
    public class RemoteAuthorizationService : DefaultAuthorizationService
    {
        private readonly IAuthenticationStateService authenticationStateService;

        public RemoteAuthorizationService(
            IAuthenticationStateService authenticationStateService,
            IAuthorizationPolicyProvider policyProvider,
            IAuthorizationHandlerProvider handlers,
            ILogger<DefaultAuthorizationService> logger,
            IAuthorizationHandlerContextFactory contextFactory,
            IAuthorizationEvaluator evaluator,
            IOptions<AuthorizationOptions> options) : base(policyProvider, handlers, logger, contextFactory, evaluator, options)
        {
            this.authenticationStateService = authenticationStateService;
        }

        public override async Task<AuthorizationResult> AuthorizeAsync(ClaimsPrincipal user, object resource, IEnumerable<IAuthorizationRequirement> requirements)
        {
            // Make sure we get the validated identity from server side
            // e.g. in case of user is disabled after the access token is issued
            var principal = await authenticationStateService.Get();

            return await base.AuthorizeAsync(principal.User, resource, requirements);
        }

        public override async Task<AuthorizationResult> AuthorizeAsync(ClaimsPrincipal user, object resource, string policyName)
        {
            var principal = await authenticationStateService.Get();

            return await base.AuthorizeAsync(principal.User, resource, policyName);
        }
    }
}
