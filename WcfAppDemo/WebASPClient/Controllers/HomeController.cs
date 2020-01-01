using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebASPClient.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ServiceReference1.Service1Client service = new ServiceReference1.Service1Client();
            /*string Result=service.GetData(5000);
            ViewBag.Result=Result;*/
            return View();
        }

        public ActionResult About()
        {
            // ViewBag.Message = "Your application description page.";
            localhost.WebService1 service1 = new localhost.WebService1();
            string time=service1.CurrentTime();
            ViewBag.Time = time;
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}