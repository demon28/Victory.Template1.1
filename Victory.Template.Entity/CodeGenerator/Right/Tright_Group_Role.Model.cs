//----------------
//DA  v1.1
//2020-7-31
//Near
//---------------

using FreeSql.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;


namespace Victory.Template.Entity.CodeGenerator
{
    /// <summary>
    ///  用户组_角色中间表
    ///</summary>
    public class   Tright_Group_Role
    {

       public Tright_Group_Role()
       {
      
       }

        ///<summary>
        ///描述：主键
        ///</summary>
        [Column(IsIdentity = true, IsPrimary = true)]
        public int Id { get; set; }
        ///<summary>
        ///描述：组id
        ///</summary>
        public int Group_Id { get; set; }
        ///<summary>
        ///描述：角色id
        ///</summary>
        public int Role_Id { get; set; }

    }
 }








