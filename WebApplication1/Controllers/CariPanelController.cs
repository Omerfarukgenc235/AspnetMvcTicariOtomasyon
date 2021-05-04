using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models.Siniflar;

namespace WebApplication1.Controllers
{
    public class CariPanelController : Controller
    {
        // GET: CariPanel
        Context c = new Context();
        [Authorize]     
        public ActionResult Index()
        {
            var mail = (string)Session["CariMail"];
            var pnl = c.Carilers.FirstOrDefault(x => x.CariMail == mail);
            ViewBag.neden = mail;
            return View(pnl);
        }
        public ActionResult Siparislerim()
        {
            var mail = (string)Session["CariMail"];
            var id = c.Carilers.Where(x => x.CariMail == mail.ToString()).Select(y => y.Cariid).FirstOrDefault();
            var dgr = c.SatisHarekets.Where(x => x.Cariid == id).ToList();
            return View(dgr);
        }
    }
}