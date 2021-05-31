using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using WebAppStudomat.Models;

namespace WebAppStudomat.Controllers.api
{
    public class MajorDataController : ApiController
    {
        private CollegeDbContext db = new CollegeDbContext();

        // GET: api/MajorData
        public IQueryable<Major> GetMajors()
        {
            return db.Majors;
        }

        // GET: api/MajorData/5
        [ResponseType(typeof(Major))]
        public async Task<IHttpActionResult> GetMajor(int id)
        {
            Major major = await db.Majors.FindAsync(id);
            if (major == null)
            {
                return NotFound();
            }

            return Ok(major);
        }

        // PUT: api/MajorData/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutMajor(int id, Major major)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != major.ID)
            {
                return BadRequest();
            }

            db.Entry(major).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MajorExists(id))
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

        // POST: api/MajorData
        [ResponseType(typeof(Major))]
        public async Task<IHttpActionResult> PostMajor(Major major)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Majors.Add(major);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = major.ID }, major);
        }

        // DELETE: api/MajorData/5
        [ResponseType(typeof(Major))]
        public async Task<IHttpActionResult> DeleteMajor(int id)
        {
            Major major = await db.Majors.FindAsync(id);
            if (major == null)
            {
                return NotFound();
            }

            db.Majors.Remove(major);
            await db.SaveChangesAsync();

            return Ok(major);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MajorExists(int id)
        {
            return db.Majors.Count(e => e.ID == id) > 0;
        }
    }
}