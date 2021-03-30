using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebAppStudomat.Models
{
    public class StudentClasses
    {
        [Key]
        public int ID { get; set; }

        public int? StudentID { get; set; }
        [ForeignKey("StudentID")]
        public virtual Student Student { get; set; }
        public int? ClassID { get; set; }
        [ForeignKey("ClassID")]
        public virtual Class Class { get; set; }

        public DateTime _dateOfEnroll;
        public DateTime DateOfEnrollment
        {
            get
            {
                return _dateOfEnroll.Date;
            }
            set { _dateOfEnroll = value.Date; }
        }
    }
}