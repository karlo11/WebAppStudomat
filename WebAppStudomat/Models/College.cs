using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAppStudomat.Models
{
    public class College
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }
        public string Address { get; set; }
        public int FoundationYear { get; set; }
        public string DeanFirstName { get; set; }
        public string DeanLastName { get; set; }

        public virtual ICollection<Major> Majors { get; set; }
    }
}