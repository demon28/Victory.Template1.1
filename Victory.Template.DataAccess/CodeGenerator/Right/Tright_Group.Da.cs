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

        /// <summary>
        /// 关键字查询
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="page"></param>
        /// <returns></returns>

        public List<Tright_Group> ListByWhere(string keyword, ref PageModel page)
        {

            var data = this.Select;

            if (!string.IsNullOrEmpty(keyword))
            {
                data = data.Where(s => s.Group_Name.Contains(keyword));
            }

            page.TotalCount = data.Count().ToInt();

            var list = data.Page(page.PageIndex, page.PageSize)
                .OrderBy(s => s.Id)
                .ToList();

            return list;
        }

        /// <summary>
        /// 根据用户组id查询 用户信息
        /// </summary>
        /// <param name="gid"></param>
        /// <returns></returns>

        public List<RightUserGroupModel> ListPeopleByGroup(int gid, string keyword, ref PageModel page)
        {
            var data = this.Orm.Select<Tright_User_Group, Tsys_User, Tright_Group>()
                  .LeftJoin((a, b, c) => a.User_Id == b.Id)
                  .LeftJoin((a, b, c) => a.Group_Id == c.Id)
                  .Where((a, b, c) => a.Group_Id == gid);

            if (!string.IsNullOrEmpty(keyword))
            {
                data = data.Where((a, b, c) => b.Name.Contains(keyword) || b.Workid.Contains(keyword));
            }

            page.TotalCount = data.Count().ToInt();

            return  data.Page(page.PageIndex, page.PageSize)
              .OrderBy((a, b, c) => b.Id)
              .ToList((a, b, c) => new RightUserGroupModel()
              {
                  UserGroup_Id = a.Id,
                  Group_Id = c.Id,
                  Group_Name = c.Group_Name
              });
          

        }


        /// <summary>
        /// 根据组id，获取组拥有的角色
        /// </summary>
        /// <param name="gid"></param>
        /// <returns></returns>

        public List<RightRoleGroupModel> ListRoleByGroup(int gid)
        {

            return this.Orm.Select< Tright_Group_Role, Tright_Role>()
              .LeftJoin((a, b) => a.Role_Id == b.Id)
              .Where((a, b) => a.Group_Id == gid)
              .ToList((a, b) => new RightRoleGroupModel() { 
              
                Group_Id=a.Group_Id,
                Role_Id=a.Role_Id,
                Role_Name=b.Role_Name
              
              });

        }
    }

}

