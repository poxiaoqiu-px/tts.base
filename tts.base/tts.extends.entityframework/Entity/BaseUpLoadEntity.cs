using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace tts.extends.entityframework
{
    public class BaseUpLoadEntity<TPrimaryKey> : BaseEntityWithTenant<TPrimaryKey>
    {
        /// <summary>
        /// 是否上传
        /// </summary>
        [Column("IsUpLoaded")]
        [Description("是否上传")]
        public bool IsUpLoaded { get; set; } = false;

        /// <summary>
        /// 重试次数
        /// </summary>
        [Column("ReTryTime")]
        [Description("重试次数")]
        public int ReTryTime { get; set; } = 0;

        /// <summary>
        /// 上传成功时间
        /// </summary>		
        [Column("AcceptTime")]
        [Description("上传成功时间")]
        public DateTime? SuccessTime { get; set; }
    }


    public class BaseUpLoadEntity : BaseUpLoadEntity<int>
    {

    }
}