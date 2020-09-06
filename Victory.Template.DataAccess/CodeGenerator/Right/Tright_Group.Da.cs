//DA  v1.1
//2020-7-31
//Near


using System;
using System.Collections.Generic;
using System.Linq;
using Victory.Template.Entity.CodeGenerator;
using FreeSql;
using Victory.Template.Entity.Model;
using Victory.Template.Entity.Enums;
using Victory.Core.Models;
using Victory.Core.Extensions;

namespace Victory.Template.DataAccess.CodeGenerator
{

    /// <summary>
    ///   用户组表
    ///</summary>
    public class Tright_Group_Da : FreeSql.BaseRepository<Tright_Group>
    {

        public Tright_Group_Da() : base(Victory.Template.DataAccess.DbContext.Db, null, null)
        {
           
        }


        /// <summary>
        /// 获取所有菜单
        /// </summary>
        /// <returns></returns>
        public List<Tright_Group> ListByTree()
        {
            return Select.OrderBy(s => s.Id).ToTreeList();
        }



        public List<Tright_Group> ListByWhere(string keyword, ref PageModel page) {

            var data =this.Select;

            if(!string.IsNullOrEmpty(keyword))
            {
               data= data.Where(s => s.Group_Name.Contains(keyword)  );
            }

            page.TotalCount = data.Count().ToInt();
          
            var list = data.Page(page.PageIndex, page.PageSize)
                .OrderBy(s => s.Id)
                .ToList();

            return list;
        }



    }

}

