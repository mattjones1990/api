using MyApi.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;


namespace MyApi.Controllers
{
    public class EmployeeController : ApiController
    {
        private Dev_DissertationEntities db = new Dev_DissertationEntities();

        // GET: api/Employees  
        //public ActionResult GetEmployees()
        //{
        //    var emp = from e 
        //              in db.Employees
        //              select e;

        //    return new JsonResult()
        //    {
        //        Data = emp,
        //        JsonRequestBehavior = JsonRequestBehavior.AllowGet
        //    };
        //}

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

        //public ActionResult GetOrders2()
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


        // PUT: api/Employees/5  

        //public HttpResponseMessage PutEmployee(Employee employee)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
        //    }


        //    db.Entry(employee).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException ex)
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
        //    }

        //    return Request.CreateResponse(HttpStatusCode.OK);
        //}

        //// POST: api/Employees  

        //public HttpResponseMessage PostEmployee(Employee employee)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        db.Employees.Add(employee);
        //        db.SaveChanges();
        //        HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, employee);
        //        response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = employee.EmployeeID }));
        //        return response;
        //    }
        //    else
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
        //    }

        //}

        //// DELETE: api/Employees/5  

        //public HttpResponseMessage DeleteEmployee(Employee employee)
        //{
        //    Employee remove_employee = db.Employees.Find(employee.EmployeeID);
        //    if (remove_employee == null)
        //    {
        //        return Request.CreateResponse(HttpStatusCode.NotFound);
        //    }

        //    db.Employees.Remove(remove_employee);
        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException ex)
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
        //    }

        //    return Request.CreateResponse(HttpStatusCode.OK);
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        //private bool EmployeeExists(int id)
        //{
        //    return db.Employees.Count(e => e.EmployeeID == id) > 0;
        //}
    }
}
