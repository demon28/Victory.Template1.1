using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Victory.Core.Controller;
using Victory.Core.Models;
using Victory.Template.DataAccess.CodeGenerator;
using Victory.Template.Entity.Enums;
using Victory.Template.WebApp.Attribute;

namespace Victory.Template.WebApp.Controllers
{
    [Authorize]
    public class SysLogController : TopControllerBase
    {
        [Right(PowerName = "访问")]
        public IActionResult Index()
        {
            return View();
        }




        [Right(PowerName = "查询")]
        [HttpPost]
        public IActionResult List(string keyword,DateTime? keystartime, DateTime? keyendTime, int keytype, int pageIndex, int pageSize)
        {

            PageModel page = new PageModel();
            page.PageIndex = pageIndex;
            page.PageSize = pageSize;


            Tsys_Log_Da da = new Tsys_Log_Da();
            var list = da.ListByWhere(keyword, (SysLogType)keytype, keystartime, keyendTime, ref page);


            return SuccessResultList(list, page);



        }


    }
}
