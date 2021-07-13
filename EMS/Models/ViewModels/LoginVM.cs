using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EMS.Models.ViewModels
{
    public class LoginVM
    {
        [Required(ErrorMessage = "User Name Can't be Null"), Display(Name = "Name"), StringLength(50)]
        public string UserName { get; set; }
        [Required(ErrorMessage = "User Name Can't be Null"), Display(Name = "Password")]
        public string Password { get; set; }
    }
}