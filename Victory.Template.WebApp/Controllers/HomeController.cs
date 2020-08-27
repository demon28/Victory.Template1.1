using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Victory.Template.DataAccess.CodeGenerator;
using Victory.Template.Entity;
using Victory.Template.Entity.Model;




namespace Victory.Template.WebApp.Controllers
{

    [Authorize]
    public class HomeController : Victory.Core.Controller.TopControllerBase
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Error()
        {
            return View();
        }

        /// <summary>
        /// 获取登录用户信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult GetLoginUser()
        {
            SysUserInfoModel usermodel = new SysUserInfoModel();

            var userinfo = (HttpContext.User.Identity as ClaimsIdentity);

            //加载基本信息
            usermodel.UserId = int.Parse(userinfo.FindFirst("userId").Value);
            usermodel.UserName = userinfo.FindFirst("userName").Value;
            usermodel.WorkId = userinfo.FindFirst("workId").Value;
            usermodel.Sex = int.Parse(userinfo.FindFirst("sex").Value);

            //加载菜单
            Tright_Menu_Da tright_Menu_Da = new Tright_Menu_Da();

            //忽略权限，则显示所有菜单
            if (AppConfig.IgnoreAuthRight)
            {
                usermodel.Menu = tright_Menu_Da.ListByTree();
            }
            else
            {
                usermodel.Menu = tright_Menu_Da.ListByLogin(usermodel.UserId);
             
            }
        

            return SuccessResult(usermodel);
        }
    }
}
