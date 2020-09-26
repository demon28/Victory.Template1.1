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
    ///   用户组_角色中间表
    ///</summary>
    public class Tright_Group_Role_Da : FreeSql.BaseRepository<Tright_Group_Role>
    {

        public Tright_Group_Role_Da() : base(DataAccess.DbContext.Db, null, null)
        {

        }


       


    }

}

