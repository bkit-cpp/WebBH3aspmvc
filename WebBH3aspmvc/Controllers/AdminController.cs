using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace WebBH3aspmvc.Controllers
{
    public class AdminController : Controller
    {
        ShopBanHangEntities2 db = new ShopBanHangEntities2();
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
       
        public ActionResult Register(User us)
        {
            if (ModelState.IsValid) //Check user have submin yet?
            {
                var check = db.Users.FirstOrDefault(x => x.uname == us.uname);
               
                if (check == null)
                {
                    db.Configuration.ValidateOnSaveEnabled = false;//Tắt tính năng xác thực auto của validation
                    db.Users.Add(us);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.error = "Username đã tồn tại";
                    return View();
                }
            }
            return View();
        }
        
        [HttpGet]
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(User user)
        {
           
            var a = db.Users.Where(x => x.uname.Equals(user.uname) && x.upass.Equals(user.upass)).ToList();
            if (a.Count> 0)
            {
                Session["uname"] = user.uname.ToString();
                Session["upass"] = user.upass.ToString();
                return RedirectToAction("DashBoard");
            }
            else
            {
                ViewBag.msg = "Invalid name or password";
            }
            return View();
        }
        public ActionResult DashBoard()
        {
            if (Session["uname"] == null ||Session["upass"]==null)
            {
                ViewBag.msg = "Login is Invalid";
                return RedirectToAction("Index");
            }
            return View();

        }
    }
}