using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations; 

namespace Suncity.Models
{
    public class Agent
    {
        [Key]
        public int AgentId { get; set; }
        [Required(ErrorMessage ="FirstName is required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "SurName is required")]
        public string SurName { get; set; }
        public string OtherName { get; set; }
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Date of Birth is required")]
        public DateTime DateOfBirth { get; set; }

        [Phone(ErrorMessage = "Invalid Phone Number")]
        [Required(ErrorMessage = "Phone Number is required")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
        
        [Phone(ErrorMessage ="Invalid Phone Number")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber2 { get; set; }

        [Required(ErrorMessage = "Date of Birth is required")]
        [EmailAddress(ErrorMessage ="Invalid Email Address")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Address is required")]
        [DataType(DataType.MultilineText)]
        public string  Address { get; set; }
        
        [DataType(DataType.MultilineText)]
        public string Address2 { get; set; }

        [Required(ErrorMessage = "Occupation is required")]       
        public string Occupation { get; set; }

        [Required(ErrorMessage = "Gender is required")]        
        public AgentGender Gender { get; set; }
        [Display(Name ="Relationship Status")]
        public Relationship RelationshipStatus { get; set; }
        [Display(Name = "State Of Origin")]
        [Required(ErrorMessage = "state of origin is required")]
        public AgentOrigin StateOfOrigin { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
    public enum AgentGender
    { 
        Gender,
        Male,
        Female
    }
    public enum Relationship
    {
        Status,
        Single,
        Married,
        engaged

    }
    public enum AgentOrigin
    {
        States,
        Abia,
        Adamawa,
        AkwaIbom,
        Anambra,
        Bauch,
        Bayalsa,
        CrossRiver,
        Delta,
        Ebonyi,
        Edo,
        Ekiti,
        Enugu,
        Imo,
        Jigawa,
        Kaduna,
        kano,
        Kastina,
        Kebbi,
        Kogi,
        Kwara,
        Lagos,
        Niger,
        Ogun,
        Ondo,
        Osun,
        Oyo,
        Plateau,
        Rivers,
        Sokoto,
        Taraba,
        Yobe,
        Zamfara,
        FCT
    }
}