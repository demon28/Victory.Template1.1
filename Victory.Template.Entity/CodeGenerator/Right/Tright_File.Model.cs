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
    ///  文件表
    ///</summary>
    public class   Tright_File
    {

       public Tright_File()
       {
      
       }

        ///<summary>
        ///描述：主键
        ///</summary>
        [Column(IsIdentity = true, IsPrimary = true)]
        public int Id { get; set; }
        ///<summary>
        ///描述：文件名
        ///</summary>
        public string File_Name { get; set; }
        ///<summary>
        ///描述：文件地址
        ///</summary>
        public string File_Url { get; set; }
        ///<summary>
        ///描述：状态{0：正常，1：禁用}
        ///</summary>
        public int Status { get; set; }

    }
 }








