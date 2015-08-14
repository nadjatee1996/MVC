using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace wb.Models
{
    public class User
    { 
        [Required(ErrorMessage = "Please provide username", AllowEmptyStrings = false)]
        public string username { get; set; }
        [Required(ErrorMessage = "Please provide password", AllowEmptyStrings = false)]
        public string password { get; set; }
        [Required(ErrorMessage = "Please confirm your password", AllowEmptyStrings = false)]
        public string passwordConfirm { get; set; }
        public string email { get; set; }
        [Required(ErrorMessage = "You have not agreed to the terms and agreements", AllowEmptyStrings = false)]
        public bool agree { get; set; }

    }
}