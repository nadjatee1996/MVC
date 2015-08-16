using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace wb.Models
{
    public class User
    { 
        public string username { get; set; }
        public string password { get; set; }
        public string passwordConfirm { get; set; }
        public string email { get; set; }
        public bool agree { get; set; }

    }
}