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
    ///   
    ///</summary>
    public class Tright_Operation_Da : FreeSql.BaseRepository<Tright_Operation>
    {

        public Tright_Operation_Da() : base(DataAccess.DbContext.Db, null, null)
        {

        }

        public List<Tright_Operation> ListByUserId(int userid) {

            string sql = @" SELECT DISTINCT
  [to].Id,
  [to].Code,
  [to].Area,
  [to].Controller,
  [to].Action,
  [to].Url,
  [to].SortId,
  [to].Parent_Id,
  [to].Type,
  [to].Name,
  [to].Status
  FROM Vright_UserRole vur
   LEFT JOIN Tright_Role_Power trp ON vur.Roleid=trp.Role_Id
   LEFT JOIN Tright_Power tp ON tp.Id=trp.Power_Id
   LEFT JOIN Tright_Power_Opeartion tpo ON tp.Id = tpo.Power_Id 
   LEFT JOIN Tright_Operation [to] ON tpo.Operation_Id = [to].Id
 WHERE tp.Id=2 AND [to].Status=0 AND vur.Userid=@userid
";

          return  this.Select.WithSql(sql, new { userid = userid }).OrderBy(s=>s.Sortid).ToList();

            

        }

    }

}

