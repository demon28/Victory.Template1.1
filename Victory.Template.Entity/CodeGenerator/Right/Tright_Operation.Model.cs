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
    public class   Tright_Operation
    {

       public Tright_Operation()
       {
      
       }

        ///<summary>
        ///描述：主键
        ///</summary>
        [Column(IsIdentity = true, IsPrimary = true)]
        public int Id { get; set; }
        ///<summary>
        ///描述：编号
        ///</summary>
        public string Code { get; set; }
        ///<summary>
        ///描述：域
        ///</summary>
        public string Area { get; set; }
        ///<summary>
        ///描述：控制器
        ///</summary>
        public string Controller { get; set; }
        ///<summary>
        ///描述：行为
        ///</summary>
        public string Action { get; set; }
        ///<summary>
        ///描述：地址
        ///</summary>
        public string Url { get; set; }
        ///<summary>
        ///描述：排序id
        ///</summary>
        public int Sortid { get; set; }
        ///<summary>
        ///描述：状态{0：正常，1：禁用}
        ///</summary>
        public int Status { get; set; }
        ///<summary>
        ///描述：父id
        ///</summary>
        public int Parent_Id { get; set; }

    }
 }








