using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EMS.Models.ViewModels
{
    public class RegVM
    {
        [Required(ErrorMessage ="User Name Can't be Null"),Display(Name ="Name"),StringLength(50)]
        public string UserNmae { get; set; }
        [Required(ErrorMessage = "User Email Can't be Null"), Display(Name = "Email"), StringLength(50),EmailAddress(ErrorMessage ="Provide Valid Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "User Password Can't be Null"), Display(Name = "Password")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Confirm Password Can't be Null"),System.ComponentModel.DataAnnotations.Compare("Password",ErrorMessage ="Password and Confirm password should be same."),Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }
    }
}