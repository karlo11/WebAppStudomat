using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using WebAppStudomat.Controllers.api.Model;
using WebAppStudomat.Models;

namespace WebAppStudomat.Controllers.api.Controller
{
    public class TeachersDataController : ApiController
    {
        private CollegeDbContext db = new CollegeDbContext();

        // GET: api/TeachersData
        public IHttpActionResult GetTeachers()
        {
            var list = db.Teachers.ToList();
            var wrapperClass = new TeacherApi { Teachers = list };

            return Ok(wrapperClass);
        }

        // GET: api/TeachersData/5
        [ResponseType(typeof(ClassApi))]
        public async Task<IHttpActionResult> GetTeachers(int id)
        {
            var list = new List<Teacher>
            {
                await db.Teachers.FindAsync(id)
            };
            if (list == null)
            {
                return NotFound();
            }
            var wrapperClass = new TeacherApi { Teachers = list };

            return Ok(wrapperClass);
        }
    }
}
