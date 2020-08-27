using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Victory.Template.DataAccess.CodeGenerator;
using Victory.Template.Entity;
using Victory.Template.Entity.CodeGenerator;
using Victory.Template.Entity.Enums;

namespace Victory.Template.WebApp.Attribute
{
    public class PermissionAttribute : ActionFilterAttribute
    {

        /// <summary>
        /// 忽略权限
        /// </summary>
        public bool Ignore { get; set; }

        /// <summary>
        /// 权限名称
        /// </summary>
        public string PowerName { get; set; }


        public  override void OnActionExecuting(ActionExecutingContext Context)
        {
            //先取出登录用户id
            int userid = int.Parse(Context.HttpContext.User.FindFirst("userId").Value);

            //根据配置文件决定是否给初次登录的用户 分配一个默认的登录角色

            if (AppConfig.IsSetDefautlRole)
            {
                SetDefaultRole(userid);
            }

            //如果Ignore 为true 则表示不检查该操作，这里只给他初次登录分配 普通会员角色
            if (Ignore)
            {
                return;
            }

            //获取路由地址

            string areaName = string.Empty;
            string controllerName = string.Empty;
            string actionName = string.Empty;

            string page = GetPageUrl(Context, ref areaName, ref controllerName, ref actionName);

            //判断请求的是否是ajax 请求
            var isAjax = Context.HttpContext.Request.Headers["X-Requested-With"] == "XMLHttpRequest";


            //判断数据库是否存在该权限，不存则自动添加，无需手动配置,减少开发中的配置工作
            InsertActionOperation(controllerName, actionName, areaName, page, isAjax);


            //如果全局配置忽略权限，则忽略检测
            if (AppConfig.IgnoreAuthRight)
            {
                return;
            }


            Tright_Operation_Da da = new Tright_Operation_Da();

            var list = da.ListByUserId(userid);   //此处应该用Redis 缓存用户权限

            if (list.Where(s => s.Url.ToLower()==page.ToLower()).ToList().Count() > 0)
            {
                return;   //有权限
            }


            //是否ajax请求，是ajax 则判定为 请求操作， 非ajax则判定为 访问页面
            if (isAjax)
            {

                Context.Result = new JsonResult(new { Success = false, Code = 405, Message = "您没有该功能操作权限！" });
                return;

            }

            //跳转指定的没有权限的页面
            Context.Result = new RedirectToRouteResult(new RouteValueDictionary(new
            {
                controller = "System",
                action = "NoPermission"
            }));
        }



        /// <summary>
        /// 增加页面操作配置
        /// </summary>
        /// <param name="controllerName"></param>
        /// <param name="actionName"></param>
        /// <param name="areaName"></param>
        /// <param name="page"></param>
        /// <param name="isAjax"></param>
        private void InsertActionOperation(string controllerName, string actionName, string areaName, string page, bool isAjax)
        {

            Tright_Operation_Da  da = new Tright_Operation_Da();

            bool HasPage = da.Select.Where(s => s.Url.ToLower() == page.ToLower()).Count() > 0;

            if (HasPage)
            {
                return;
            }


            //获取功能归属哪个页面
            Tright_Operation root = da.Where(s => s.Controller == controllerName && s.Type == (int)OpeartionType.页面访问).First();

            Tright_Operation model = new Tright_Operation();

            model.Action = actionName;
            model.Area = areaName;
            model.Code = Guid.NewGuid().ToString();
            model.Controller = controllerName;
            model.Parent_Id = isAjax ? root.Id:0;
            model.Sortid = 0;
            model.Status = 0;
            model.Type = isAjax ? (int)OpeartionType.功能操作 : (int)OpeartionType.页面访问;
            model.Url = page;
            model.Name = PowerName;
            

            da.Insert(model);




        }


        /// <summary>
        /// 给用户设置默认登录角色
        /// </summary>
        /// <returns></returns>
        public void SetDefaultRole(int userid)
        {

            Tright_User_Role_Da userrole = new Tright_User_Role_Da();

            if (userrole.Where(s => s.User_Id == userid).Count() <= 0)
            {
                Tright_User_Role userolemodel = new Tright_User_Role()
                {
                    Role_Id = 1,   //默认1为普通会员
                    User_Id = userid
                };

                userrole.Insert(userolemodel);
            }
        }

        /// <summary>
        /// 获取当前页面 或 功能 的路由地址
        /// </summary>
        /// <param name="Context"></param>
        /// <returns></returns>
        public string GetPageUrl(ActionExecutingContext Context, ref string areaName, ref string controllerName, ref string actionName)
        {


            if (Context.ActionDescriptor.RouteValues.ContainsKey("area"))
            {
                areaName = Context.ActionDescriptor.RouteValues["area"].ToString();
            }
            if (Context.ActionDescriptor.RouteValues.ContainsKey("controller"))
            {
                controllerName = Context.ActionDescriptor.RouteValues["controller"].ToString();
            }
            if (Context.ActionDescriptor.RouteValues.ContainsKey("action"))
            {
                actionName = Context.ActionDescriptor.RouteValues["action"].ToString();
            }

            var page = "/" + controllerName + "/" + actionName;

            if (!string.IsNullOrEmpty(areaName))
            {
                page = "/" + areaName + page;
            }

            return page;

        }

    }
}
