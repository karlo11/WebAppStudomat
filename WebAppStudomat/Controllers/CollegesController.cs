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
    public class CollegesController : Controller
    {
        private CollegeDbContext db = new CollegeDbContext();

        // GET: Colleges
        public ActionResult Index()
        {
            return View(db.Colleges.ToList());
        }

        // GET: Colleges/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            College college = db.Colleges.Find(id);
            if (college == null)
            {
                return HttpNotFound();
            }
            return View(college);
        }

        // GET: Colleges/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Colleges/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Address,FoundationYear,DeanFirstName,DeanLastName")] College college)
        {
            if (ModelState.IsValid)
            {
                db.Colleges.Add(college);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(college);
        }

        // GET: Colleges/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            College college = db.Colleges.Find(id);
            if (college == null)
            {
                return HttpNotFound();
            }
            return View(college);
        }

        // POST: Colleges/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Address,FoundationYear,DeanFirstName,DeanLastName")] College college)
        {
            if (ModelState.IsValid)
            {
                db.Entry(college).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(college);
        }

        // GET: Colleges/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            College college = db.Colleges.Find(id);
            if (college == null)
            {
                return HttpNotFound();
            }
            return View(college);
        }

        // POST: Colleges/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            College college = db.Colleges.Find(id);
            db.Colleges.Remove(college);
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
