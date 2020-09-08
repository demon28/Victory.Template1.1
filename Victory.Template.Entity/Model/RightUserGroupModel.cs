using System;
using System.Collections.Generic;
using System.Text;
using Victory.Template.Entity.CodeGenerator;

namespace Victory.Template.Entity.Model
{
   public class RightUserGroupModel: Tsys_User
    {

        /// <summary>
        /// 中间表Tright_user_Group 的主键id
        /// </summary>
        public int UserGroup_Id { get; set; }

        /// <summary>
        /// 组id
        /// </summary>
        public int Group_Id { get; set; }

        /// <summary>
        /// 用户组，组名
        /// </summary>
        public string Group_Name { get; set; }

    }
}
