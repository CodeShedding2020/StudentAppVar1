using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CodeShedding.Models
{
    public class Student
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [Required]
        [Display(Name = "Student Number")]
        public string Student_Number { get; set; }


        [Required]
        [Display(Name = "First Name")]
        public string First_Name { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string Last_Name { get; set; }


        [Display(Name = "Email address")]
        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Display(Name = "Home Address")]
        [Required]
        public string Home_Address { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Contact Number")]
        [Required()]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$",
                   ErrorMessage = "Entered Contact number format is not valid.")]
        public string Mobile { get; set; }

        [Display(Name ="Photo Path")]
        public string Photo_Path { get; set; }

        [Display(Name = "Status")]
        public bool Status{ get; set; }
    }
}