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
using Victory.Template.Entity.Enums;

namespace Victory.Template.DataAccess.CodeGenerator
{

    /// <summary>
    ///   权限&amp;菜单中间表
    ///</summary>
    public class Tright_Power_Menu_Da : FreeSql.BaseRepository<Tright_Power_Menu>
    {

        public Tright_Power_Menu_Da() : base(DataAccess.DbContext.Db, null, null)
        {

        }

        public List<RightRoleMenuModel> ListByRoleid(int roleid)
        {

            return this.Orm.Select<Tright_Role, Tright_Role_Power, Tright_Power, Tright_Power_Menu>()
                  .LeftJoin((tr, trp, tp, tpm) => trp.Role_Id == tr.Id)
                  .LeftJoin((tr, trp, tp, tpm) => tp.Id == trp.Power_Id)
                  .LeftJoin((tr, trp, tp, tpm) => tpm.Power_Id == tp.Id)
                  .Where((tr, trp, tp, tpm) => tr.Id == roleid)
                  .ToList((tr, trp, tp, tpm) => new RightRoleMenuModel()
                  {
                      Menu_Id = tpm.Menu_Id,
                      Power_Id = tp.Id,
                      Role_Id = tr.Id
                  });

        }

    }

}

