using System;
using System.Linq;
using System.Web.Mvc;
using WebAppStudomat.Models;
using System.Security.Cryptography;
using System.Text;
using WebAppStudomat.Models.Users;

namespace WebAppStudomat.Controllers
{
    public class HomeController : Controller
    {
        public CollegeDbContext db = new CollegeDbContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                var check = db.Users
                        .FirstOrDefault(x => x.Email == user.Email);
                if (check == null)
                {
                    user.Password = GetMD5(user.Password);
                    db.Configuration.ValidateOnSaveEnabled = false;
                    user.UserRole = UserRoles.Teacher;
                    db.Users.Add(user);
                    db.SaveChanges();

                    return RedirectToAction("Login");
                }
                else
                {
                    ViewBag.error = "Email already exists";
                    return View();
                }
            }

            ViewBag.error = "Incorrect input";

            return View();
        }

        public static string GetMD5(string input)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] inputBytes = null;
            try
            {
                inputBytes = Encoding.UTF8.GetBytes(input);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            byte[] hash = null;
            try
            {
                hash = md5.ComputeHash(inputBytes);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            string byteToString = null;

            for (int i = 0; i < hash.Length; i++)
            {
                try
                {
                    byteToString += hash[i].ToString("x2");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }

            return byteToString;
        }

        public ActionResult Login()
        {
            ViewBag.Message = "Login page.";

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string email, string password)
        {
            if (ModelState.IsValid)
            {
                var encryptedPassword = GetMD5(password);
                var data = db.Users.Where(x => x.Email == email && x.Password.Equals(encryptedPassword)).ToList();
                if (data.Count() > 0)
                {
                    Session["IdUser"] = data.FirstOrDefault().IdUser;
                    Session["Email"] = data.FirstOrDefault().Email;
                    Session["FullName"] = data.FirstOrDefault().FullName;
                    Session["Username"] = data.FirstOrDefault().Username;

                    ViewBag.UserNow = Session["FullName"].ToString();

                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.error = "Login failed";
                    return RedirectToAction("Login");
                }
            }
            return View();

        }

        public ActionResult Logout()
        {
            try
            {
                Session.Clear();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return RedirectToAction("Login");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}