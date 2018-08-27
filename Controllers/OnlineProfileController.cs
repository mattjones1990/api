using MyApi.Models;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace MyApi.Controllers
{
    public class OnlineProfileController : ApiController
    {
        private Dev_DissertationEntities db = new Dev_DissertationEntities();

        [System.Web.Http.Route("api/OnlineProfile/GetProfile")]
        [System.Web.Http.HttpPost]
        public HttpResponseMessage GetOnlineProfileForUser([FromBody] Guid guid)
        {
            HttpResponseMessage response = new HttpResponseMessage();

            //GET USER BASED ON GUID
            var users = from u
                        in db.Users
                        where u.UserGuid == guid
                        select u; ;

            var user = users.FirstOrDefault();

            var profiles = from p
                           in db.OnlineProfiles
                           where p.UserId == user.UserId
                           select p;

            var profile = profiles.FirstOrDefault();

            var newProfileObject = new Profile()
            {
                Age = profile.Age ?? default(int),
                Bio = profile.Bio,
                Name = profile.Name,
                Location = profile.Location
            };

            response = Request.CreateResponse(HttpStatusCode.OK, newProfileObject);
            return response;

        }

        [System.Web.Http.Route("api/OnlineProfile/UpdateProfile")]
        [System.Web.Http.HttpPost]
        public HttpResponseMessage UpdateOnlineProfileForUser([FromBody] Profile profile)
        {
            HttpResponseMessage response = new HttpResponseMessage();

            //GET USER BASED ON GUID
            var users = from u
                        in db.Users
                        where u.UserGuid == profile.UserGuid
                        select u; ;

            var user = users.FirstOrDefault();

            var profiles = from p
                           in db.OnlineProfiles
                           where p.UserId == user.UserId
                           select p;

            var individualProfile = profiles.FirstOrDefault();

            individualProfile.Name = profile.Name;
            individualProfile.Age = profile.Age;
            individualProfile.Bio = profile.Bio;
            individualProfile.Location = profile.Location;

            db.SaveChanges();

            response = Request.CreateResponse(HttpStatusCode.OK, profile);
            return response;
        }

        [System.Web.Http.Route("api/OnlineProfile/GetProfileByHandle")]
        [System.Web.Http.HttpPost]
        public HttpResponseMessage GetOnlineProfileForUserByHandle([FromBody] String handle)
        {
            HttpResponseMessage response = new HttpResponseMessage();

            //GET USER BASED ON GUID
            var users = from u
                        in db.Users
                        where u.Handle == handle
                        select u; ;

            var user = users.FirstOrDefault();

            var profiles = from p
                           in db.OnlineProfiles
                           where p.UserId == user.UserId
                           select p;

            var profile = profiles.FirstOrDefault();

            var newProfileObject = new Profile()
            {
                Age = profile.Age ?? default(int),
                Bio = profile.Bio,
                Name = profile.Name,
                Location = profile.Location
            };

            response = Request.CreateResponse(HttpStatusCode.OK, newProfileObject);
            return response;
        }


        [System.Web.Http.Route("api/OnlineProfile/GetProfilesByHandle")]
        [System.Web.Http.HttpPost]
        public HttpResponseMessage GetOnlineProfileForUsersByHandle([FromBody] ProfileHandles handle)
        {
            HttpResponseMessage response = new HttpResponseMessage();
            var h = handle.Handle;
            var users = (from u in db.Users where u.Handle.Contains(h) select u.Handle).ToList();
            handle.Handles = users;

            response = Request.CreateResponse(HttpStatusCode.OK, handle);
            return response;
        }
    }
}