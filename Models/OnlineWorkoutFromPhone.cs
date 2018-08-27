using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyApi.Models
{
    public class OnlineWorkoutFromPhone
    {
        public Guid UsersGuidFromUserTable { get; set; }
        public string WorkoutInformationString { get; set; }
        public DateTime DateOfSubmission { get; set; }
        public DateTime WorkoutDate { get; set; }
        public int WorkoutNumber { get; set; }
        public string Reason { get; set; }
    }
}