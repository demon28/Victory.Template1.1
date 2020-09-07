using System;
using System.Collections.Generic;
using System.Text;
using Victory.Template.Entity.CodeGenerator;

namespace Victory.Template.Entity.Model
{
   public class RightUserGroupModel: Tsys_User
    {

        /// <summary>
        /// 用户组，组名
        /// </summary>
        public string Group_Name { get; set; }

    }
}
