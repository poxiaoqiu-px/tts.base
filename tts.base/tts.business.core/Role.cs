using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using tts.business.core.Base;

namespace tts.business.core
{
    public class Role : EntityBase
    {
        /// <summary>
        /// 角色名称
        /// </summary>
        [Required(ErrorMessage = "不能为空")]
        public string RoleName { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 用户实体集合 （导航属性）
        /// </summary>
        public ICollection<User> Users { get; set; }
    }
}
