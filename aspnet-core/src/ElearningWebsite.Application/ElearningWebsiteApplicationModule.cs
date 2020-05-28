using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using ElearningWebsite.Authorization;

namespace ElearningWebsite
{
    [DependsOn(
        typeof(ElearningWebsiteCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class ElearningWebsiteApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<ElearningWebsiteAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(ElearningWebsiteApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
