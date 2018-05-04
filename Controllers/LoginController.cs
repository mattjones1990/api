using MyApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace MyApi.Controllers
{
    public class LoginController : ApiController
    {
        private Dev_DissertationEntities db = new Dev_DissertationEntities();

        [System.Web.Http.HttpPost]
        public ActionResult CheckUser([FromBody] LoginCheck login)
        {
            //string extraCheck = "FAF3C5A4-D949-E811-811F-0CC47A480E0C";
            //loginCheck.Email = Security.Decrypt(Security.Decrypt(login.Email, extraCheck), extraCheck);
            //loginCheck.Password = Security.Decrypt(Security.Decrypt(login.Password, extraCheck), extraCheck);
            LoginCheck loginCheck = new LoginCheck();
            loginCheck.Email = login.Email;
            loginCheck.Password = login.Password;
            loginCheck.Active = login.Active;

            bool active = false;

            if (login.Active == 1)
            {
                active = true;
            }

            var loginSQL = from u
                           in db.Users
                           where u.Email == loginCheck.Email && 
                           u.Password == loginCheck.Password &&
                           u.Active == active
                           select u;

            if (loginSQL.Count() == 1)
            {
                loginCheck.Reason = "Successful Login";
                loginCheck.handle = login.handle;
                loginCheck.Id = loginSQL.FirstOrDefault().UserId;
                loginCheck.Email = loginSQL.FirstOrDefault().Email;
                loginCheck.Password = loginSQL.FirstOrDefault().Password;

                int activeInt = 0;
                if (loginSQL.FirstOrDefault().Active == true)
                {
                    activeInt = 1;
                }

                loginCheck.Active = activeInt;
                return new JsonResult()
                {
                    Data = loginCheck,
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };
            }
            else
            {
                LoginCheck incorrectLogin = new LoginCheck();
                incorrectLogin.Reason = "Unsuccessful Login. Incorrect details supplied.";
                return new JsonResult()
                {
                    Data = incorrectLogin,
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };
            }
        }
    }
}
