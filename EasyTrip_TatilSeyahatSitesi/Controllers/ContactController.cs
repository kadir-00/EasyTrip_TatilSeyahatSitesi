using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using EasyTrip_TatilSeyahatSitesi.Models.Siniflar;

namespace EasyTrip_TatilSeyahatSitesi.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        Context c = new Context();
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Gonder(Iletisim p)
        {
            c.Iletisims.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
