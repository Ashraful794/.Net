using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using RoleBased.Models;

namespace RoleBased.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register

        Ash_DBEntities db = new Ash_DBEntities();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignUp(tbl_user model)
        {
            db.tbl_user.Add(model);

            db.SaveChanges();

            return RedirectToAction("Login");
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(MemberShip model)
        {
            tbl_user user = (from st in db.tbl_user where st.Username == model.Username && st.Password == model.Password select st).FirstOrDefault();
            
            if(user!=null)
            {
                FormsAuthentication.SetAuthCookie(user.Username,false);
                return RedirectToAction("Index","tbl_Student");
            }

            ViewBag.Error = "InCorrect User Name or Password";
            return View();
        }
        public ActionResult Dashboard()
        {
            return View();
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}