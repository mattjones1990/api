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
        private Dev_DissertationEntities db = new Dev_DissertationEntities();

        [System.Web.Http.Route("api/OnlineSet/AddSetForUser")]
        [System.Web.Http.HttpPost]
        public HttpResponseMessage AddSet([FromBody] SetOnline set)
        {
            HttpResponseMessage response = new HttpResponseMessage();

            OnlineSet newSet = new OnlineSet()
            {
                Handle = set.Handle,
                Reps = set.Reps,
                Weight = set.Weight,
                Date = DateTime.Now,
                ExerciseName = set.ExerciseName
            };

            db.OnlineSets.Add(newSet);
            db.SaveChanges();

            response = Request.CreateResponse(HttpStatusCode.OK, set);
            return response;

        }

        [System.Web.Http.Route("api/OnlineSet/GetSets")]
        [System.Web.Http.HttpPost]
        public HttpResponseMessage GetSets([FromBody] SetOnline set)
        {
            HttpResponseMessage response = new HttpResponseMessage();
            //IOrderedQueryable<OnlineSet> onlineSet;
            var onlineSet = new List<OnlineSet>();

            if (set.Handle == "Empty")
            {
                onlineSet = (from u
                                 in db.OnlineSets
                                 where u.Reps == set.Reps
                                 where u.ExerciseName == set.ExerciseName
                                 select u).OrderBy(u => u.Weight).ToList();
            }
            else
            {
                onlineSet = (from u
                                in db.OnlineSets
                                 where u.Reps == set.Reps
                                 where u.ExerciseName == set.ExerciseName
                                 where u.Handle.Contains(set.Handle)
                                 select u).OrderBy(u => u.Weight).ToList();
            }

            List<SetOnline> setOnline = new List<SetOnline>();
            foreach (var item in onlineSet)
            {
                SetOnline s = new SetOnline
                {
                    Reps = item.Reps ?? default(int),
                    Weight = item.Weight ?? default(decimal),
                    ExerciseName = item.ExerciseName,
                    Handle = item.Handle
                };
                setOnline.Add(s);
            }


            response = Request.CreateResponse(HttpStatusCode.OK, setOnline);
            return response;

        }
    }
}
