
using MVC_RW_Demo.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_RW_Demo.Controllers
{
    public class EmployeesController : Controller
    {
        // GET: Employees
        public ActionResult Index()
        {

            if (Session["SSID"] == null)
            {
                return RedirectToAction("Login","Home");
            }
            List<Employee> lstEmp = new List<Employee>();
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = @"Data Source=(localdb)\mssqllocaldb;Initial Catalog=Akshay;Integrated Security=True;Pooling=False";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                con.Open();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "select * from Employees";
                SqlDataReader dr = cmd.ExecuteReader();
                while(dr.Read())
                {
                    Employee e = new Employee();
                    e.EmpID = (int)dr["EmpID"];
                    e.Name = "" + dr["Name"];
                    e.Basic = (Decimal)dr["Basic"];
                    e.DeptNo = (int)dr["DeptNo"];
                    lstEmp.Add(e);
                }
            }
            catch
            {
                //return View();
            }
            return View(lstEmp);
        }

        // GET: Employees/Details/5
        public ActionResult Details(int id=0)
        {
            Employee e = FetchRecord(id);
            return View(e);
            //return View();
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index","Home");
        }

        // POST: Employees/Create
        [HttpPost]
        public ActionResult Create(Employee emp)
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
                cmd.CommandText = "select MAX(EmpID) from Employees";
                int ID=(int)cmd.ExecuteScalar();
                ID++;
                cmd.CommandText = "insert into Employees values(@EmpID,@NAME,@DEPTNO,@BASIC)";
                cmd.Parameters.AddWithValue("@EmpID", ID);
                cmd.Parameters.AddWithValue("@NAME", emp.Name);
                cmd.Parameters.AddWithValue("@DEPTNO", emp.DeptNo);
                cmd.Parameters.AddWithValue("@BASIC", emp.Basic);

                int result =cmd.ExecuteNonQuery();
                if (result > 0)
                    ViewData["msg"] = "Record Inserted";
                else
                    ViewData["msg"] = "Record Not Inserted";
                return RedirectToAction("Index");
                //con.Close();
            }
            catch(Exception ee)
            {
                ViewData["msg"] = ee.Message;
                return View();
            }
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int id)
        {
            Employee e =FetchRecord(id);
            return View(e);
        }

        Employee FetchRecord(int id)
        {
            Employee e = new Employee();
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = @"Data Source=(localdb)\mssqllocaldb;Initial Catalog=Akshay;Integrated Security=True;Pooling=False";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                con.Open();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "select * from Employees where EmpID=@EmpID";
                cmd.Parameters.AddWithValue("@EmpID", id);

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    e.EmpID = (int)dr["EmpID"];
                    e.Name = "" + dr["Name"];
                    e.Basic = (Decimal)dr["Basic"];
                    e.DeptNo = (int)dr["DeptNo"];
                }
            }
            catch
            {
                //return View();
            }
            return e;
        }

        // POST: Employees/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Employee emp)
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = @"Data Source=(localdb)\mssqllocaldb;Initial Catalog=Akshay;Integrated Security=True;Pooling=False";
                SqlCommand cmd = new SqlCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "update Employees set Name=@NAME, DeptNo=@DEPTNO, Basic=@BASIC where empID=@EMPID";
                cmd.Parameters.AddWithValue("@EmpID", id);
                cmd.Parameters.AddWithValue("@NAME", emp.Name);
                cmd.Parameters.AddWithValue("@DEPTNO", emp.DeptNo);
                cmd.Parameters.AddWithValue("@BASIC", emp.Basic);

                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                    ViewBag.Msg = "Record Updated";
                else
                    ViewBag.Msg = "Record Not Updated";
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int id)
        {
            Employee e = FetchRecord(id);
            return View(e);
        }

        // POST: Employees/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Employee emp)
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = @"Data Source=(localdb)\mssqllocaldb;Initial Catalog=Akshay;Integrated Security=True;Pooling=False";
                SqlCommand cmd = new SqlCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "delete from Employees where EmpID=@EmpID";
                cmd.Parameters.AddWithValue("@EmpID", id);

                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                    ViewBag.Msg = "Record Deleted";
                else
                    ViewBag.Msg = "Record Not Deleted";
                //return View("Index");

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
