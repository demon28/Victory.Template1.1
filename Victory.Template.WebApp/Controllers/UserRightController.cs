using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Victory.Core.Controller;
using Victory.Template.DataAccess.CodeGenerator;
using Victory.Template.Entity.CodeGenerator;
using Victory.Template.WebApp.Attribute;

namespace Victory.Template.WebApp.Controllers
{
    [Authorize]
    public class UserRightController : TopControllerBase
    {

        [Permission(PowerName = "用户角色")]
        public IActionResult Index()
        {
            return View();
        }


        [Permission(Ignore = true)]
        public IActionResult NoPermission() {

            return View();

        }

      

        [Permission(PowerName = "功能配置")]
        public IActionResult Func()
        {
            return View();
        }

      




        [Permission(PowerName = "查询功能")]
        [HttpPost]
        public IActionResult ListFunc()
        {
            DataAccess.CodeGenerator.Tright_Power_Da da = new DataAccess.CodeGenerator.Tright_Power_Da();

            return SuccessResultList(da.ListByOder());

        }


        [Permission(PowerName = "添加功能")]
        [HttpPost]
        public IActionResult AddFunc(Tright_Power model)
        {
           // if (string.IsNullOrEmpty(model.Powername))
           // {
           //     return FailMessage("权限名不能为空！");
           // }

           //Tright_Power_Da da = new Tright_Power_Da();

           // da.Insert(model);

            return SuccessMessage("成功！");
  
        }


        [Permission(PowerName = "修改功能")]
        [HttpPost]
        public IActionResult UpdateFunc(Tright_Power model)
        {

           // if (string.IsNullOrEmpty(model.Powername))
           // {
           //     return FailMessage("权限名不能为空！");
           // }

           //Tright_Power_Da da = new Tright_Power_Da();
           //da.Update(model);

           return SuccessMessage("成功！");
           
        }



        [Permission(PowerName = "删除功能")]
        [HttpPost]
        public IActionResult DelFunc(int id)
        {
            Tright_Power_Da da = new Tright_Power_Da();

            if (da.Delete(s => s.Id == id) > 0)
            {
                return SuccessMessage();
              
            }
            return FailMessage();

        }






    }
}
