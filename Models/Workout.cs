using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyApi.Models
{
    public class Workout
    {
        public string Handle { get; set; }
        public string WorkoutString { get; set; }
        public DateTime WorkoutDate { get; set; }
        public Guid UserGuid { get; set; }
    }
}