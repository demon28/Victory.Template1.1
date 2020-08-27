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
    ///  用户&amp;角色 中间表
    ///</summary>
    public class   Tright_User_Role
    {

       public Tright_User_Role()
       {
      
       }

        ///<summary>
        ///描述：主键
        ///</summary>
        [Column(IsIdentity = true, IsPrimary = true)]
        public int Id { get; set; }
        ///<summary>
        ///描述：用户id
        ///</summary>
        public int User_Id { get; set; }
        ///<summary>
        ///描述：角色id
        ///</summary>
        public int Role_Id { get; set; }

    }
 }








