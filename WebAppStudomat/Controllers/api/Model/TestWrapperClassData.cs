using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAppStudomat.Models;

namespace WebAppStudomat.Controllers.api.Model
{
    public class TestWrapperClassData
    {
        public List<Teacher> Teachers { get; set; }
    }

    public class ClassApi
    {
        public List<Class> Classes { get; set; }
    }

    public class CollegeApi
    {
        public List<College> Colleges { get; set; }
    }

    public class GradeApi
    {
        public List<Grade> Grades { get; set; }
    }

    public class MajorApi
    {
        public List<Major> Majors { get; set; }
    }

    public class StudentApi
    {
        public List<Student> Students { get; set; }
    }

    public class TeacherApi
    {
        public List<Teacher> Teachers { get; set; }
    }
}