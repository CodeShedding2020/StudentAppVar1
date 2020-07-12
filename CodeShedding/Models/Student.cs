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
        [JsonProperty(PropertyName = "Student Number")]
        [StringLength(8, MinimumLength = 8, ErrorMessage = "This field must be 8 characters")]
        [Display(Name = "Student Number")]
        public string Student_Number { get; set; }


        [Required]
        [JsonProperty(PropertyName = "First Name")]
        [StringLength(20, ErrorMessage = "This field cannot contain more than 20 characters")]
        [Display(Name = "First Name")]
        public string First_Name { get; set; }

        [Required]
        [JsonProperty(PropertyName = "Last Name")]
        [StringLength(20, ErrorMessage = "This field cannot contain more than 20 characters")]
        [Display(Name = "Last Name")]
        public string Last_Name { get; set; }


        [Display(Name = "Email address")]
        [JsonProperty(PropertyName = "Email address")]
        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Display(Name = "Home Address")]
        [JsonProperty(PropertyName = "Home Address")]
        [Required]
        public string Home_Address { get; set; }

        [DataType(DataType.PhoneNumber)]
        [JsonProperty(PropertyName = "Contact Number")]
        [Display(Name = "Contact Number")]
        [Required()]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$",
                   ErrorMessage = "Entered Contact number format is not valid.")]
        public string Mobile { get; set; }

        
        [Display(Name ="Photo Path")]
        [JsonProperty(PropertyName = "Photo Path")]
        public string Photo_Path { get; set; }

        [Required]
        [JsonProperty(PropertyName = "Status")]
        [Display(Name = "Status")]
        public bool Status{ get; set; }
    }
}