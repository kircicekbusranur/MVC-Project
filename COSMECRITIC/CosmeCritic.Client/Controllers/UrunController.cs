using CosmeCritic.Client.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CosmeCritic.Client.Controllers
{
    public class UrunController : Controller
    {

        public CosmeCriticDBEntities db = new CosmeCriticDBEntities();
        public ActionResult Index(int? id)
        {
            Session["AltKatUrun"] = db.Urunler.Where(x => x.AltKategoriId == id).ToList();
            return View();
        }
    }
}