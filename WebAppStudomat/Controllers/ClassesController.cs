using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebAppStudomat.Models;

namespace WebAppStudomat.Controllers
{
    public class ClassesController : Controller
    {
        private CollegeDbContext db = new CollegeDbContext();

        // GET: Classes
        public ActionResult Index()
        {
            if (Session["IdUser"] != null)
            {
                ViewBag.UserNow = Session["FullName"].ToString();
                var classes = db.Classes.Include(m => m.Major).Include(t => t.Teacher);

                return View(classes.ToList()
                    .OrderBy(t => t.Major.ID)
                    .ThenBy(x => x.Semester)
                    .ThenByDescending(y => y.NumberOfECTS)
                    .ThenBy(z => z.Name));
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
        }

        // GET: Classes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Class @class = db.Classes.Find(id);
            if (@class == null)
            {
                return HttpNotFound();
            }
            return View(@class);
        }

        // GET: Classes/Create
        public ActionResult Create()
        {
            ViewBag.MajorID = new SelectList(db.Majors, "ID", "Name");
            ViewBag.TeacherID = new SelectList(db.Teachers, "ID", "FullNameWithTitle");
            return View();
        }

        // POST: Classes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Details,ISVUNumber,HoursOfLectures,HoursOfAudit,HoursOfLab,HoursOfSeminar,HoursOfConstr,HoursOfHomework,Name,NumberOfECTS,Semester,TeacherID,MajorID")] Class @class)
        {
            if (ModelState.IsValid)
            {
                db.Classes.Add(@class);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MajorID = new SelectList(db.Majors, "ID", "Name", @class.MajorID);
            ViewBag.TeacherID = new SelectList(db.Teachers, "ID", "FullNameWithTitle", @class.TeacherID);
            return View(@class);
        }

        // GET: Classes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Class @class = db.Classes.Find(id);
            if (@class == null)
            {
                return HttpNotFound();
            }
            ViewBag.MajorID = new SelectList(db.Majors, "ID", "Name", @class.MajorID);
            ViewBag.TeacherID = new SelectList(db.Teachers, "ID", "FullNameWithTitle", @class.TeacherID);
            return View(@class);
        }

        // POST: Classes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Details,ISVUNumber,HoursOfLectures,HoursOfAudit,HoursOfLab,HoursOfSeminar,HoursOfConstr,HoursOfHomework,Name,NumberOfECTS,Semester,TeacherID,MajorID")] Class @class)
        {
            if (ModelState.IsValid)
            {
                db.Entry(@class).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MajorID = new SelectList(db.Majors, "ID", "Name", @class.MajorID);
            ViewBag.TeacherID = new SelectList(db.Teachers, "ID", "FullNameWithTitle", @class.TeacherID);
            return View(@class);
        }

        // GET: Classes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Class @class = db.Classes.Find(id);
            if (@class == null)
            {
                return HttpNotFound();
            }
            return View(@class);
        }

        // POST: Classes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Class @class = db.Classes.Find(id);
            db.Classes.Remove(@class);
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
