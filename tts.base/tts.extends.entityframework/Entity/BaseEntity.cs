using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;

namespace tts.extends.entityframework
{
    public class BaseEntity<TPrimaryKey> : Entity<TPrimaryKey>, ISoftDelete
    {
        public BaseEntity()
        {
            DeleteFlag = "";
        }

        /// <summary>
        /// 版本
        /// </summary>
        [Column(nameof(Version), TypeName = "timestamp"), ConcurrencyCheck]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime Version { get; set; }

        [Column("ID")]
        [Description("唯一标识")]
        public override TPrimaryKey Id { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
        [Column("CreateUser")]
        [MaxLength(20)]
        [Description("创建人")]
        public string CreateUser { get; set; } = "";

        /// <summary>
        /// 最后修改人
        /// </summary>
        [Column("ModifyUser")]
        [MaxLength(20)]
        [Description("最后修改人")]
        public string ModifyUser { get; set; } = "";

        /// <summary>
        /// 新增时间
        /// </summary>
        [Column("CreateTime")]
        [Description("新增时间")]
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        [Column("ModifyTime")]
        [Description("修改时间")]
        public DateTime? ModifyTime { get; set; }

        /// <summary>
        /// 删除标识 
        /// </summary>
        [Column("DeleteFlag")]
        [MaxLength(1)]
        [Description("删除标识")]
        public virtual string DeleteFlag { get; set; } = "";
    }

    public class BaseEntity : BaseEntity<int>
    {

    }
}