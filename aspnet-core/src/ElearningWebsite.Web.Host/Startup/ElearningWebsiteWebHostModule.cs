using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using ElearningWebsite.Configuration;

namespace ElearningWebsite.Web.Host.Startup
{
    [DependsOn(
       typeof(ElearningWebsiteWebCoreModule))]
    public class ElearningWebsiteWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public ElearningWebsiteWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(ElearningWebsiteWebHostModule).GetAssembly());
        }
    }
}
