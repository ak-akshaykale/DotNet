using LoginEmployeeManagement.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LoginEmployeeManagement.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Clearc()
        {
            HttpCookie cookie = Request.Cookies["UID"];
            if (cookie != null)
            {
                cookie.Expires = DateTime.Now.AddDays(-30);
                Session.Abandon();
                Response.Cookies.Add(cookie);
            }
            return RedirectToAction("Login");
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
            if (Session["SSID"] == null)
            {
                return RedirectToAction("Login");
            }
            return View();
        }

        public ActionResult Contact()
        {
            if (Session["SSID"] == null)
            {
                return RedirectToAction("Login");
            }
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(DbUser user)
        {
            if (user.Mobileno == 0)
            {
                return View();
            }
            else
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
                    cmd.CommandText = "insert into DbUser values(@UID,@PWD,@FULL,@EMAIL,@MOBILE)";
                    cmd.Parameters.AddWithValue("@UID", user.Uid);
                    cmd.Parameters.AddWithValue("@PWD", user.Pass);
                    cmd.Parameters.AddWithValue("@FULL", user.FullName);
                    cmd.Parameters.AddWithValue("@EMAIL", user.EmailID);
                    cmd.Parameters.AddWithValue("@MOBILE", user.Mobileno);

                    int result = cmd.ExecuteNonQuery();
                    if (result > 0)
                    {
                        ViewData["msg"] = "Register Successfull..!";
                        return RedirectToAction("Login");
                    }
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
            }
            return View();
        }
        public ActionResult Login()
        {
            if (Request.Cookies["UID"]!=null)
            {
                HttpCookie cookie = Request.Cookies["UID"];
                if (cookie != null)
                {
                    Session["SSID"] = "__NEWSESSION";
                    Session["user"] = cookie.Value;
                    return RedirectToAction("Index");
                }
                if (cookie["USERID"] != null)
                {
                    return RedirectToAction("Index");
                }
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
                    if (user.Remember)
                    {
                        HttpCookie cookie = new HttpCookie("UID", user.Uid);
                        cookie.Expires = DateTime.Now.AddMinutes(1);
                        Response.Cookies.Add(cookie);
                    }
                }
                else
                {
                    ViewData["msg"] = "Login Failed..!";
                    return View("Index");
                }
                //con.Close();
            }
            catch (Exception ee)
            {
                ViewData["msg"] = ee.Message;
                return View();
            }
            return View("Index");
        }

        public ActionResult Edit()
        {
            if (Session["SSID"] != null)
            {
                if (Session["user"] != null)
                {
                    string id = (string)Session["user"];
                    DbUser db = FetchRecord(id);
                    return View(db);
                }
            }
            else
            {
                return RedirectToAction("Login");
            }
            return View();
        }
        [HttpPost]
        public ActionResult Edit(DbUser u)
        {
            if (Session["SSID"] != null)
            {
                if (Session["user"] != null)
                {
                    try
                    {
                        SqlConnection con = new SqlConnection();
                        con.ConnectionString = @"Data Source=(localdb)\mssqllocaldb;Initial Catalog=Akshay;Integrated Security=True;Pooling=False";
                        SqlCommand cmd = new SqlCommand();
                        con.Open();
                        cmd.Connection = con;
                        cmd.CommandType = System.Data.CommandType.Text;
                        cmd.CommandText = "update DbUser set FullName=@FULL, Pwd=@PWD,EmailID=@EMAIL,Mobileno=@MOBILE where Uid=@Uid";
                        cmd.Parameters.AddWithValue("@UID", u.Uid);
                        cmd.Parameters.AddWithValue("@FULL", u.FullName);
                        cmd.Parameters.AddWithValue("@MOBILE",u.Mobileno);
                        cmd.Parameters.AddWithValue("@EMAIL",u.EmailID);
                        cmd.Parameters.AddWithValue("@PWD",u.Pass);

                        int result = cmd.ExecuteNonQuery();
                        if (result > 0)
                            ViewBag.Msg = "Profile Updated";
                        else
                            ViewBag.Msg = "Profile Not Updated";
                        return RedirectToAction("Index");
                    }
                    catch(Exception e)
                    {

                        return View(e.Message);
                    }
                }
                return RedirectToAction("Login");
            }
            else
            {
                return RedirectToAction("Login");
            }
            return View();
        }
        public ActionResult Logout()
        {
            Session.Abandon();
            HttpCookie cookie = Request.Cookies["UID"];
            if (cookie != null)
            {
                cookie.Expires = DateTime.Now.AddDays(-30);
                Response.Cookies.Add(cookie);
            }
            return RedirectToAction("Index", "Home");
        }
        DbUser FetchRecord(string id)
        {
            DbUser e = new DbUser();
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = @"Data Source=(localdb)\mssqllocaldb;Initial Catalog=Akshay;Integrated Security=True;Pooling=False";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                con.Open();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "select * from DbUser where Uid=@UID";
                cmd.Parameters.AddWithValue("@UID", id);

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    e.Uid =""+ dr["Uid"];
                    e.FullName = "" + dr["FullName"];
                    e.Pass = ""+dr["Pwd"];
                    e.EmailID = ""+dr["EmailID"];
                    e.Mobileno = Convert.ToInt64(dr["Mobileno"]);
                }
            }
            catch(Exception ee)
            {
                 Console.Write( ee.Message);
                //return View();
            }
            return e;
        }
    }
}