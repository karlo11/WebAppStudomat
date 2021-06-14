using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAppStudomat.Controllers.api.Model;
using WebAppStudomat.Models;

namespace WebAppStudomat.Controllers.api.Controller
{
    public class TestWrapperClassDataController : ApiController
    {
        private CollegeDbContext db = new CollegeDbContext();

        // GET: api/TestWrapperClassData
        public IHttpActionResult GetTeachers()
        {
            var list = new TestWrapperClassData { Teachers = db.Teachers.ToList() };

            return Ok(list);
        }
    }
}
