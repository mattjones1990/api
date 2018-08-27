using MyApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyApi.Controllers
{
    public class SetController : ApiController
    {
        //private Dev_DissertationEntities db = new Dev_DissertationEntities();

        //[System.Web.Http.Route("api/Set/GetSets/{id}")] //ExerciseId
        //[System.Web.Http.HttpGet]
        //public HttpResponseMessage GetSets(int id)
        //{
        //    HttpResponseMessage response = new HttpResponseMessage();

        //    var WorkoutGroup = from u
        //                       in db.Sets
        //                       where u.ExerciseId == id
        //                       select new { u.SetId, u.Exercise.GymExercise.ExerciseName, u.DateOfSet, u.Weight, u.Reps };

        //    response = Request.CreateResponse(HttpStatusCode.BadRequest, WorkoutGroup);
        //    return response;
        //}
    }
}
