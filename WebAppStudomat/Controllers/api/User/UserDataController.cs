using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using WebAppStudomat.Models;
using WebAppStudomat.Models.Users;

namespace WebAppStudomat.Controllers.api.User
{
    public class UserDataController : ApiController
    {
        private CollegeDbContext db = new CollegeDbContext();

        // GET: api/UserData
        public IQueryable<Models.Users.User> GetUsers()
        {
            return db.Users;
        }

        // GET: api/UserData/5
        [ResponseType(typeof(Models.Users.User))]
        public async Task<IHttpActionResult> GetUser(int id)
        {
            Models.Users.User user = await db.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        // PUT: api/UserData/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutUser(int id, Models.Users.User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != user.IdUser)
            {
                return BadRequest();
            }

            db.Entry(user).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
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

        // POST: api/UserData
        [ResponseType(typeof(Models.Users.User))]
        public async Task<IHttpActionResult> PostUser(Models.Users.User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Users.Add(user);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = user.IdUser }, user);
        }

        // DELETE: api/UserData/5
        [ResponseType(typeof(Models.Users.User))]
        public async Task<IHttpActionResult> DeleteUser(int id)
        {
            Models.Users.User user = await db.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            db.Users.Remove(user);
            await db.SaveChangesAsync();

            return Ok(user);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserExists(int id)
        {
            return db.Users.Count(e => e.IdUser == id) > 0;
        }
    }
}