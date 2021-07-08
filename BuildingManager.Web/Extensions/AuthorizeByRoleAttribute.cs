using Microsoft.AspNetCore.Authorization;

namespace BuildingManager.Web.Extensions
{
    public class AuthorizeByRoleAttribute:AuthorizeAttribute
    {
        public AuthorizeByRoleAttribute(params string[] roles)
        {
            Roles = string.Join(",",roles);
        }
    }
}