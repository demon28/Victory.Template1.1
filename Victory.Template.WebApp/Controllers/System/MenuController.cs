using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Victory.Core.Controller;
using Victory.Core.Models;
using Victory.Template.DataAccess.CodeGenerator;
using Victory.Template.Entity.CodeGenerator;
using Victory.Template.WebApp.Attribute;

namespace Victory.Template.WebApp.Controllers
{
    [Authorize]
    public class MenuController : TopControllerBase
    {
        [Permission(PowerName = "菜单管理")]
        public IActionResult Index()
        {
            return View();
        }


        [Permission(PowerName = "查询")]
        [HttpPost]
        public IActionResult List()
        {
            Tright_Menu_Da da = new Tright_Menu_Da();
            var list = da.ListByTree ();
            return SuccessResultList(list);
        }




        [Permission(PowerName = "添加")]
        [HttpPost]
        public IActionResult Add(Tright_Menu model)
        {

            Tright_Menu_Da da = new Tright_Menu_Da();
            da.Insert(model);


            return SuccessMessage("添加成功！");

        }


        [Permission(PowerName = "修改")]
        [HttpPost]
        public IActionResult Update(Tright_Menu model)
        {
            Tright_Menu_Da da = new Tright_Menu_Da();
            da.Update(model);
            return SuccessMessage("成功！");
        }


        [Permission(PowerName = "删除")]
        [HttpPost]
        public IActionResult Del(int id)
        {
            Tright_Menu_Da da = new Tright_Menu_Da();

            int count= da.Select.Where(s => s.Id == id).AsTreeCte().ToDelete().ExecuteAffrows();

            if (count > 0)
            {
                return SuccessMessage("已删除！");

            }
            return FailMessage();
        }

    }
}
