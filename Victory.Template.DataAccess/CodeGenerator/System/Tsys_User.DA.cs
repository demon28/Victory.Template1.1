using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Victory.Core.Extensions;
using Victory.Core.Models;
using Victory.Template.DataAccess;
using Victory.Template.Entity.CodeGenerator;
using Victory.Template.Entity.Enums;
using Victory.Template.Entity.Model;
using Victory.Template.Entity;

namespace Victory.Template.DataAccess.CodeGenerator
{

    /// <summary>
    ///  
    ///</summary>
    public class Tsys_User_Da : FreeSql.BaseRepository<Tsys_User>
    {

        public Tsys_User_Da() : base(DataAccess.DbContext.Db, null, null)
        {

        }


        /// <summary>
        /// 无分页查询
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        public List<Tsys_User> ListByWhere(string keyword) {

            var data = this.Select;

            if (!string.IsNullOrEmpty(keyword))
            {
                data = data.Where(s => s.Name.Contains(keyword) || s.Workid.Contains(keyword) || s.Dep1.Contains(keyword) || s.Dep2.Contains(keyword) || s.Dep3.Contains(keyword) || s.Dep4.Contains(keyword) || s.Dep5.Contains(keyword));
            }
            return data.OrderBy(s => s.Comedate).ToList();
        }

        /// <summary>
        /// 有分页查询
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        public List<Tsys_User> ListByWhere(string keyword, ref PageModel page) {

            var data =this.Select;

            if(!string.IsNullOrEmpty(keyword))
            {
                data= data.Where(s => s.Name.Contains(keyword) || s.Workid.Contains(keyword) ||s.Dep1.Contains(keyword) || s.Dep2.Contains(keyword) || s.Dep3.Contains(keyword) || s.Dep4.Contains(keyword) || s.Dep5.Contains(keyword));
            }

            page.TotalCount = data.Count().ToInt();
          

            var list = data.Page(page.PageIndex, page.PageSize)
                .OrderBy(s => s.Comedate)
                .ToList();

            return list;
        }


    }

}

