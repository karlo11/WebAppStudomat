using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebAppStudomat.Models
{
    public class Class
    {
        [Key]
        public int ID { get; set; }
        public string Details { get; set; }
        public string ISVUNumber { get; set; }

        [Range(1, 200)]
        public int? HoursOfLectures { get; set; } = 0;
        public int? HoursOfAudit { get; set; } = 0;
        public int? HoursOfLab { get; set; } = 0;
        public int? HoursOfSeminar { get; set; } = 0;
        public int? HoursOfConstr { get; set; } = 0;
        [Range(0, 400)]
        public int? HoursOfHomework { get; set; } = 0;

        [Required]
        public string Name { get; set; }
        [Required]
        [Range(1, 20)]
        public int NumberOfECTS { get; set; }
        [Range(1, 6)]
        public int Semester { get; set; }

        public int? TeacherID { get; set; }
        [ForeignKey("TeacherID")]
        public virtual Teacher Teacher { get; set; }

        public int? MajorID { get; set; }
        [ForeignKey("MajorID")]
        public virtual Major Major { get; set; }

        public string NameAndSemester
        {
            get
            {
                return Name + " - " + Semester;
            }
        }

        public string MajorSemesterNameEcts
        {
            get
            {
                return Major.Name + " (" + Semester + " sem.) - " + Name + " (" + NumberOfECTS + " ECTS)";
            }
        }

        public string HoursOfWork
        {
            get
            {
                return (HoursOfAudit + HoursOfConstr + HoursOfLab + HoursOfLectures + HoursOfSeminar)
                    .ToString()
                    + " + " + HoursOfHomework;
            }
        }
    }
}