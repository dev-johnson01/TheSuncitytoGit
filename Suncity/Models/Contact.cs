using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Suncity.Models
{
    public class Contact
    {
        [Required(ErrorMessage ="FullName is Required")]
        public string FullName { get; set; }
        [Display(Name ="Email")]
        [Required(ErrorMessage = "Email is Required")]
        [EmailAddress]
        public string UserEmail { get; set; }
        [Phone]
        [Required(ErrorMessage = "Phone Number is Required")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Message is Required")]
        public string MessageBody { get; set; }

    }
}