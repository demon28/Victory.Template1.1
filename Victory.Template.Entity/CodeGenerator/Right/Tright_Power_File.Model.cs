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
    ///  权限&amp;文件中间表
    ///</summary>
    public class   Tright_Power_File
    {

       public Tright_Power_File()
       {
      
       }

        ///<summary>
        ///描述：主键
        ///</summary>
        [Column(IsIdentity = true, IsPrimary = true)]
        public int Id { get; set; }
        ///<summary>
        ///描述：文件表id
        ///</summary>
        public int File_Id { get; set; }
        ///<summary>
        ///描述：权限表id
        ///</summary>
        public int Power_Id { get; set; }

    }
 }








