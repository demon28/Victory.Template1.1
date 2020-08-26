
using System;
using System.Collections.Generic;
using System.Linq;
using Victory.Template.Entity.CodeGenerator;
using FreeSql;
using Victory.Template.Entity.Model;

namespace Victory.Template.DataAccess.CodeGenerator
{

    /// <summary>
    ///   
    ///</summary>
    public class Tright_Menu_Da : FreeSql.BaseRepository<Tright_Menu>
    {

        public Tright_Menu_Da() : base(DataAccess.DbContext.Db, null, null)
        {

        }

        public List<Tright_Menu> ListByTree()
        {
            return Select.ToTreeList();
        }


    }

}

