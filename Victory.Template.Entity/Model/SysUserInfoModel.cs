using System;
using System.Collections.Generic;
using System.Text;
using Victory.Template.Entity.CodeGenerator;

namespace Victory.Template.Entity.Model
{
   public class SysUserInfoModel
    {

        /// <summary>
        /// 用户id
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 工号
        /// </summary>
        public string WorkId { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
         public int Sex { get; set; }

        /// <summary>
        /// 菜单
        /// </summary>
        public List<Tright_Menu> Menu { get; set; }
    }
}
