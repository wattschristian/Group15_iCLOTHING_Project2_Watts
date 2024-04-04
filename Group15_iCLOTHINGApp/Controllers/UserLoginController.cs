using System.Configuration;
using System.Data.SqlClient;
using System.Web.Mvc;
using System;
using Group15_iCLOTHINGApp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Drawing.Printing;

public class UserLoginController : Controller
{
    private Group15_iCLOTHINGDBEntities db = new Group15_iCLOTHINGDBEntities();

    [AllowAnonymous]
    [HttpGet]
    public ActionResult UserLogin()
    {
        return View();
    }

    [HttpPost]
    public ActionResult Validate(UserPassword up)
    {
        List<UserPassword> users = db.UserPassword.ToList();
        foreach(UserPassword user in users)
        {
            if(user.userAccountName == up.userAccountName && user.userEncryptedPassword == up.userEncryptedPassword)
            {
                return RedirectToAction("UserIndex", "Home");
            }
        }
        return RedirectToAction("Create", "UserPassword");
    }
}