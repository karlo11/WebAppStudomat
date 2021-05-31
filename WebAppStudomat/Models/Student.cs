using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAppStudomat.Models
{
    public class Student
    {
        [Key]
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [Required]
        public string JMBAG { get; set; }
        public string OIB { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateOfEnrollment { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }

        [JsonIgnore]
        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }

        [JsonIgnore]
        public string JMBAGAndFullName
        {
            get
            {
                return JMBAG + " - " + FullName;
            }
        }
    }
}