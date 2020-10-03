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
using Victory.Template.Entity.Model;

namespace Victory.Template.DataAccess.CodeGenerator
{

    /// <summary>
    ///   权限&amp;操作id
    ///</summary>
    public class Tright_Power_Opeartion_Da : FreeSql.BaseRepository<Tright_Power_Opeartion>
    {

        public Tright_Power_Opeartion_Da() : base(DataAccess.DbContext.Db, null, null)
        {

        }

        public List<RightRoleOperationModel> ListByRoleid(int roleid)
        {

            return this.Orm.Select<Tright_Role, Tright_Role_Power, Tright_Power, Tright_Power_Opeartion>()
                  .LeftJoin((tr, trp, tp, tpo) => trp.Role_Id == tr.Id)
                  .LeftJoin((tr, trp, tp, tpo) => tp.Id == trp.Power_Id)
                  .LeftJoin((tr, trp, tp, tpo) => tpo.Power_Id == tp.Id)
                  .Where((tr, trp, tp, tpo) => tr.Id == roleid)
                  .ToList((tr, trp, tp, tpo) => new RightRoleOperationModel()
                  {
                      Operation_Id = tpo.Operation_Id,
                      Power_Id = tp.Id,
                      Role_Id = tr.Id
                  });

        }





    }

}

