using Abp.EntityFrameworkCore;
using Abp.Modules;
using Abp.Reflection.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using tts.business.core;

namespace tts.business.entityframework
{
    [DependsOn(typeof(AbpEntityFrameworkCoreModule), typeof(BusinessCoreModule))]
    public class BusinessEntityFrameworkModule : AbpModule
    {
        public override void PreInitialize()
        {
            // base.PreInitialize();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(BusinessEntityFrameworkModule).GetAssembly());
        }
    }
}
