using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using ElearningWebsite.Configuration.Dto;

namespace ElearningWebsite.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : ElearningWebsiteAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
