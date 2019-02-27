using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace tts.business.core.Base
{
    public abstract class EntityBase<TKey>
    {
        /// <summary>
        /// 主键Id (主键类型根据继承时确定)
        /// </summary>
        public TKey Id { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; } = DateTime.Now;

        /// <summary>
        /// 是否删除  （逻辑删除而非物理删除）
        /// </summary>
        public bool IsDelete { get; set; } = false;

        /// <summary>
        /// 行版本 （时间戳处理并发）
        /// </summary>
        [Timestamp]
        public byte[] RowVersion { get; set; }
    }

    public abstract class EntityBase : EntityBase<int>
    { }

}
