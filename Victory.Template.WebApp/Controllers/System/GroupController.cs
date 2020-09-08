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

            if (da.Delete(s => s.Id == id) > 0)
            {
                return SuccessMessage("已删除！");

            }
            return FailMessage();
        }


        [Permission(PowerName = "查询组员")]
        [HttpPost]
        public IActionResult ListPeople(int groupid, string keyword, int pageIndex, int pageSize) {

            PageModel page = new PageModel();
            page.PageIndex = pageIndex;
            page.PageSize = pageSize;

            Tright_Group_Da da = new Tright_Group_Da();
            var list=  da.ListPeopleByGroup(groupid, keyword,ref page);

            return SuccessResult(list);

        }

        /// <summary>
        /// 关键字查询人员添加用户组
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult QueryPeople(string keyword) {

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
        public IActionResult AddPeopleToGroup(List<Tright_User_Group> list) {

            Tright_User_Group_Da da = new Tright_User_Group_Da();

            //List<Tright_User_Group> items = new List<Tright_User_Group>();

            //foreach (var item in list)
            //{
            //    Tright_User_Group model = new Tright_User_Group
            //    {
            //        User_Id = item,
            //        Group_Id = groupid
            //    };
            //    items.Add(model);
            //}

            if (!da.BatchInsert(list))
            {
                return FailMessage("添加失败！");
            }

            return SuccessMessage("添加成功！");

        }


    }
}
