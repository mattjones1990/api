using MyApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Web.Http;

namespace MyApi.Controllers
{
    public class AuditController : ApiController
    {
        private Dev_DissertationEntities db = new Dev_DissertationEntities();

        //[System.Web.Http.Route("api/Audit/AddAudit")] 
        //[System.Web.Http.HttpPost]
        //public HttpResponseMessage AddAudit([FromBody] AuditRecord audit)
        //{
        //    //HttpResponseMessage response = new HttpResponseMessage();

        //    //if (audit.UserId > 0 && !String.IsNullOrWhiteSpace(audit.Comment))
        //    //{
        //    //    Audit a = new Audit(audit.UserId, audit.Comment);

        //    //    Regex reg = new Regex("[*\"_&#^@=]");
        //    //    string newComment = reg.Replace(audit.Comment, " special ");
        //    //    a.Comment = newComment;
        //    //    audit.Comment = newComment;

        //    //    db.Audits.Add(a);
        //    //    db.SaveChanges();

        //    //    response = Request.CreateResponse(HttpStatusCode.Created, audit);
        //    //    return response;
        //    //}
        //    //else
        //    //{
        //    //    response = Request.CreateResponse(HttpStatusCode.BadRequest, audit);
        //    //    return response;
        //    //}
        //}
    }
}
