using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeShedding.Models
{
    public class StudentInfo
    {

        [JsonProperty(PropertyName = "studentNumber")]
        public string StudentNo { get; set; }

        [JsonProperty(PropertyName = "firstName")]
        public string FirstName { get; set; }

        [JsonProperty(PropertyName = "lastName")]
        public string LastName { get; set; }

        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }

        [JsonProperty(PropertyName = "mobileNumber")]
        public string Mobile { get; set; }

        [JsonProperty(PropertyName = "homeAddress")]
        public string HomeAddress { get; set; }

        [JsonProperty(PropertyName = "image")]
        public byte[] Image { get; set; }

        [JsonProperty(PropertyName = "isActive")]
        public bool IsActive { get; set; }


    }
}