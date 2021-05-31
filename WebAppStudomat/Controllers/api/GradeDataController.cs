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
    public class GradeDataController : ApiController
    {
        private CollegeDbContext db = new CollegeDbContext();

        // GET: api/GradeData
        public IQueryable<Grade> GetGrades()
        {
            return db.Grades;
        }

        // GET: api/GradeData/5
        [ResponseType(typeof(Grade))]
        public async Task<IHttpActionResult> GetGrade(int id)
        {
            Grade grade = await db.Grades.FindAsync(id);
            if (grade == null)
            {
                return NotFound();
            }

            return Ok(grade);
        }

        // PUT: api/GradeData/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutGrade(int id, Grade grade)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != grade.ID)
            {
                return BadRequest();
            }

            db.Entry(grade).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GradeExists(id))
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

        // POST: api/GradeData
        [ResponseType(typeof(Grade))]
        public async Task<IHttpActionResult> PostGrade(Grade grade)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Grades.Add(grade);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = grade.ID }, grade);
        }

        // DELETE: api/GradeData/5
        [ResponseType(typeof(Grade))]
        public async Task<IHttpActionResult> DeleteGrade(int id)
        {
            Grade grade = await db.Grades.FindAsync(id);
            if (grade == null)
            {
                return NotFound();
            }

            db.Grades.Remove(grade);
            await db.SaveChangesAsync();

            return Ok(grade);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GradeExists(int id)
        {
            return db.Grades.Count(e => e.ID == id) > 0;
        }
    }
}