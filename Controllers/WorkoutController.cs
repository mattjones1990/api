using MyApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyApi.Controllers
{
    public class WorkoutController : ApiController
    {
        //private Dev_DissertationEntities db = new Dev_DissertationEntities();

        //[System.Web.Http.Route("api/Workout/GetAllWorkouts")]
        //[System.Web.Http.HttpGet]
        //public HttpResponseMessage GetAllWorkouts()
        //{
        //    HttpResponseMessage response = new HttpResponseMessage();

        //    var WorkoutGroup = from u
        //                       in db.Workouts
        //                       select new { u.WorkoutId, u.UserId, u.DateOfWorkout, u.Completed };

        //    response = Request.CreateResponse(HttpStatusCode.BadRequest, WorkoutGroup);
        //    return response;
        }

        
    
}


//public int SetId { get; set; }
//public Nullable<int> WorkoutId { get; set; }
//public Nullable<int> GymExerciseId { get; set; }
//public System.DateTime DateOfSet { get; set; }
//public decimal Weight { get; set; }
//public int Reps { get; set; }


//public virtual GymExercise GymExercise { get; set; }
//public virtual Workout Workout { get; set; }

////////*
////// *         public int WorkoutId { get; set; }
//////        public Nullable<int> UserId { get; set; }
//////        public System.DateTime DateOfWorkout { get; set; }
//////        public bool Completed { get; set; }
////// * /


//var innerJoinQuery =
//    from category in categories
//    join prod in products on category.ID equals prod.CategoryID
//    select new { ProductName = prod.Name, Category = category.Name }; //produces flat sequence
