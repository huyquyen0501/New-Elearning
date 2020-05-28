using System.Threading.Tasks;
using ElearningWebsite.Configuration.Dto;

namespace ElearningWebsite.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
