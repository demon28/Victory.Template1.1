using Victory.Template.Entity.CodeGenerator;

namespace Victory.Template.Facade
{
    public class LoginFacade: FacadeBase
    {
            
        public bool Login(string workId,string pwd,ref Team_User user)
        {

            DataAccess.CodeGenerator.Team_User_Da da = new DataAccess.CodeGenerator.Team_User_Da();

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

            return true;

        }




    }
}
