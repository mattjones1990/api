using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Results;
using System.Web.Mvc;

namespace MyApi.Models
{
    public class ReturnResult
    {
        internal static JsonResult ReturnPositiveLoginResult(LoginCheck login)
        {
            login.Reason = "Good";

            return new JsonResult()
            {
                Data = login,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
        internal static JsonResult ReturnNegativeLoginResult(string reason)
        {
            LoginCheck incorrectLogin = new LoginCheck();
            incorrectLogin.Reason = reason;

            return new JsonResult()
            {
                Data = incorrectLogin,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
    }
}