using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EasyTrip_TatilSeyahatSitesi.Models.Siniflar;

namespace EasyTrip_TatilSeyahatSitesi.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        Context c = new Context();
        [Authorize]
        public ActionResult Index()
        {
            var degerler = c.Blogs.ToList();
            return View(degerler);
        }

        [HttpGet]
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

        public ActionResult BlogSil(int id)
        {
            var b = c.Blogs.Find(id);
            c.Blogs.Remove(b);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult BlogGetir(int id)
        {
            var bl = c.Blogs.Find(id);
            return View("BlogGetir", bl);
        }

        public ActionResult BlogGuncelle(Blog b)
        {
            var blg = c.Blogs.Find(b.ID);
            blg.Aciklama = b.Aciklama;
            blg.Baslik = b.Baslik;
            blg.BlogImage = b.BlogImage;
            blg.Tarih = b.Tarih;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult YorumListesi()
        {
            var yorumlar = c.Yorumlars.ToList();
            return View(yorumlar);
        }

        public ActionResult YorumSil(int id)
        {
            var b = c.Yorumlars.Find(id);
            c.Yorumlars.Remove(b);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult YorumGetir(int id)
        {
            var yr = c.Yorumlars.Find(id);
            return View("YorumGetir", yr);
        }

        public ActionResult YorumGuncelle(Yorumlar y)
        {
            var yrm = c.Yorumlars.Find(y.ID);
            yrm.KullaniciAdi = y.KullaniciAdi;
            yrm.Mail = y.Mail;
            yrm.Yorum = y.Yorum;
            c.SaveChanges();
            return RedirectToAction("YorumListesi");
        }


        public ActionResult Hakkimizda()
        {
            var values = c.Hakkimizdas.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult YeniHakkimizda()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniHakkimizda(Hakkimizda h)
        {
            c.Hakkimizdas.Add(h);
            c.SaveChanges();
            return RedirectToAction("Hakkimizda");
        }

        public ActionResult HakkimizdaSil(int id)
        {
            var h = c.Hakkimizdas.Find(id);
            c.Hakkimizdas.Remove(h);
            c.SaveChanges();
            return RedirectToAction("Hakkimizda");
        }

        public ActionResult HakkimizdaGetir(int id)
        {
            var h = c.Hakkimizdas.Find(id);
            return View("HakkimizdaGetir", h);
        }

        public ActionResult HakkimizdaGuncelle(Hakkimizda h)
        {
            var hk = c.Hakkimizdas.Find(h.ID);
            hk.Aciklama = h.Aciklama;
            hk.FotoUrl = h.FotoUrl;
            c.SaveChanges();
            return RedirectToAction("Hakkimizda");
        }

        public ActionResult Iletisim()
        {
            var iletisim = c.Iletisims.ToList();
            return View(iletisim);
        }
    }
}