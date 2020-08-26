//----------------
//DA  v1.1
//2020-7-31
//Near
//---------------

using FreeSql.DataAnnotations;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;


namespace Victory.Template.Entity.CodeGenerator
{
    /// <summary>
    ///  
    ///</summary>
    public class   Tright_Menu
    {

       public Tright_Menu()
       {
      
       }

        ///<summary>
        ///描述：主键
        ///</summary>
        [Column(IsIdentity = true, IsPrimary = true)]
        public int Id { get; set; }
        ///<summary>
        ///描述：菜单名
        ///</summary>
        public string Menu_Name { get; set; }
        ///<summary>
        ///描述：菜单地址
        ///</summary>
        public string Menu_Url { get; set; }
        ///<summary>
        ///描述：父id
        ///</summary>
        public int Parent_Id { get; set; }
        ///<summary>
        ///描述：状态{0：正常，1：禁用}
        ///</summary>
        public int Status { get; set; }
        ///<summary>
        ///描述：icon图标
        ///</summary>
        public string Icon { get; set; }
        ///<summary>
        ///描述：排序id
        ///</summary>
        public int Sortid { get; set; }

        [JsonIgnore]
        public Tright_Power Parent { get; set; }

        public List<Tright_Menu> Childs { get; set; }

    }
 }








