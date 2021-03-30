using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAppStudomat.Models
{
    public class Teacher
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string OIB { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Title { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }

        public string FullNameWithTitle
        {
            get
            {
                return Title + " " + FirstName + " " + LastName;
            }
        }
        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }
    }
}