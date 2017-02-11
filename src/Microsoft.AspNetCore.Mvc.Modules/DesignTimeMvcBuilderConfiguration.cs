using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Orchard.Cms.Web
{
    public class DesignTimeMvcBuilderConfiguration : IDesignTimeMvcBuilderConfiguration
    {
        public void ConfigureMvc(IMvcBuilder builder)
        {
            var serviceProvider = builder.Services.BuildServiceProvider();
            var env = serviceProvider.GetRequiredService<IHostingEnvironment>();

            var services = new ServiceCollection();
            services.AddSingleton<IHostingEnvironment>(env);

            serviceProvider = services.BuildServiceProvider();
            var loggerFactory = serviceProvider.GetRequiredService<ILoggerFactory>();

            //builder.ConfigureApplicationPartManager(apm =>
            //{
            //    var extensionLibraryService = serviceProvider.GetRequiredService<IExtensionLibraryService>();
            //    apm.FeatureProviders.Add(
            //        new ExtensionMetadataReferenceFeatureProvider(extensionLibraryService.MetadataPaths.ToArray()));
            //});
        }
    }
}