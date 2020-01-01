using MVC_RW_Demo.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_RW_Demo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(DbUser user)
        {
            try
            {
                // TODO: Add insert logic here
                SqlConnection con = new SqlConnection();
                con.ConnectionString = @"Data Source=(localdb)\mssqllocaldb;Initial Catalog=Akshay;Integrated Security=True;Pooling=False";
                SqlCommand cmd = new SqlCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "insert into DbUser values(@UID,@PWD)";
                cmd.Parameters.AddWithValue("@UID", user.Uid);
                cmd.Parameters.AddWithValue("@PWD", user.Pass);

                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                    return View("Login");
                else
                {
                    ViewData["msg"] = "Registration Failed";
                    return RedirectToAction("Register");
                }
                //con.Close();
            }
            catch (Exception ee)
            {
                ViewData["msg"] = ee.Message;
                return View();
            }
            return View();
        }
        public ActionResult Login()
        {

            ViewBag.Title = "Login";
            HttpCookie cookie = Request.Cookies["USERID"];
            cookie.Expires = DateTime.Now.AddDays(-80);
            if (cookie["USERID"] != null)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpPost]
        public ActionResult Login(DbUser user)
        {
            try
            {
                // TODO: Add insert logic here
                SqlConnection con = new SqlConnection();
                con.ConnectionString = @"Data Source=(localdb)\mssqllocaldb;Initial Catalog=Akshay;Integrated Security=True;Pooling=False";
                SqlCommand cmd = new SqlCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "select count(Uid) from DbUser where Uid=@UID and Pwd=@PWD";
                cmd.Parameters.AddWithValue("@UID", user.Uid);
                cmd.Parameters.AddWithValue("@PWD", user.Pass);

                int result = (int)cmd.ExecuteScalar();
                if (result == 1)
                {
                    Session["SSID"] = "__NEWSESSION";
                    Session["user"] = user.Uid;
                }
                else
                {
                    ViewData["msg"] = "Login Failed..!";
                    return View();
                }
                //con.Close();
            }
            catch (Exception ee)
            {
                ViewData["msg"] = ee.Message;
                return View();
            }
            return View();
        }
        public ActionResult Index()
        {

            if (Session["SSID"] == null)
            {
                return RedirectToAction("Login");
            }
            return View();
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