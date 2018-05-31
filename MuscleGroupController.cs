using MyApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace MyApi.Controllers
{
    public class MuscleGroupController : ApiController
    {
        private Dev_DissertationEntities db = new Dev_DissertationEntities();

        [System.Web.Http.Route("api/MuscleGroup/GetMuscleGroups")]
        [System.Web.Http.HttpGet]
        public HttpResponseMessage GetMuscleGroups()
        {
            HttpResponseMessage response = new HttpResponseMessage();

            var muscleGroup = from u
                              in db.MuscleGroups
                              select new { u.MuscleGroupId, u.MuscleGroupName };

            response = Request.CreateResponse(HttpStatusCode.BadRequest, muscleGroup);
            return response;
        }
    }
}