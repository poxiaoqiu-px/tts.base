using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using tts.business.core.Base;

namespace tts.business.core
{
    public class User : EntityBase
    {/// <summary>
     /// 用户名
     /// </summary>
        [StringLength(24, MinimumLength = 6, ErrorMessage = "字符长度必须6-24之间")]
        public string UserName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [StringLength(32, MinimumLength = 6, ErrorMessage = "字符长度必须6-32之间")]
        public string Password { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public Sex Sex { get; set; } = Sex.secret;

        /// <summary>
        /// 角色Id （外键）
        /// </summary>
        public int RoleId { get; set; }
        /// <summary>
        /// 角色实体 （导航属性）
        /// </summary>
        public Role Role { get; set; }
    }

    /// <summary>
    /// 性别 （枚举类型）
    /// </summary>
    public enum Sex { man, woman, secret }
}
