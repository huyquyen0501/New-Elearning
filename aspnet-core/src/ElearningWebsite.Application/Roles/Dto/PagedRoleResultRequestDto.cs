using Abp.Application.Services.Dto;

namespace ElearningWebsite.Roles.Dto
{
    public class PagedRoleResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}

