using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAspClientAsync.Controllers
{
    public class HomeController : AsyncController
    {
        public void IndexAsync()
        {
            ServiceReference1.Service1Client service = new ServiceReference1.Service1Client();
            service.GetDataCompleted += Service_GetDataCompleted;
            service.GetDataAsync(100);
            AsyncManager.OutstandingOperations.Increment();
        }
        public ActionResult IndexCompleted()
        {
            return View();
        }
        private void Service_GetDataCompleted(object sender, ServiceReference1.GetDataCompletedEventArgs e)
        {
            AsyncManager.OutstandingOperations.Decrement();
            ViewBag.Result=e.Result;
        }

        public void AboutAsync()
        {
            ServiceReference1.Service1Client service = new ServiceReference1.Service1Client();
            service.HelloWelcomeCompleted += Service_HelloWelcomeCompleted;
            service.HelloWelcomeAsync("Akshay");
            AsyncManager.OutstandingOperations.Increment();
            //return View();
        }

        private void Service_HelloWelcomeCompleted(object sender, ServiceReference1.HelloWelcomeCompletedEventArgs e)
        {
            AsyncManager.OutstandingOperations.Decrement();
            ViewBag.Result = e.Result;

        }

        public ActionResult AboutCompleted()
        {
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}