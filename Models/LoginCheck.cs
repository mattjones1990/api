using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyApi.Models
{
    public class LoginCheck
    {
        public int Id { get; set; }
        public Guid UserGuid { get; set; }
        public string Email { get; set; }
        public string Handle { get; set; }
        public string Password { get; set; }
        public int Active { get; set; }
        public string Reason { get; set; }
        public bool Worked { get; set; }

        public LoginCheck()
        {

        }

        internal bool Validated(LoginCheck login)
        {
            if (String.IsNullOrEmpty(login.Email) ||
                String.IsNullOrEmpty(login.Password) ||
                String.IsNullOrEmpty(login.Handle))
            {
                return false;
            }
            return true;
        }

        internal bool checkActiveLogin(int active) 
        {
            bool activeBool = false;
            if (active == 1)
                activeBool = true;

            return activeBool;
        }
        internal bool UserExists(string email)
        {
            Dev_DissertationEntities db = new Dev_DissertationEntities();
            return db.Users.Count(e => e.Email == email) > 0;
        }

        internal bool UserHandleExists(string handle)
        {
            Dev_DissertationEntities db = new Dev_DissertationEntities();
            return db.Users.Count(e => e.Handle == handle) > 0;
        }
    }
}