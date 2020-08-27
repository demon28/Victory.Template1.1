
using System;
using System.Collections.Generic;
using System.Linq;
using Victory.Template.Entity.CodeGenerator;

namespace Victory.Template.DataAccess.CodeGenerator
{

    /// <summary>
    ///  用户角色中间关联表
    ///</summary>
    public class Tright_User_Role_Da : FreeSql.BaseRepository<Tright_User_Role>
    {
        public Tright_User_Role_Da() : base(DataAccess.DbContext.Db, null, null)
        {


        }


      
    }

}

