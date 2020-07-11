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

        [JsonProperty(PropertyName = "Student Number")]
        [Required]
        [StringLength(8, MinimumLength = 8, ErrorMessage = "This field must be 8 characters")]
        [Display(Name = "Student Number")]
        public string Student_Number { get; set; }


        [JsonProperty(PropertyName = "First Name")]
        [Required]
        [StringLength(20, ErrorMessage = "This field cannot contain more than 20 characters")]
        [Display(Name = "First Name")]
        public string First_Name { get; set; }

        [JsonProperty(PropertyName = "Last Name")]
        [Required]
        [StringLength(20, ErrorMessage = "This field cannot contain more than 20 characters")]
        [Display(Name = "Last Name")]
        public string Last_Name { get; set; }


        [JsonProperty(PropertyName = "Email address")]
        [Display(Name = "Email address")]
        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [JsonProperty(PropertyName = "Home Address")]
        [Required]
        [Display(Name = "Home Address")]
        public string Home_Address { get; set; }

        [JsonProperty(PropertyName = "Contact Number")]
        [Required()]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Contact Number")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$",
                   ErrorMessage = "Entered Contact number format is not valid.")]
        public string Mobile { get; set; }

        [JsonProperty(PropertyName = "Photo Path")]
        [Display(Name ="Photo Path")]
        public string Photo_Path { get; set; }
       
        
        [JsonProperty(PropertyName = "Status")]
        [Required]
        [Display(Name = "Status")]
        public bool Status{ get; set; }
    }
}