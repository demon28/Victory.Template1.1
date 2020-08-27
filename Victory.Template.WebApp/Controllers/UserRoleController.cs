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
    public class UserRoleController : TopControllerBase
    {
        public IActionResult Index()
        {
            return View();
        }

        [Right(PowerName = "角色管理")]
        public IActionResult Role()
        {
            return View();
        }




        [Right(PowerName = "添加角色")]
        [HttpPost]
        public IActionResult AddRole(Tright_Role model)
        {
            if (string.IsNullOrEmpty(model.Role_Name))
            {
                return FailMessage("角色名不能为空！");
            }


            Tright_Role_Da da = new Tright_Role_Da();
            da.Insert(model);
            return SuccessMessage("添加成功！");

        }


        [Right(PowerName = "修改角色")]
        [HttpPost]
        public IActionResult UpdateRole(Tright_Role model)
        {

            if (string.IsNullOrEmpty(model.Role_Name))
            {
                return FailMessage("角色名不能为空！");
            }

            Tright_Role_Da da = new Tright_Role_Da();
            da.Update(model);
            return SuccessMessage("成功！");
        }


        [Right(PowerName = "角色查询")]
        [HttpPost]
        public IActionResult ListRole()
        {
            Tright_Role_Da da = new Tright_Role_Da();

            return SuccessResultList(da.Select.ToList());
        }

        [Right(PowerName = "删除角色")]
        [HttpPost]
        public IActionResult DelRole(int id)
        {
            Tright_Role_Da da = new Tright_Role_Da();

            if (da.Delete(s => s.Id == id) > 0)
            {
                return SuccessMessage("已删除！");

            }
            return FailMessage();

        }





        /// <summary>
        /// 获取角色 与 权限 的中间表信息
        /// </summary>
        /// <param name="roleid"></param>
        /// <returns></returns>
        [Right(PowerName = "角色功能配置")]
        [HttpPost]
        public IActionResult GetRolePowerMebmer(int roleid)
        {
            Tright_Role_Power_Da userroleManage = new Tright_Role_Power_Da();
            var list = userroleManage.Select.Where(s => s.Role_Id == roleid).ToList();

            return SuccessResultList(list);



        }


        



        [Right(PowerName = "角色关联功能")]
        [HttpPost]
        public IActionResult AddRolePowerMebmer(int roleid, int powerid)
        {
            //Tright_Role_Power_Da Manage = new Tright_Role_Power_Da();

            //if (Manage.Select.Where(s => s.Roleid == roleid && s.Powerid == powerid).Count() > 0)
            //{
            //    return SuccessMessage("请不要反复添加！");
            //}



            //Tright_Role_Power model = new Tright_Role_Power
            //{
            //    Role_Id = roleid,
            //    Power_Id = powerid
            //};
            //Manage.Insert(model);

            return SuccessMessage("已添加！");
        }


        [Right(PowerName = "角色取消功能")]
        [HttpPost]
        public IActionResult DeletedRolePowerMebmer(int id)
        {
            Tright_Role_Power_Da userroleManage = new Tright_Role_Power_Da();
            var model = userroleManage.Select.Where(s => s.Id == id);

            if (model == null)
            {
                return SuccessMessage("请不要反复取消！"); ;
            }


            if (userroleManage.Delete(s => s.Id == id) > 0)
            {
                return SuccessMessage("已取消！");

            }
            return FailMessage();


        }


    }
}
