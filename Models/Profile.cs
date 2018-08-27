using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyApi.Models
{
    public class Profile
    {
        public string Location { get; set; }
        public string Bio { get; set; }
        public int Age { get; set; }
        public string Name { get; set; }
        public Guid UserGuid { get; set; }
    }
}