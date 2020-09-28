using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using Victory.Core.Controller;
using Victory.Core.Encrypt;
using Victory.Core.Models;
using Victory.Template.DataAccess.CodeGenerator;
using Victory.Template.Entity.CodeGenerator;
using Victory.Template.WebApp.Attribute;

namespace Victory.Template.WebApp.Controllers
{
    [Authorize]
    public class PeopleController : TopControllerBase
    {
        [Permission(PowerName = "人员信息")]
        public IActionResult Index()
        {
            return View();
        }

        [Permission(PowerName = "查询")]
        [HttpPost]
        public IActionResult List(string keyword, int pageIndex, int pageSize)
        {
            PageModel page = new PageModel
            {
                PageIndex = pageIndex,
                PageSize = pageSize
            };

            Tsys_User_Da da = new Tsys_User_Da();
            var list = da.ListByWhere(keyword, ref page);

            return SuccessResultList(list, page);
        }

        /// <summary>
        /// 新增用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [Permission(PowerName = "新增用户")]
        [HttpPost]
        public IActionResult AddUser(Tsys_User user)
        {
            if(string.IsNullOrWhiteSpace(user.Workid))
            {
                return FailMessage("用户工号不能为空！");
            }
            if (string.IsNullOrWhiteSpace(user.Name))
            {
                return FailMessage("用户姓名不能为空！");
            }
            if (string.IsNullOrWhiteSpace(user.Pwd))
            {
                return FailMessage("用户密码不能为空！");
            }

            user.Pwd = Md5.Encrypt32(user.Pwd);
            user.Createtime = DateTime.Now;

            Tsys_User_Da da = new Tsys_User_Da();

            if(da.Select.Where(i => i.Workid == user.Workid).Count() > 0)
            {
                return FailMessage("用户工号重复！");
            }

            da.Insert(user);

            return SuccessResult("添加用户成功！");
        }

        /// <summary>
        /// 修改用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [Permission(PowerName = "修改用户")]
        [HttpPost]
        public IActionResult UpdateUser(Tsys_User user)
        {
            if (string.IsNullOrWhiteSpace(user.Workid))
            {
                return FailMessage("用户工号不能为空！");
            }
            if (string.IsNullOrWhiteSpace(user.Name))
            {
                return FailMessage("用户姓名不能为空！");
            }
            if (string.IsNullOrWhiteSpace(user.Pwd))
            {
                return FailMessage("用户密码不能为空！");
            }

            Tsys_User_Da da = new Tsys_User_Da();

            Tsys_User old = da.Select.Where(o => o.Id == user.Id).First();

            if(old.Pwd != user.Pwd)
            {
                user.Pwd = Md5.Encrypt32(user.Pwd);
            }

            if (da.Update(user) <= 0)
            {
                return FailMessage("修改用户信息失败！");
            }

            return SuccessResult("修改用户信息成功！");
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Permission(PowerName = "删除用户")]
        [HttpPost]
        public IActionResult DeleteUser(int id)
        {
            Tsys_User_Da da = new Tsys_User_Da();

            if (da.Delete(u => u.Id == id) <= 0)
            {
                return FailMessage("删除用户失败！");
            }
            else
            {
                return SuccessResult("删除用户成功！");
            }
        }

        /// <summary>
        /// 批量删除用户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Permission(PowerName = "批量删除用户")]
        [HttpPost]
        public IActionResult BatchDeleteUser(int[] ids)
        {
            Tsys_User_Da da = new Tsys_User_Da();

            if (da.Delete(u => ids.Contains(u.Id)) <= 0)
            {
                return FailMessage("批量删除用户失败！");
            }
            else
            {
                return SuccessResult("批量删除用户成功！");
            }
        }

        [Permission(PowerName = "设置用户角色")]
        [HttpPost]
        public IActionResult GetAllRole()
        {
            Tright_Role_Da rolemanger = new Tright_Role_Da();
            var list = rolemanger.Select.OrderBy(s => s.Id).ToList();

            return SuccessResultList(list);
        }

        [Permission(PowerName = "分配权限")]
        [HttpPost]
        public IActionResult GetUserRoleMebmer(int userid)
        {
            Tright_User_Role_Da userroleManage = new Tright_User_Role_Da();
            var list = userroleManage.Select.Where(s => s.User_Id == userid).ToList();

            return SuccessResultList(list);
        }

        [Permission(PowerName = "用户关联角色")]
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

        [Permission(PowerName = "用户退出角色")]
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
