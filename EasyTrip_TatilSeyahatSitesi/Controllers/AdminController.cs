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
            if (b == null) return HttpNotFound();
            c.Blogs.Remove(b);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult BlogGetir(int id)
        {
            var bl = c.Blogs.Find(id);
            if (bl == null) return HttpNotFound();
            return View("BlogGetir", bl);
        }

        public ActionResult BlogGuncelle(Blog b)
        {
            var blg = c.Blogs.Find(b.ID);
            if (blg == null) return HttpNotFound();
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
            if (b == null) return HttpNotFound();
            c.Yorumlars.Remove(b);
            c.SaveChanges();
            return RedirectToAction("YorumListesi");
        }

        public ActionResult YorumGetir(int id)
        {
            var yr = c.Yorumlars.Find(id);
            if (yr == null) return HttpNotFound();
            return View("YorumGetir", yr);
        }

        public ActionResult YorumGuncelle(Yorumlar y)
        {
            var yrm = c.Yorumlars.Find(y.ID);
            if (yrm == null) return HttpNotFound();
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
            if (h == null) return HttpNotFound();
            c.Hakkimizdas.Remove(h);
            c.SaveChanges();
            return RedirectToAction("Hakkimizda");
        }

        public ActionResult HakkimizdaGetir(int id)
        {
            var h = c.Hakkimizdas.Find(id);
            if (h == null) return HttpNotFound();
            return View("HakkimizdaGetir", h);
        }

        public ActionResult HakkimizdaGuncelle(Hakkimizda h)
        {
            var hk = c.Hakkimizdas.Find(h.ID);
            if (hk == null) return HttpNotFound();
            hk.Aciklama = h.Aciklama;
            hk.FotoUrl = h.FotoUrl;
            c.SaveChanges();
            return RedirectToAction("Hakkimizda");
        }

        public ActionResult IletisimSil(int id)
        {
            var i = c.Iletisims.Find(id);
            if (i == null) return HttpNotFound();
            c.Iletisims.Remove(i);
            c.SaveChanges();
            return RedirectToAction("Iletisim");
        }

        public ActionResult Iletisim()
        {
            var iletisim = c.Iletisims.ToList();
            return View(iletisim);
        }
    }
}