using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTripProject.Models.Siniflar;

namespace TravelTripProject.Controllers
{
    public class AdminController : Controller
    {
        Context c = new Context();
        // GET: Admin
        [Authorize]
        public ActionResult Index()
        {
            var deger = c.Blogs.ToList();
            return View(deger);
        }
        [HttpGet,Authorize]
        public ActionResult YeniBlog()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniBlog(Blog p)
        {
            c.Blogs.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult BlogSil(Blog p)
        {
            c.Entry(p).State = System.Data.Entity.EntityState.Deleted;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        //public ActionResult BlogSil(int id)
        //{
        //    var b = c.Blogs.Find(id);       2.silme Alternatifi
        //    c.Blogs.Remove(b);
        //    c.SaveChanges();
        //    return RedirectToAction("Index");

        //}
        [Authorize]
        public ActionResult BlogGetir(int id)
        {
            var b = c.Blogs.Find(id);
            return View("BlogGetir", b);
        }
        public ActionResult BlogGuncelle(Blog p)
        {
            c.Entry(p).State = System.Data.Entity.EntityState.Modified;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        [Authorize]
        public ActionResult YorumListesi()
        {
            var yorumlar = c.Yorumlars.ToList();
            return View(yorumlar);
        }
        public ActionResult YorumSil(Yorumlar p)
        {
            c.Entry(p).State = System.Data.Entity.EntityState.Deleted;
            c.SaveChanges();
            return RedirectToAction("YorumListesi");
        }
        [Authorize]
        public ActionResult YorumGetir(int id)
        {
            var yrm = c.Yorumlars.Find(id);
            return View("YorumGetir", yrm);
        }
        //public ActionResult YorumGuncelle(Yorumlar y)
        //{
        //    c.Entry(y).State = System.Data.Entity.EntityState.Modified;
        //    c.SaveChanges();
        //    return RedirectToAction("Index");
        //}
        public ActionResult YorumGuncelle(Yorumlar y)
        {
            var yrm = c.Yorumlars.Find(y.ID);
            yrm.KullaniciAdi = y.KullaniciAdi;
            yrm.Mail = y.Mail;
            yrm.Yorum = y.Yorum;
            c.SaveChanges();
            return RedirectToAction("YorumListesi");
        }
    }
}