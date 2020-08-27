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
    ///  权限_页面元素 中间表
    ///</summary>
    public class   Tright_Power_Element
    {

       public Tright_Power_Element()
       {
      
       }

        ///<summary>
        ///描述：主键
        ///</summary>
        [Column(IsIdentity = true, IsPrimary = true)]
        public int Id { get; set; }
        ///<summary>
        ///描述：页面元素id
        ///</summary>
        public int Page_Id { get; set; }
        ///<summary>
        ///描述：权限id
        ///</summary>
        public int Power_Id { get; set; }

    }
 }








