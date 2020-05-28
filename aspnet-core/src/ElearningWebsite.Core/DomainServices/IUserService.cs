using ElearningWebsite.Authorization.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ElearningWebsite.DomainServices
{
    public interface IUserService
    {
        IQueryable<User> GetUserByRole(string roleName);
        bool UserHasRole(long userId, string roleName);
    }
}
