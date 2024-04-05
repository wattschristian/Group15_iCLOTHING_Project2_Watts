using Group15_iCLOTHINGApp.Models;
using System.Collections.Generic;
using System.Linq;
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

            foreach (Administrator admin in admins)
            {
                if (admin.adminName == a.adminName && admin.adminEncryptedPassword == a.adminEncryptedPassword)
                {
                    Session.Add("AdminID", a.adminName.ToUpper());
                    return RedirectToAction("Index", "Administrator");
                }
            }
            return RedirectToAction("AdminLogin", "AdminLogin");
        }
    }
}