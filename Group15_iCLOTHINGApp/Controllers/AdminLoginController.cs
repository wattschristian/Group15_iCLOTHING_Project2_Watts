using Group15_iCLOTHINGApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Group15_iCLOTHINGApp.Controllers
{
    public class AdminLoginController : Controller
    {
        private Group15_iCLOTHINGDBEntities db = new Group15_iCLOTHINGDBEntities();

        [AllowAnonymous]
        [HttpGet]
        public ActionResult AdminLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Validate(Administrator a)
        {
            List<Administrator> admins = db.Administrator.ToList();
         
            //foreach (Administrator admin in admins)
            //{
            //    if (admin.adminEmail == a.adminEmail && admin.adminPassword == a.adminPassword)
            //    {
            //        return RedirectToAction("User", "Home");
            //    }
            //}
            return RedirectToAction("AdminLogin", "AdminLogin");
        }
    }
}