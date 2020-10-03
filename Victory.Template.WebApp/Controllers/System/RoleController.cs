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
    public class RoleController : TopControllerBase
    {

        [Permission(PowerName = "角色管理")]
        public IActionResult Index()
        {
            return View();
        }


        [Permission(PowerName = "添加角色")]
        [HttpPost]
        public IActionResult AddRole(Tright_Role model)
        {
            if (string.IsNullOrEmpty(model.Role_Name))
            {
                return FailMessage("角色名不能为空！");
            }


            Tright_Role_Da da = new Tright_Role_Da();
            var role=  da.Insert(model);


            Tright_Power_Da powerda = new Tright_Power_Da();

            Tright_Power powermodel = new Tright_Power();
            powermodel.Power_Type = model.Role_Name + "权限";

            var power = powerda.Insert(powermodel);


            Tright_Role_Power_Da rolepowerda = new Tright_Role_Power_Da();
            Tright_Role_Power rolepowermodel = new Tright_Role_Power();
            rolepowermodel.Role_Id = role.Id;
            rolepowermodel.Power_Id = power.Id;

            rolepowerda.Insert(rolepowermodel);

            return SuccessMessage("添加成功！");

        }


        [Permission(PowerName = "修改角色")]
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


        [Permission(PowerName = "角色查询")]
        [HttpPost]
        public IActionResult ListRole()
        {
            Tright_Role_Da da = new Tright_Role_Da();

            return SuccessResultList(da.Select.ToList());
        }

        [Permission(PowerName = "删除角色")]
        [HttpPost]
        public IActionResult DelRole(int id)
        {
            Tright_Role_Da da = new Tright_Role_Da();

            Tright_Role_Power_Da rpda = new Tright_Role_Power_Da();
            var rp= rpda.Select.Where(s => s.Role_Id == id).ToOne();


            Tright_Power_Da powerda = new Tright_Power_Da();

            if (da.Delete(s => s.Id == id) > 0 && powerda.Delete(s => s.Id == rp.Power_Id) > 0)
            {
                return SuccessMessage("已删除！");
            }
        
            return FailMessage();

        }

        #region 操作配置

        [Permission(PowerName = "查询功能")]
        [HttpPost]
        public IActionResult ListFunc()
        {
            Tright_Operation_Da da = new Tright_Operation_Da();
            return SuccessResultList(da.Select.ToTreeList());
        }



        /// <summary>
        /// 获取角色 与 权限 的中间表信息
        /// </summary>
        /// <param name="roleid"></param>
        /// <returns></returns>
        [Permission(PowerName = "角色功能配置")]
        [HttpPost]
        public IActionResult GetRolePowerMebmer(int roleid)
        {
            Tright_Power_Opeartion_Da da = new Tright_Power_Opeartion_Da();
            var list = da.ListByRoleid(roleid);

            return SuccessResultList(list);
        }


        [Permission(PowerName = "角色关联功能")]
        [HttpPost]
        public IActionResult AddRolePowerMebmer(int roleid, int operationid)
        {


            Tright_Role_Power_Da da = new Tright_Role_Power_Da();
            var rp= da.Select.Where(s => s.Role_Id == roleid).ToOne();

            Tright_Power_Opeartion_Da poda = new Tright_Power_Opeartion_Da();

            Tright_Power_Opeartion model = new Tright_Power_Opeartion();

            model.Power_Id = rp.Power_Id;
            model.Operation_Id = operationid;

            poda.InsertOrUpdate(model);

            return SuccessMessage("已添加！");
        }


        [Permission(PowerName = "角色取消功能")]
        [HttpPost]
        public IActionResult DeletedRolePowerMebmer(int id, int roleid)
        {
            Tright_Role_Power_Da da = new Tright_Role_Power_Da();
            var rp = da.Select.Where(s => s.Role_Id == roleid).ToOne();

            Tright_Power_Opeartion_Da poda = new Tright_Power_Opeartion_Da();

            if (poda.Delete(s => s.Operation_Id == id && s.Power_Id == rp.Power_Id)>0)
            {
                return SuccessMessage("已删除！");
            }

            return FailMessage("删除失败");



        }
        #endregion


        #region 菜单配置

        [Permission(PowerName = "查询菜单")]
        [HttpPost]
        public IActionResult ListMenu()
        {
            Tright_Menu_Da da = new Tright_Menu_Da();
            var list = da.Select.OrderBy(s => s.Sortid).ToTreeList();
            return SuccessResultList(list);
        }

        [Permission(PowerName = "角色菜单配置")]
        [HttpPost]
        public IActionResult GetRoleMenuMember(int roleid)
        {
            Tright_Power_Menu_Da da = new Tright_Power_Menu_Da();
            var list = da.ListByRoleid(roleid);
            return SuccessResultList(list);
        }


        [Permission(PowerName = "角色关联菜单")]
        [HttpPost]
        public IActionResult AddRoleMenuMebmer(int menuid, int roleid)
        {


            Tright_Role_Power_Da da = new Tright_Role_Power_Da();
            var rp = da.Select.Where(s => s.Role_Id == roleid).ToOne();

            Tright_Power_Menu_Da poda = new Tright_Power_Menu_Da();

            Tright_Power_Menu model = new Tright_Power_Menu();

            model.Power_Id = rp.Power_Id;
            model.Menu_Id = menuid;

            poda.InsertOrUpdate(model);

            return SuccessMessage("已添加！");
        }



        [Permission(PowerName = "角色取消菜单")]
        [HttpPost]
        public IActionResult DeletedRoleMenuMebmer(int menuid, int roleid)
        {
            Tright_Role_Power_Da da = new Tright_Role_Power_Da();
            var rp = da.Select.Where(s => s.Role_Id == roleid).ToOne();

            Tright_Power_Menu_Da poda = new Tright_Power_Menu_Da();

            if (poda.Delete(s => s.Menu_Id == menuid && s.Power_Id == rp.Power_Id) > 0)
            {
                return SuccessMessage("已删除！");
            }

            return FailMessage("删除失败");



        }

        #endregion


    }
}
