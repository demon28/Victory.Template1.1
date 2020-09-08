//DA  v1.1
//2020-7-31
//Near


using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Victory.Core.Extensions;
using Victory.Core.Models;
using Victory.Template.Entity.CodeGenerator;

namespace Victory.Template.DataAccess.CodeGenerator
{

    /// <summary>
    ///   用户&amp;用户组中间表
    ///</summary>
    public class Tright_User_Group_Da : FreeSql.BaseRepository<Tright_User_Group>
    {

        public Tright_User_Group_Da() : base(DataAccess.DbContext.Db, null, null)
        {

        }



        /// <summary>
        /// 批量插入
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public bool BatchInsert(List<Tright_User_Group> items)
        {
             return  this.Orm.Insert(items).ExecuteAffrows() > 0;
        }

    }

}

