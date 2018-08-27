using MyApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyApi.Controllers
{
    public class GymExerciseController : ApiController
    {
        //private Dev_DissertationEntities db = new Dev_DissertationEntities();

        //[System.Web.Http.Route("api/GymExercise/GetAllExercises")]
        //[System.Web.Http.HttpGet]
        //public HttpResponseMessage GetAllExercises()
        //{
        //    HttpResponseMessage response = new HttpResponseMessage();

        //    var exerciseGroup = from u
        //                      in db.GymExercises
        //                      select new {u.GymExerciseId, u.ExerciseName, u.BigFour };

        //    response = Request.CreateResponse(HttpStatusCode.BadRequest, exerciseGroup);
        //    return response;
        //}

        //[System.Web.Http.Route("api/GymExercise/GetExercisesByMuscleGroup/{id}")]
        //[System.Web.Http.HttpGet]
        //public HttpResponseMessage GetExerciseByMuscleGroup(int id)
        //{
        //    HttpResponseMessage response = new HttpResponseMessage();

        //    var exerciseGroup = from u
        //                        in db.GymExercises
        //                        where u.MuscleGroupId == id
        //                        select new { u.GymExerciseId, u.ExerciseName, u.BigFour };

        //    response = Request.CreateResponse(HttpStatusCode.BadRequest, exerciseGroup);
        //    return response;
        //}

        //[System.Web.Http.Route("api/GymExercise/GetExercise/{id}")]
        //[System.Web.Http.HttpGet]
        //public HttpResponseMessage GetExercise(int id)
        //{
        //    HttpResponseMessage response = new HttpResponseMessage();

        //    var exerciseGroup = from u
        //                        in db.GymExercises
        //                        where u.GymExerciseId == id
        //                        select new { u.GymExerciseId, u.ExerciseName, u.BigFour };

        //    response = Request.CreateResponse(HttpStatusCode.BadRequest, exerciseGroup);
        //    return response;
        //}
    }
}
