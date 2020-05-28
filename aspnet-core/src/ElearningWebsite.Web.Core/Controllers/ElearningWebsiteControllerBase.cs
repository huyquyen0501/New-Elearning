using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace ElearningWebsite.Controllers
{
    public abstract class ElearningWebsiteControllerBase: AbpController
    {
        protected ElearningWebsiteControllerBase()
        {
            LocalizationSourceName = ElearningWebsiteConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
