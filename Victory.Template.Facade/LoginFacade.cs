using System.Collections.Generic;
using Victory.Template.Entity.CodeGenerator;

namespace Victory.Template.Facade
{
    public class LoginFacade: FacadeBase
    {
            
        public bool Login(string workId,string pwd,ref Tsys_User user)
        {

            DataAccess.CodeGenerator.Tsys_User_Da da = new DataAccess.CodeGenerator.Tsys_User_Da();

            if (da.Where(s => s.Workid == workId).ToOne() == null)
            {
                this.Message = "用户工号不存在";
                
                return false;
            }

            user = da.Where(s => s.Workid == workId && s.Pwd == pwd).ToOne();

            if (user==null)
            {
                this.Message = "密码错误";

                return false;
            }


            if (user.Isadmin!=Entity.Enums.IsAdmin.系统用户)
            {
                this.Message = "抱歉，您不是系统用户！";

                return false;
            }

            return true;

        }


       

    }
}
