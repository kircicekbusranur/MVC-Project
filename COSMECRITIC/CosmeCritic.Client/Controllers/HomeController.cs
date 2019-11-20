using CosmeCritic.Client.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CosmeCritic.Client.Controllers
{
    public class HomeController : Controller
    {
        public CosmeCriticDBEntities db = new CosmeCriticDBEntities();

        public ActionResult Index()
        {
            Session["YuksekPuanliUrunler"] = db.Urunler.ToList();
            Session["Kategoriler"] = db.Kategoriler.ToList();
            return View();
        }

    }
}