using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyApi.Models
{
    public class LoginCheck
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string handle { get; set; }
        public string Password { get; set; }
        public int Active { get; set; }
        public string Reason { get; set; }
        public LoginCheck()
        {
            
        }
    }
}