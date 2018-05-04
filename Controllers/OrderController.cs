using MyApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using System.Data.Entity;

namespace MyApi.Controllers
{
    public class OrderController : ApiController
    {
        private Dev_DissertationEntities db = new Dev_DissertationEntities();
        //public ActionResult GetOrders()
        //{
        //    var emp = from e
        //              in db.Orders
        //              select e;


        //    return new JsonResult()
        //    {
        //        Data = emp,
        //        JsonRequestBehavior = JsonRequestBehavior.AllowGet
        //    };
        //}

        //public ActionResult JoinOrders()
        //{
        //    var emp = from e
        //              in db.Orders
        //              join p in db.Persons on e.PersonID equals p.PersonID
        //              select e;

        //    return new JsonResult()
        //    {
        //        Data = emp,
        //        JsonRequestBehavior = JsonRequestBehavior.AllowGet
        //    };
        //}
    }
}
