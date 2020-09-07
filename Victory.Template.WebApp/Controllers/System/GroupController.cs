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



    }
}
