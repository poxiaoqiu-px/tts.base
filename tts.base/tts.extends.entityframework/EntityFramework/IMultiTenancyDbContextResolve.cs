using System;

namespace tts.extends.entityframework
{
    public interface IMultiTenancyDbContextResolve
    {
        bool IsMainDbContext(Type type);
    }
}