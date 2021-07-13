using EMS.CustomValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EMS.Models.ViewModels
{
    public class EmployeeViewModel
    {
        public int eId { get; set; }
        public string Title { get; set; }
        [Display(Name ="Name")]
        [Required(ErrorMessage = "It cannot remain empty")]
        public string eName { get; set; }
        [Required, Display(Name = "Birth Day")]
        [Column(TypeName = "date")]
        [LessDate]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public System.DateTime DateOfBirth { get; set; }
        [Display(Name ="Gender")]
        [Required(ErrorMessage = "Gender can't Null or Empty")]
        public string eGender { get; set; }
        [Display(Name ="Phone No")]
        public string PhoneNo { get; set; }

        [Required(ErrorMessage = "It cannot remain empty")]
        [ForeignKey("tblPosition")]
        [Display(Name ="Position")]
        public Nullable<int> positionId { get; set; }
        [Display(Name ="Profil Picture")]
        public string eImage { get; set; }
        
        public HttpPostedFileBase Picture { get; set; }
        
    }
}