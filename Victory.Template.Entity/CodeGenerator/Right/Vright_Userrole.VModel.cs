//----------------
//DA  v1.1
//2020-7-31
//Near
//---------------

using FreeSql.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;



namespace Victory.Template.Entity.CodeGenerator
{
  
    public class   Vright_UserRole
    {

       public Vright_UserRole()
       {
      
       }

        public int Userid { get; set; }
        public int Roleid { get; set; }
        public string Role_Name { get; set; }
        public string Username { get; set; }
        public string Workid { get; set; }

    }
 }








