using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebBH3aspmvc;

namespace WebBH3aspmvc.Controllers
{
    public class PricesController : Controller
    {
        private ShopBanHangEntities2 db = new ShopBanHangEntities2();

        // GET: Prices
        public ActionResult Index()
        {
            var prices = db.Prices.Include(p => p.Category);
            return View(prices.ToList());
        }

        // GET: Prices/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Price price = db.Prices.Find(id);
            if (price == null)
            {
                return HttpNotFound();
            }
            return View(price);
        }

        // GET: Prices/Create
        public ActionResult Create()
        {
            ViewBag.cid = new SelectList(db.Categories, "cid", "cnam");
            return View();
        }

        // POST: Prices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "pid,pname,pprice,pdetails,cid")] Price price)
        {
            if (ModelState.IsValid)
            {
                db.Prices.Add(price);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.cid = new SelectList(db.Categories, "cid", "cnam", price.cid);
            return View(price);
        }

        // GET: Prices/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Price price = db.Prices.Find(id);
            if (price == null)
            {
                return HttpNotFound();
            }
            ViewBag.cid = new SelectList(db.Categories, "cid", "cnam", price.cid);
            return View(price);
        }

        // POST: Prices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "pid,pname,pprice,pdetails,cid")] Price price)
        {
            if (ModelState.IsValid)
            {
                db.Entry(price).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.cid = new SelectList(db.Categories, "cid", "cnam", price.cid);
            return View(price);
        }

        // GET: Prices/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Price price = db.Prices.Find(id);
            if (price == null)
            {
                return HttpNotFound();
            }
            return View(price);
        }

        // POST: Prices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Price price = db.Prices.Find(id);
            db.Prices.Remove(price);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Images(int ?id)
        {
            if(id==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadGateway);
            }
            var pro = db.Prices.Where(l => l.pid == id).ToList();
            if(pro==null)
            {
                return HttpNotFound();
            }
     
            var imgs = db.Images.Where(l => l.pid == id).ToList();
            ViewBag.imgs = imgs;
            ViewBag.pro = pro;
            return View();
        }
        [HttpPost]
        public ActionResult Images(int id, HttpPostedFileBase file)
        {
            string path = System.IO.Path.Combine("~/Content/FE/img/" + file.FileName);
            file.SaveAs(Server.MapPath(path));//Upload hinh anh vao folder
            Image obj = new Image();
            obj.iname = file.FileName.ToString();
            obj.pid = id;
            db.Images.Add(obj);
            db.SaveChanges();
          
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
