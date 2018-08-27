using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyApi.Models
{
    public class SetOnline
    {
        public string Handle { get; set; }
        public int Reps { get; set; }
        public decimal Weight { get; set; }
        public DateTime Date { get; set; }
        public string ExerciseName { get; set; }
    }
}