using Abp.Application.Services;
using ElearningWebsite.MultiTenancy.Dto;

namespace ElearningWebsite.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

