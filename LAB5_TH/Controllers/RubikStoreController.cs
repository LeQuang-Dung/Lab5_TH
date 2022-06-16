using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LAB5_TH.Models;

namespace LAB5_TH.Controllers
{
    public class RubikStoreController : Controller
    {
        // GET: RubikStore
        dbRubikStoreDataContext data = new dbRubikStoreDataContext();
        public ActionResult Index()
        {
            var all_rubik = from s in data.Rubiks select s;
            return View(all_rubik);
        }
        public ActionResult Detail(int id)
        {
            var D_sach = data.Rubiks.Where(m => m.id == id).First();
            return View(D_sach);
        }
    }
}