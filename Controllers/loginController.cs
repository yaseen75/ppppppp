using SchoolSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolSystem.Controllers
{

    public class loginController : Controller
    {
        uniEntities db = new uniEntities();
        // GET: login
        public ActionResult Index()
        {
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(User UserobjChck)
        {
            if (ModelState.IsValid)
            {
                using (uniEntities db=new uniEntities())
                {
                    var obj = db.Users.Where(a => a.UserName.Equals(UserobjChck.UserName) && a.Password.Equals(UserobjChck.Password)).FirstOrDefault()
;
                if(obj != null)
                    {
                        Session["UserId"] = obj.UserId.ToString();
                        Session["UserName"] = obj.UserName.ToString();
                        return RedirectToAction("About","Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", "UserName or Password Is Incorrect");
                    }
                }
               
            }


            return View(UserobjChck);
        }
    }
}