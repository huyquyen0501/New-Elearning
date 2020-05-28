using System.Threading.Tasks;
using Abp.Application.Services;
using ElearningWebsite.Sessions.Dto;

namespace ElearningWebsite.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
