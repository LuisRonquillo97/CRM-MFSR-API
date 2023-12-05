using Entities.Models.Users;
using Microsoft.AspNetCore.Authorization;
using Security.Requirements;
using Services.Interfaces;
using System.Security.Claims;

namespace Security.Handlers
{
    public class ByNameHandler : AuthorizationHandler<ByNameRequirement>
    {
        private readonly IRoleService service;
        private readonly string permissionKey = "users.see";
        public ByNameHandler(IRoleService service)
        {
            this.service = service;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, ByNameRequirement requirement)
        {
            context.User.Claims.Where(x => x.Type.Equals(ClaimTypes.Role)).ToList().ForEach(x =>
            {
                if (service.RoleHasPermission(Guid.Parse(x.Value), requirement.Name))
                {
                    context.Succeed(requirement);
                }
            });
            return Task.CompletedTask;
        }
    }
}
