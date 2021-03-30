using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebAppStudomat.Models
{
    public class Major
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }
        public string NameAbbreviation { get; set; }
        public string ViceDeanFirstName { get; set; }
        public string ViceDeanLastName { get; set; }

        public virtual ICollection<Class> Classes { get; set; }
    }
}