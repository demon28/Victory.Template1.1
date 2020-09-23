using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Victory.Core.Controller;
using Victory.Core.Models;
using Victory.Template.WebApp.Attribute;
using Victory.Template.DataAccess.CodeGenerator;
using Victory.Template.Entity.CodeGenerator;

namespace Victory.Template.WebApp.Controllers.System
{
    [Authorize]
    public class GroupController : TopControllerBase
    {


        [Permission(PowerName = "分组管理")]
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public IActionResult List(string keyword, int pageIndex, int pageSize)
        {

            PageModel page = new PageModel();
            page.PageIndex = pageIndex;
            page.PageSize = pageSize;


            Tright_Group_Da da = new Tright_Group_Da();
            var list = da.ListByWhere(keyword, ref page);
            return SuccessResultList(list, page);
        }


        [Permission(PowerName = "查询")]
        [HttpPost]
        public IActionResult ListGroupByTree()
        {
            Tright_Group_Da da = new Tright_Group_Da();
            var list = da.ListByTree();
            return SuccessResultList(list);
        }



        [Permission(PowerName = "添加")]
        [HttpPost]
        public IActionResult AddGroup(Tright_Group model)
        {

            Tright_Group_Da da = new Tright_Group_Da();
            da.Insert(model);
            return SuccessMessage("添加成功！");

        }


        [Permission(PowerName = "修改")]
        [HttpPost]
        public IActionResult UpdateGroup(Tright_Group model)
        {
            Tright_Group_Da da = new Tright_Group_Da();
            da.Update(model);
            return SuccessMessage("成功！");
        }


        [Permission(PowerName = "删除")]
        [HttpPost]
        public IActionResult DelGroup(int id)
        {
            Tright_Group_Da da = new Tright_Group_Da();
            int count = da.Where(s => s.Id == id).AsTreeCte().ToDelete().ExecuteAffrows();
            if (count > 0)
            {
                return SuccessMessage("已删除！");

            }
            return FailMessage();
        }


        [Permission(PowerName = "查询组员")]
        [HttpPost]
        public IActionResult ListPeople(int groupid, string keyword, int pageIndex, int pageSize)
        {

            PageModel page = new PageModel();
            page.PageIndex = pageIndex;
            page.PageSize = pageSize;

            Tright_Group_Da da = new Tright_Group_Da();
            var list = da.ListPeopleByGroup(groupid, keyword, ref page);

            return SuccessResultList(list, page);

        }

        /// <summary>
        /// 关键字查询人员添加用户组
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult QueryPeople(string keyword, int pageIndex, int pageSize)
        {
            Tsys_User_Da da = new Tsys_User_Da();
            var list = da.ListByWhere(keyword);

            return SuccessResult(list);
        }


        /// <summary>
        /// 添加用户到用户组
        /// </summary>
        /// <param name="list"></param>
        /// <param name="groupid"></param>
        /// <returns></returns>
        public IActionResult AddPeopleToGroup(List<Tright_User_Group> list, int groupid)
        {

            Tright_User_Group_Da da = new Tright_User_Group_Da();

            List<Tright_User_Group> existPeople = da.Select.Where(s => s.Group_Id == groupid).ToList();

            List<Tright_User_Group> insertPeople = new List<Tright_User_Group>();


            //需要先过滤，已存在的组员，避免重复添加
            if (existPeople.Count>0)
            {
                foreach (var item in list)
                {
                    if (existPeople.Where(s=>s.User_Id== item.User_Id && s.Group_Id==item.Group_Id).Count()==0)
                    {
                        insertPeople.Add(item);
                    }
                }
            }
            else
            {
                insertPeople = list;
            }


            if (!da.BatchInsert(insertPeople))
            {
                return FailMessage("添加失败！");
            }

            return SuccessMessage("添加成功！");

        }


        /// <summary>
        /// 删除用户到用户组
        /// </summary>
        /// <param name="list"></param>
        /// <param name="groupid"></param>
        /// <returns></returns>
        public IActionResult DelPeopleToGroup(int tugid)
        {

            Tright_User_Group_Da da = new Tright_User_Group_Da();


            if (da.Delete(s => s.Id == tugid) > 0)
            {
                return SuccessMessage("删除成功！"); ;
            }

            return FailMessage("删除失败！");

        }

        public IActionResult BatchDeletePeople(List<int> ids)
        {

            Tright_User_Group_Da da = new Tright_User_Group_Da();
            int count = da.Where(s => ids.Contains(s.Id)).ToDelete().ExecuteAffrows();
            if (count > 0)
            {
                return SuccessMessage("删除成功！");
            }
            return FailMessage("删除失败！");
        }

    }
}
