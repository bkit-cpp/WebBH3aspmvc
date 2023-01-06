using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBH3aspmvc;
using WebBH3aspmvc.Models;
namespace WebBH3aspmvc.Controllers
{
    public class HomeController : Controller
    {
        ShopBanHangEntities2 db = new ShopBanHangEntities2();
        // GET: Home
        public ActionResult Index()
        {
            
            var p = db.Prices.ToList();
            ViewBag.p = p;
            var imgs = db.Images.ToList();
            ViewBag.imgs = imgs;
            return View();
        }
        public ActionResult cat(int ?id)
        {
            var p = db.Prices.Where(l => l.cid == id).ToList();
            ViewBag.p = p;
            var imgs = db.Images.ToList();
            ViewBag.imgs = imgs;
            return View();
        }
        public ActionResult pro(int ?id)
        {
            var p = db.Prices.Where(l => l.pid == id).ToList();
            ViewBag.p = p;
            var imgs = db.Images.Where(l=>l.pid==id).ToList();
            ViewBag.imgs = imgs;
            return View();
        }
        public ActionResult cart()
        {
            ViewBag.c = ListCart.c;
            return View();
        }
        [HttpPost]
        public ActionResult cart(string pid,string pqty)
        {
            foreach(var item in ListCart.c)
            {
                if (item.iid == int.Parse(pid))
                {
                    item.iqty += int.Parse(pqty);
                }
                ViewBag.c = ListCart.c;
                return View();
            }
            cartItem cI = new cartItem() { iid = int.Parse(pid), iqty =int.Parse( pqty) };
            ListCart.c.Add(cI);
            ViewBag.c = ListCart.c;
            return View();
        }
    }
}