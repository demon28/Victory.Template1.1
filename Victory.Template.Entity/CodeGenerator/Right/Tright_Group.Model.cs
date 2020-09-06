//----------------
//DA  v1.1
//2020-7-31
//Near
//---------------

using FreeSql.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;

namespace Victory.Template.Entity.CodeGenerator
{
    /// <summary>
    ///  用户组表
    ///</summary>
    public class   Tright_Group
    {

       public Tright_Group()
       {
      
       }

        ///<summary>
        ///描述：主键
        ///</summary>
        [Column(IsIdentity = true, IsPrimary = true)]
        public int Id { get; set; }
        ///<summary>
        ///描述：组名
        ///</summary>
        public string Group_Name { get; set; }
        ///<summary>
        ///描述：父id
        ///</summary>
        public int Parent_Id { get; set; }
        ///<summary>
        ///描述：状态{0：正常，1：禁用}
        ///</summary>
        public int Status { get; set; }


        [Navigate(nameof(Parent_Id))]
        [JsonIgnore]
        public Tright_Power Parent { get; set; }

        [Navigate(nameof(Parent_Id))]
        public List<Tright_Group> Childs { get; set; }

    }
 }








