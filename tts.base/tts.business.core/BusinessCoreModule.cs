using Abp.Modules;
using Abp.Reflection.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace tts.business.core
{
    public class BusinessCoreModule : AbpModule
    {
        public override void PreInitialize()
        {
            // base.PreInitialize();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(BusinessCoreModule).GetAssembly());
        }
    }
}
