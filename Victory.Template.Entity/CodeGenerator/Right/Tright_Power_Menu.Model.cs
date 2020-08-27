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
    ///  权限&amp;菜单中间表
    ///</summary>
    public class   Tright_Power_Menu
    {

       public Tright_Power_Menu()
       {
      
       }

        ///<summary>
        ///描述：主键id
        ///</summary>
        [Column(IsIdentity = true, IsPrimary = true)]
        public int Id { get; set; }
        ///<summary>
        ///描述：菜单id
        ///</summary>
        public int Menu_Id { get; set; }
        ///<summary>
        ///描述：权限id
        ///</summary>
        public int Power_Id { get; set; }

    }
 }








