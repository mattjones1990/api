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
        public HttpResponseMessage CheckUser([FromBody] LoginCheck login)
        {
            /*
             * CheckIfSqliteInAzure
             * CheckIfSqliteInAzureForDisclaimer
             */
            HttpResponseMessage response = new HttpResponseMessage();
            bool active = false;
 
            if (login.Active == 1)
            {
                active = true;
            }
            //Check if the credentials are in Azure. Return True if they are (worked). Loading > HomePage. Or Login > Homepage.
            if (login.Reason == "CheckIfSqliteInAzure")
            {
                var loginSQL = from u
                           in db.Users
                           where u.Email == login.Email &&
                           u.Password == login.Password &&
                           u.Active == active
                           select u;

                if (loginSQL.Count() < 1)
                {
                    login.Worked = false;
                    login.Reason = "Less than one record returned.";
                }
                else if (loginSQL.Count() > 1)
                {
                    login.Worked = false;
                    login.Reason = "More than one record returned.";
                }
                else if (loginSQL.Count() == 1)
                {
                    login.Worked = true;
                    login.Reason = "One record found.";
                }
                else
                {
                    login.Worked = false;
                    login.Reason = "Major login issue.";
                }

                response = Request.CreateResponse(HttpStatusCode.OK, login);
                return response;
            }

            //Check if the credentials are stored on the Azure Db, if not, go to disclaimer page...Register > Login or Disclaimer
            else if (login.Reason == "CheckIfSqliteInAzureForDisclaimer")
            {
                var loginSQLEmailCheck = from u
                           in db.Users
                              
                               where u.Email == login.Email
                               select u;

                var loginSQLHandleCheck = from u
                            in db.Users
                            where u.Handle == login.Handle
                            select u;

                if (loginSQLEmailCheck.Count() > 0)
                {
                    login.Worked = false;
                    login.Reason = "Email address already exists.";
                }
                else if (loginSQLHandleCheck.Count() > 0)
                {
                    login.Worked = false;
                    login.Reason = "Handle already exists.";
                }
                else
                {
                    login.Worked = true;
                    login.Reason = "Details not found.";
                }

                response = Request.CreateResponse(HttpStatusCode.OK, login);
                return response;
            }

            else
            {
                login.Reason = "Nothing has happened, no legit reason input.";
            }
            response = Request.CreateResponse(HttpStatusCode.OK, login);
            return response;
        }

        [System.Web.Http.Route("api/Login/CreateUser")]
        [System.Web.Http.HttpPost]
        public HttpResponseMessage CreateUser([FromBody] LoginCheck login)
        {
            HttpResponseMessage response = new HttpResponseMessage();
            LoginCheck loginCheck = new LoginCheck();
            if (loginCheck.Validated(login))
            {
                User user = new User();
                user.Email = login.Email;
                user.Password = login.Password;
                user.Handle = login.Handle;
                user.Active = login.checkActiveLogin(login.Active);
                
                //user.UserGuid = Guid.NewGuid();

                //var loginSQLGuidCheck = from u
                //           in db.Users
                //           where u.UserGuid == user.UserGuid
                //           select u;

                //if (loginSQLGuidCheck.Count() > 0)
                //{
                //    loginCheck.Reason = "GUID already exists";
                //    response = Request.CreateResponse(HttpStatusCode.BadRequest, loginCheck);
                //    return response;
                //}

                if (loginCheck.UserExists(user.Email))
                {
                    loginCheck.Reason = "Email already exists";
                    response = Request.CreateResponse(HttpStatusCode.BadRequest, loginCheck);
                    return response;
                }
                if (loginCheck.UserHandleExists(user.Handle))
                {
                    loginCheck.Reason = "Handle already exists.";
                    response = Request.CreateResponse(HttpStatusCode.BadRequest, loginCheck);
                    return response;
                }

                db.Users.Add(user);
                db.SaveChanges();

                if (loginCheck.UserExists(user.Email))
                {
                    loginCheck.Reason = "User created successfully.";
                    response = Request.CreateResponse(HttpStatusCode.Created, loginCheck);
                    return response;
                }
                else
                {
                    loginCheck.Reason = "User record could not be found after registering. Internal Error";
                    response = Request.CreateResponse(HttpStatusCode.BadRequest, loginCheck);
                    return response;
                }
            }
            else
            {
                loginCheck.Reason = "Invalid credentials entered."; //Should never get past front end validation.
                response = Request.CreateResponse(HttpStatusCode.BadRequest, loginCheck);
                return response;
            }
        }
    }
}
