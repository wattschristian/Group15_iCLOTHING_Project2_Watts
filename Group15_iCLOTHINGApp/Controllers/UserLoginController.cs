using Group15_iCLOTHINGApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Hosting;
using System.Web.Mvc;

public class UserLoginController : Controller
{
    private Group15_iCLOTHINGDBEntities db = new Group15_iCLOTHINGDBEntities();

    [AllowAnonymous]
    [HttpGet]
    // Shows error message right when page loads 
    public ActionResult UserLogin(UserPassword up, string eMessage="")
    {
        ViewBag.ErrorMessage = eMessage;
        return View();
    }

    public ActionResult Validate(UserPassword up)
    {
        List<UserPassword> users = db.UserPassword.ToList();
        string eMessage;
        if (up.userAccountName == null && up.userEncryptedPassword == null)
        {
            eMessage = "Input fields required";
            return RedirectToAction("UserLogin", "UserLogin", new { eMessage = eMessage });
        }
        else if (up.userAccountName == null)
        {
            eMessage = "Username required";
            return RedirectToAction("UserLogin", "UserLogin", new { eMessage = eMessage });
        }
        else if (up.userEncryptedPassword == null)
        {
            eMessage = "Password required";
            return RedirectToAction("UserLogin", "UserLogin", new { eMessage = eMessage });
        }
        foreach (UserPassword user in users)
        {
            if (user.userAccountName == up.userAccountName && user.userEncryptedPassword == up.userEncryptedPassword)
            {
                Session.Add("UserID", user.userID);
                Session.Add("UserName", user.userAccountName);
                eMessage = "";
                return RedirectToAction("Index", "Home", new { eMessage = eMessage });
            }
        }
        eMessage = "User not found, please register account";
        return RedirectToAction("UserLogin", "UserLogin", new { eMessage = eMessage });
    }
}