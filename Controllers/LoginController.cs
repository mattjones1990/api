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

        [System.Web.Http.Route("api/Login/CheckUser")]
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

            if (loginSQL.Count() < 1)
                return ReturnResult.ReturnNegativeLoginResult("Unsuccessful login, No account found.");

            if (loginSQL.Count() > 1)
                return ReturnResult.ReturnNegativeLoginResult("Unsuccessful login, More than one account found.");

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
                return ReturnResult.ReturnPositiveLoginResult(loginCheck);
            }
            else
            {
                return ReturnResult.ReturnNegativeLoginResult("Unsuccessful Login. Incorrect details supplied.");               
            }

        }

        [System.Web.Http.Route("api/Login/CreateUser")]
        [System.Web.Http.HttpPost]
        public HttpResponseMessage CreateUser([FromBody] LoginCheck login)
        {
            LoginCheck loginCheck = new LoginCheck();
            loginCheck.Email = login.Email;
            loginCheck.Password = login.Password;
            loginCheck.Active = login.Active;
            loginCheck.handle = login.handle;

            if (loginCheck.Validated(loginCheck))
            {
                User user = new User();
                user.Email = loginCheck.Email;
                user.Password = loginCheck.Password;
                user.Handle = loginCheck.handle;
                user.Active = loginCheck.checkActiveLogin(loginCheck.Active);
                                
                db.Users.Add(user);
                db.SaveChanges();

                //if (loginCheck.UserExists(user.Email)) //not working
                //{
                //    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, user);
                //    return response;
                //}
                //else
                //{
                //    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "User record could not be found after registering. Internal Error");
                //}    

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, user);
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Error logging in");
            } 
        }
    }
}
