using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using WebAppStudomat.Controllers.api.Model;
using WebAppStudomat.Models;

namespace WebAppStudomat.Controllers.api.Controller
{
    public class GradesDataController : ApiController
    {
        private CollegeDbContext db = new CollegeDbContext();

        // GET: api/GradesData
        public IHttpActionResult GetGrades()
        {
            var list = db.Grades.ToList();
            var wrapperClass = new GradeApi { Grades = list };

            return Ok(wrapperClass);
        }

        // GET: api/GradesData/5
        [ResponseType(typeof(GradeApi))]
        public async Task<IHttpActionResult> GetGrades(int id)
        {
            var list = new List<Grade>
            {
                await db.Grades.FindAsync(id)
            };
            if (list == null)
            {
                return NotFound();
            }
            var wrapperClass = new GradeApi { Grades = list };

            return Ok(wrapperClass);
        }
    }
}
