using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SearchCustomer.Controllers
{
    public class ApplicationController : Controller
    {
        public ActionResult Application() 
        {
            return View();
        }

        // GET: Application
        public ActionResult Index()
        {
            return View();
        }
    }
}