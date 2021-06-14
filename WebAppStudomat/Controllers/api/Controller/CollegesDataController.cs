using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using WebAppStudomat.Controllers.api.Model;
using WebAppStudomat.Models;

namespace WebAppStudomat.Controllers.api.Controller
{
    public class CollegesDataController : ApiController
    {
        private CollegeDbContext db = new CollegeDbContext();

        // GET: api/CollegesData
        public IHttpActionResult GetColleges()
        {
            var list = db.Colleges.ToList();
            var wrapperClass = new CollegeApi { Colleges = list };

            return Ok(wrapperClass);
        }

        // GET: api/CollegesData/5
        [ResponseType(typeof(CollegeApi))]
        public async Task<IHttpActionResult> GetColleges(int id)
        {
            var list = new List<College>
            {
                await db.Colleges.FindAsync(id)
            };
            if (list == null)
            {
                return NotFound();
            }
            var wrapperClass = new CollegeApi { Colleges = list };

            return Ok(wrapperClass);
        }
    }
}
