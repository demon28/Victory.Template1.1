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
    public class PeopleController : TopControllerBase
    {
        [Right(PowerName = "人员信息")]
        public IActionResult Index()
        {
            return View();
        }


        [Right(PowerName = "查询")]
        [HttpPost]
        public IActionResult List(string keyword,int pageIndex,int pageSize)
        {
            PageModel page = new PageModel();
            page.PageIndex = pageIndex;
            page.PageSize = pageSize;


            Tsys_User_Da da = new Tsys_User_Da();
            var list = da.ListByWhere(keyword, ref page);


            return SuccessResultList(list,page);
        }


        [Right(PowerName = "设置用户角色")]
        [HttpPost]
        public IActionResult GetAllRole()
        {
            Tright_Role_Da rolemanger = new Tright_Role_Da();
            var list = rolemanger.Select.OrderBy(s => s.Id).ToList();

            return SuccessResultList(list);
        }



        /// <summary>
        /// 获取用户与角色的中间 表 信息
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        /// 
        [Right(PowerName = "分配权限")]
        [HttpPost]
        public IActionResult GetUserRoleMebmer(int userid)
        {
            Tright_User_Role_Da userroleManage = new Tright_User_Role_Da();
            var list = userroleManage.Select.Where(s => s.User_Id == userid).ToList();

            return SuccessResultList(list);


        }


        [Right(PowerName = "用户关联角色")]
        [HttpPost]
        public IActionResult AddUserRoleMebmer(int userid, int roleid)
        {
            Tright_User_Role_Da userroleManage = new Tright_User_Role_Da();

            if (userroleManage.Select.Where(s => s.Role_Id == roleid && s.User_Id == userid).Count() > 0)
            {
                return SuccessMessage("请不要反复添加！");
            }


            Tright_User_Role model = new Tright_User_Role
            {
                Role_Id = roleid,
                User_Id = userid
            };
            userroleManage.Insert(model);

            return SuccessMessage("添加成功！");
        }


        [Right(PowerName = "用户退出角色")]
        [HttpPost]
        public IActionResult DeleteUserRoleMebmer(int id)
        {
            Tright_User_Role_Da userroleManage = new Tright_User_Role_Da();
            var model = userroleManage.Select.Where(s => s.Id == id);

            if (model == null)
            {
                return SuccessMessage("请不要反复取消！"); ;
            }



            if (userroleManage.Delete(s => s.Id == id) > 0)
            {
                return SuccessMessage("成功！");

            }
            return FailMessage();

        }



    }
}
