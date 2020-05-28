using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace ElearningWebsite.Localization
{
    public static class ElearningWebsiteLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(ElearningWebsiteConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(ElearningWebsiteLocalizationConfigurer).GetAssembly(),
                        "ElearningWebsite.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
