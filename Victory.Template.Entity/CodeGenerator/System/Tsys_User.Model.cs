using FreeSql.DataAnnotations;
using System;
using Victory.Template.Entity.Enums;

namespace Victory.Template.Entity.CodeGenerator
{
    /// <summary>
    ///  
    ///</summary>
    public class Tsys_User
    {
        public Tsys_User()
        {

        }

        ///<summary>
        ///描述：
        ///</summary>
        [Column(IsIdentity = true, IsPrimary = true)]
        public int Id { get; set; }
        ///<summary>
        ///描述：用户名
        ///</summary>
        public string Name { get; set; }
        ///<summary>
        ///描述：密码
        ///</summary>
        public string Pwd { get; set; }
        ///<summary>
        ///描述：工号
        ///</summary>
        public string Workid { get; set; }
        ///<summary>
        ///描述：手机
        ///</summary>
        public string Phone { get; set; }
        ///<summary>
        ///描述：状态{0：在职，1：离职}
        ///</summary>
        public int Status { get; set; }
        ///<summary>
        ///描述：性别，{0：男，1：女}
        ///</summary>
        public int Sex { get; set; }
        ///<summary>
        ///描述：
        ///</summary>
        public string Dep1 { get; set; }
        ///<summary>
        ///描述：
        ///</summary>
        public string Dep2 { get; set; }
        ///<summary>
        ///描述：
        ///</summary>
        public string Dep3 { get; set; }
        ///<summary>
        ///描述：
        ///</summary>
        public string Dep4 { get; set; }
        ///<summary>
        ///描述：
        ///</summary>
        public string Dep5 { get; set; }
        ///<summary>
        ///描述：职位
        ///</summary>
        public string Dtname { get; set; }
        ///<summary>
        ///描述：创建时间
        ///</summary>
        public DateTime Createtime { get; set; }
        ///<summary>
        ///描述：
        ///</summary>
        public string Remarks { get; set; }
        ///<summary>
        ///描述：入职时间
        ///</summary>
        public DateTime Comedate { get; set; }
        ///<summary>
        ///描述：是否项目成员
        ///</summary>
        public IsAdmin Isadmin { get; set; }
    }
}