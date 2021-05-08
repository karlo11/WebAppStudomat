using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using WebAppStudomat.Attributes;
using WebAppStudomat.Models;
using WebAppStudomat.Models.Users;

namespace WebAppStudomat.Controllers
{
    [CustomAuthorize(UserRoles.Admin, UserRoles.Teacher)]
    public class GradesController : Controller
    {
        private CollegeDbContext db = new CollegeDbContext();

        // GET: Grades
        public ActionResult Index()
        {
            var grades = db.Grades.Include(g => g.Class).Include(g => g.Student);
            return View(grades.ToList()
                .OrderBy(x => x.Class.Name)
                .ThenByDescending(y => y.GradeInt)
                .ThenBy(z => z.Student.FullName));
        }

        // GET: Grades/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Grade grade = db.Grades.Find(id);
            if (grade == null)
            {
                return HttpNotFound();
            }
            return View(grade);
        }

        // GET: Grades/Create
        public ActionResult Create()
        {
            ViewBag.ClassID = new SelectList(db.Classes, "ID", "MajorSemesterNameEcts");
            ViewBag.StudentID = new SelectList(db.Students, "ID", "JMBAGAndFullName");
            return View();
        }

        // POST: Grades/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,StudentID,ClassID,GradeInt,DateOfGrade")] Grade grade)
        {
            if (ModelState.IsValid)
            {
                grade.DateOfGrade = DateTime.Now;
                db.Grades.Add(grade);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClassID = new SelectList(db.Classes, "ID", "MajorSemesterNameEcts", grade.ClassID);
            ViewBag.StudentID = new SelectList(db.Students, "ID", "JMBAGAndFullName", grade.StudentID);
            return View(grade);
        }

        // GET: Grades/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Grade grade = db.Grades.Find(id);
            if (grade == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClassID = new SelectList(db.Classes, "ID", "MajorSemesterNameEcts", grade.ClassID);
            ViewBag.StudentID = new SelectList(db.Students, "ID", "JMBAGAndFullName", grade.StudentID);
            return View(grade);
        }

        // POST: Grades/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,StudentID,ClassID,GradeInt,DateOfGrade")] Grade grade)
        {
            if (ModelState.IsValid)
            {
                grade.DateOfGrade = DateTime.Now;
                db.Entry(grade).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClassID = new SelectList(db.Classes, "ID", "MajorSemesterNameEcts", grade.ClassID);
            ViewBag.StudentID = new SelectList(db.Students, "ID", "JMBAGAndFullName", grade.StudentID);
            return View(grade);
        }

        // GET: Grades/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Grade grade = db.Grades.Find(id);
            if (grade == null)
            {
                return HttpNotFound();
            }
            return View(grade);
        }

        // POST: Grades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Grade grade = db.Grades.Find(id);
            db.Grades.Remove(grade);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
