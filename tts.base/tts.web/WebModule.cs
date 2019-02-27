using Abp.AspNetCore;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tts.business.application;
using tts.business.entityframework;

namespace tts.web
{
    [DependsOn(
        typeof(BusinessApplicationModule),
        typeof(BusinessEntityFrameworkModule),
        typeof(AbpAspNetCoreModule))]
    public class WebModule : AbpModule
    {
        public override void PreInitialize()
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            var config = builder.Build();
            Configuration.DefaultNameOrConnectionString = config.GetConnectionString("Default");
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(WebModule).GetAssembly());
        }
    }
}
