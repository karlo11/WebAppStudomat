using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using WebAppStudomat.Controllers.api.Model;
using WebAppStudomat.Models;

namespace WebAppStudomat.Controllers.api.Controller
{
    public class ClassesDataController : ApiController
    {
        private CollegeDbContext db = new CollegeDbContext();

        // GET: api/ClassesData
        public IHttpActionResult GetClasses()
        {
            var list = db.Classes.ToList();
            var wrapperClass = new ClassApi { Classes = list };

            return Ok(wrapperClass);
        }

        // GET: api/ClassesData/5
        [ResponseType(typeof(ClassApi))]
        public async Task<IHttpActionResult> GetClasses(int id)
        {
            var list = new List<Class>
            {
                await db.Classes.FindAsync(id)
            };
            if (list == null)
            {
                return NotFound();
            }
            var wrapperClass = new ClassApi { Classes = list };

            return Ok(wrapperClass);
        }
    }
}
