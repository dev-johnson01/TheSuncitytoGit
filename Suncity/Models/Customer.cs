using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Suncity.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        
        [Required(ErrorMessage ="FirstName is Required")]
        public String FirstName { get; set; }

        [Required(ErrorMessage ="LastName is Required")]
        public string LastName { get; set; }

        [Required(ErrorMessage ="Email Address is Required")]
        [EmailAddress(ErrorMessage = "Invalid Email address")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name ="Phone Number")]
        [DataType(DataType.PhoneNumber)]
        [Phone(ErrorMessage ="invalid Phone number")]
        [Required(ErrorMessage ="Phone number is required")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        [DataType(DataType.MultilineText)]
        public string Address { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Please confirm your Password")]

        public string ConfirmPassword { get; set; }
       
        [ScaffoldColumn(false)]
        public DateTime DateRegistered { get; set; }

    }
}