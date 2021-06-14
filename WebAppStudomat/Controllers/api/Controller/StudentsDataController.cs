using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using WebAppStudomat.Controllers.api.Model;
using WebAppStudomat.Models;

namespace WebAppStudomat.Controllers.api.Controller
{
    public class StudentsDataController : ApiController
    {
        private CollegeDbContext db = new CollegeDbContext();

        // GET: api/StudentsData
        public IHttpActionResult GetStudents()
        {
            var list = db.Students.ToList();
            var wrapperClass = new StudentApi { Students = list };

            return Ok(wrapperClass);
        }

        // GET: api/StudentsData/5
        [ResponseType(typeof(StudentApi))]
        public async Task<IHttpActionResult> GetStudents(int id)
        {
            var list = new List<Student>
            {
                await db.Students.FindAsync(id)
            };
            if (list == null)
            {
                return NotFound();
            }
            var wrapperClass = new StudentApi { Students = list };

            return Ok(wrapperClass);
        }
    }
}
