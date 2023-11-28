using Microsoft.AspNetCore.Authorization;

namespace Security.Requirements
{
    public class ByNameRequirement : IAuthorizationRequirement
    {
        public ByNameRequirement(string name)
        {
            Name = name;
        }

        public string Name { get; }
    }
}
