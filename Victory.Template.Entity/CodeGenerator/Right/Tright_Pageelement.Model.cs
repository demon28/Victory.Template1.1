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
    ///  
    ///</summary>
    public class   Tright_PageElement
    {

       public Tright_PageElement()
       {
      
       }

        ///<summary>
        ///描述：主键
        ///</summary>
        [Column(IsIdentity = true, IsPrimary = true)]
        public int Id { get; set; }
        ///<summary>
        ///描述：界面元素
        ///</summary>
        public string Element_Name { get; set; }
        ///<summary>
        ///描述：状态{0：正常，1：禁用}
        ///</summary>
        public int Status { get; set; }

    }
 }








