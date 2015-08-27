using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace wb.Models
{
    public class register
    {
        public string pseudonym { get; set; }
        public string password { get; set; }
        public string passwordConfirm { get; set; }
        public bool agree { get; set; }
    }
}