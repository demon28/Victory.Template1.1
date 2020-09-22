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
    public class OperationController : TopControllerBase
    {

        [Permission(PowerName = "功能管理")]
        public IActionResult Index()
        {
            return View();
        }

        [Permission(PowerName = "查询")]
        [HttpPost]
        public IActionResult ListFunc()
        {
            Tright_Operation_Da da = new Tright_Operation_Da();
            return SuccessResultList(da.Select.ToTreeList());
        }


        [Permission(PowerName = "添加")]
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


        [Permission(PowerName = "修改")]
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



        [Permission(PowerName = "删除")]
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
