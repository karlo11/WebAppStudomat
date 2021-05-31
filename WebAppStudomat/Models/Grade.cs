using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebAppStudomat.Models
{
    public class Grade
    {
        [Key]
        public int ID { get; set; }

        public int? StudentID { get; set; }
        [ForeignKey("StudentID")]
        [JsonIgnore]
        public virtual Student Student { get; set; }

        public int? ClassID { get; set; }
        [ForeignKey("ClassID")]
        [JsonIgnore]
        public virtual Class Class { get; set; }

        [Required]
        [Range(1, 5)]
        public int GradeInt { get; set; }

        [JsonIgnore]
        public DateTime _dateOfGrade;
        public DateTime DateOfGrade
        {
            get
            {
                return _dateOfGrade.Date;
            }
            set { _dateOfGrade = value.Date; }
        }
    }
}