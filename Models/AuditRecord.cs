using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyApi.Models
{
    public class AuditRecord
    {
        public int UserId { get; set; }
        public string Comment { get; set; }
    }
}