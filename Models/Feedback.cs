using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace wb.Models
{
    public class Feedback
    {
        public string feedback { get; set; }
        public string sentBy { get; set; }

    }
}