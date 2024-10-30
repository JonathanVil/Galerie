using Microsoft.AspNetCore.Identity;

namespace Galerie.Infrastructure.Identity;

public class ApplicationRole : IdentityRole<Guid>
{
    public ApplicationRole(string roleName) : base(roleName)
    {
        
    }
}