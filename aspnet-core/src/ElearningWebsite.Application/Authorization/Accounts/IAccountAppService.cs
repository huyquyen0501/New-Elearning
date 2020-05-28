using System.Threading.Tasks;
using Abp.Application.Services;
using ElearningWebsite.Authorization.Accounts.Dto;

namespace ElearningWebsite.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
