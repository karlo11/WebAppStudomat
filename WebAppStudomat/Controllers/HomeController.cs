﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppStudomat.Models;
using System.Security.Cryptography;
using System.Text;

namespace WebAppStudomat.Controllers
{
    public class HomeController : Controller
    {
        public CollegeDbContext db = new CollegeDbContext();

        public ActionResult Index()
        {
            if (Session["IdUser"] != null)
            {
                ViewBag.UserNow = Session["FullName"].ToString();
                return View();
            }
            else
                return RedirectToAction("Login");
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
                    db.Users.Add(user);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.error = "Email already exists";
                    return View();
                }
            }
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
                var pass = GetMD5(password);
                var data = db.Users.Where(x => x.Email == email && x.Password.Equals(pass)).ToList();
                if (data.Count() > 0)
                {
                    Session["IdUser"] = data.FirstOrDefault().IdUser;
                    Session["Email"] = data.FirstOrDefault().Email;
                    Session["FullName"] = data.FirstOrDefault().FullName;
                    Session["Username"] = data.FirstOrDefault().Username;
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.error = "Login failed";
                    return RedirectToAction("Login");
                }
            }
            ViewBag.UserNow = "sss";
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