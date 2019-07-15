using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace UmbracoWebApplicationHOC.Models
{
    public class LoginModel
    {
        [Display(Name = "E-mail")]
        [Required]
        public string Username { get; set; }

        [Display(Name = "Password")]
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}