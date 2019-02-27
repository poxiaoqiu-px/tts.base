using Abp.Domain.Entities;

namespace tts.extends.entityframework
{
    public class BaseEntityWithTenant<TPrimaryKey> : BaseEntity<TPrimaryKey>, IMustHaveTenant
    {
        public int TenantId { get; set; }
    }

    public class BaseEntityWithTenant : BaseEntityWithTenant<int>
    {

    }
}