using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using WebAppStudomat.Models;

namespace WebAppStudomat.Controllers.api
{
    public class ClassDataController : ApiController
    {
        private CollegeDbContext db = new CollegeDbContext();

        // GET: api/ClassData
        public IHttpActionResult GetClasses()
        {
            return Ok(db.Classes);
        }

        // GET: api/ClassData/5
        [ResponseType(typeof(Class))]
        public async Task<IHttpActionResult> GetClass(int id)
        {
            Class @class = await db.Classes.FindAsync(id);
            if (@class == null)
            {
                return NotFound();
            }

            return Ok(@class);
        }

        // PUT: api/ClassData/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutClass(int id, Class @class)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != @class.ID)
            {
                return BadRequest();
            }

            db.Entry(@class).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClassExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/ClassData
        [ResponseType(typeof(Class))]
        public async Task<IHttpActionResult> PostClass(Class @class)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Classes.Add(@class);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = @class.ID }, @class);
        }

        // DELETE: api/ClassData/5
        [ResponseType(typeof(Class))]
        public async Task<IHttpActionResult> DeleteClass(int id)
        {
            Class @class = await db.Classes.FindAsync(id);
            if (@class == null)
            {
                return NotFound();
            }

            db.Classes.Remove(@class);
            await db.SaveChangesAsync();

            return Ok(@class);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ClassExists(int id)
        {
            return db.Classes.Count(e => e.ID == id) > 0;
        }
    }
}