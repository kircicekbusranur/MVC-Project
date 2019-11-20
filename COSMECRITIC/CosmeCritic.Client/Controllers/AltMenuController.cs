using CosmeCritic.Client.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CosmeCritic.Client.Controllers
{
    public class AltMenuController : Controller
    {
        CosmeCriticDBEntities db = new CosmeCriticDBEntities();
        public ActionResult AltKategori(int? id)
        {
            Session["AltKategori"] = db.AltKategoriler.Where(x => x.KategoriId == id).ToList();
            return View();

        }
    }
}