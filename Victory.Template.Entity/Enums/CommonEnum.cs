using System;
using System.Collections.Generic;
using System.Text;

namespace Victory.Template.Entity.Enums
{
    /// <summary>
    /// 系统日志类型
    /// </summary>
    public enum SysLogType
    {
        全部=0,
        登录日志=1,
        系统异常=2,
        操作日志=3
    }



    // <summary>
    /// 权限类型
    /// </summary>
    public enum PowerType
    {

        菜单权限 = 1,
        功能权限 = 2,
        文件权限 = 3,
        元素权限=4
    }


    /// <summary>
    /// 权限操作类型
    /// </summary>
    public enum OpeartionType
    {
        功能操作=0,
        页面访问=1
    }

    /// <summary>
    /// 用户是否有允许登录项目
    /// </summary>
    public enum IsAdmin
    {
        非系统用户=0,
        系统用户=1
    }
}
