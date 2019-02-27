using Abp.Domain.Entities;

namespace tts.extends.entityframework
{
    public class BaseEntityMayWithTenant<TPrimaryKey> : BaseEntity<TPrimaryKey>, IMayHaveTenant
    {
        public int? TenantId { get; set; }
    }

    public class BaseEntityMayWithTenant : BaseEntityMayWithTenant<int>
    {

    }
}