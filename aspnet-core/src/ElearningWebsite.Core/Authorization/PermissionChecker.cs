using Abp.Authorization;
using ElearningWebsite.Authorization.Roles;
using ElearningWebsite.Authorization.Users;

namespace ElearningWebsite.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
