using Abp.Modules;
using Abp.Reflection.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace tts.business.application
{
    public class BusinessApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            // base.PreInitialize();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(BusinessApplicationModule).GetAssembly());
        }
    }
}
