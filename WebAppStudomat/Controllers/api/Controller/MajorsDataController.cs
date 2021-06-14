using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using WebAppStudomat.Controllers.api.Model;
using WebAppStudomat.Models;

namespace WebAppStudomat.Controllers.api.Controller
{
    public class MajorsDataController : ApiController
    {
        private CollegeDbContext db = new CollegeDbContext();

        // GET: api/MajorsData
        public IHttpActionResult GetMajors()
        {
            var list = db.Majors.ToList();
            var wrapperClass = new MajorApi { Majors = list };

            return Ok(wrapperClass);
        }

        // GET: api/MajorsData/5
        [ResponseType(typeof(MajorApi))]
        public async Task<IHttpActionResult> GetMajors(int id)
        {
            var list = new List<Major>
            {
                await db.Majors.FindAsync(id)
            };
            if (list == null)
            {
                return NotFound();
            }
            var wrapperClass = new MajorApi { Majors = list };

            return Ok(wrapperClass);
        }
    }
}
