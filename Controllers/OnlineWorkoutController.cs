using MyApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyApi.Controllers
{
    public class OnlineWorkoutController : ApiController
    {
        private Dev_DissertationEntities db = new Dev_DissertationEntities();

        [System.Web.Http.Route("api/OnlineWorkout/AddWorkout")]
        [System.Web.Http.HttpPost]
        public HttpResponseMessage UploadWorkoutToDb([FromBody] OnlineWorkoutFromPhone workout)
        {
            HttpResponseMessage response = new HttpResponseMessage();

            //Get userId based on Guid
            var users = from u in db.Users where u.UserGuid == workout.UsersGuidFromUserTable select u;

            if (users.Count() != 1)
            {
                workout.Reason = "Users <> 1";
            }
            else
            {
                DateTime workoutDateWithoutSeconds =  new DateTime(
                    workout.WorkoutDate.Ticks - (workout.WorkoutDate.Ticks % TimeSpan.TicksPerSecond),
                    workout.WorkoutDate.Kind
                    );

                var user = users.FirstOrDefault();
                var onlineWorkoutsCheck = from o in db.OnlineWorkouts where o.UserId == user.UserId && o.WorkoutDate == workoutDateWithoutSeconds select o;

                if (onlineWorkoutsCheck.Count() > 0)
                {
                    workout.Reason = "Workout Already Submitted";
                }
                else
                {
                    OnlineWorkout onlineWorkout = new OnlineWorkout()
                    {
                        UserId = user.UserId,
                        DateOfSubmission = DateTime.Now,
                        WorkoutDate = workoutDateWithoutSeconds,
                        WorkoutString = workout.WorkoutInformationString
                    };

                    db.OnlineWorkouts.Add(onlineWorkout);
                    db.SaveChanges();

                    workout.Reason = "Worked Correctly";
                }
            }

            response = Request.CreateResponse(HttpStatusCode.OK, workout);
            return response;

        }

        [System.Web.Http.Route("api/OnlineWorkout/GetWorkouts")]
        [System.Web.Http.HttpPost]
        public HttpResponseMessage GetOnlineWorkouts([FromBody] OnlineWorkoutFromPhone workout)
        {
            HttpResponseMessage response = new HttpResponseMessage();

            //Get userId based on Guid
            var users = (from u in db.Users where u.UserGuid == workout.UsersGuidFromUserTable select u) ;
            var user = users.FirstOrDefault();

            var onlineWorkouts = (from o in db.OnlineWorkouts where o.UserId != user.UserId select o).OrderByDescending(o => o.WorkoutDate);

            List<Workout> workouts = new List<Workout>();

            foreach (var item in onlineWorkouts)
            {
                var userForWorkout = (from o in db.Users where o.UserId == item.UserId select o).FirstOrDefault();
                Workout w = new Workout()
                {
                    WorkoutDate = item.WorkoutDate ?? item.DateOfSubmission ?? DateTime.Now,
                    Handle = userForWorkout.Handle,
                    WorkoutString = item.WorkoutString                   
                };
                workouts.Add(w);
            }

            response = Request.CreateResponse(HttpStatusCode.OK, workouts);
            return response;

        }

        [System.Web.Http.Route("api/OnlineWorkout/GetWorkoutsForUser")]
        [System.Web.Http.HttpPost]
        public HttpResponseMessage GetOnlineWorkoutsForUser([FromBody] Workout workout)
        {
            HttpResponseMessage response = new HttpResponseMessage();

            //Get userId based on Guid
            var users = from u in db.Users where u.Handle == workout.Handle select u;
            var user = users.FirstOrDefault();

            var onlineWorkouts = (from o in db.OnlineWorkouts where o.UserId == user.UserId select o).OrderByDescending(o => o.WorkoutDate);

            List<Workout> workouts = new List<Workout>();

            foreach (var item in onlineWorkouts)
            {
                var userForWorkout = (from o in db.Users where o.UserId == item.UserId select o).FirstOrDefault();
                Workout w = new Workout()
                {
                    WorkoutDate = item.WorkoutDate ?? item.DateOfSubmission ?? DateTime.Now,
                    Handle = userForWorkout.Handle,
                    WorkoutString = item.WorkoutString
                };
                workouts.Add(w);
            }

            response = Request.CreateResponse(HttpStatusCode.OK, workouts);
            return response;

        }



        //// GET: api/OnlineWorkout
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET: api/OnlineWorkout/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST: api/OnlineWorkout
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT: api/OnlineWorkout/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/OnlineWorkout/5
        //public void Delete(int id)
        //{
        //}
    }
}
