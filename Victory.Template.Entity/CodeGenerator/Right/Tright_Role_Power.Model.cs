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
    ///  角色&amp;权限表中间表
    ///</summary>
    public class   Tright_Role_Power
    {

       public Tright_Role_Power()
       {
      
       }

        ///<summary>
        ///描述：主键
        ///</summary>
        [Column(IsIdentity = true, IsPrimary = true)]
        public int Id { get; set; }
        ///<summary>
        ///描述：角色id
        ///</summary>
        public int Role_Id { get; set; }
        ///<summary>
        ///描述：权限id
        ///</summary>
        public int Power_Id { get; set; }

    }
 }








