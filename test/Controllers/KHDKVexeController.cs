using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using test.Models;

namespace test.Controllers
{
    public class KHDKVexeController : Controller
    {
        // GET: KHDKVexe
        public ActionResult Index()
        {
            tbl_Loaixe loaixe = new tbl_Loaixe();
            List<tbl_Loaixe> dsLoaixe = loaixe.GetLoaixeByPK(0);
            ViewBag.dsLoaixe = dsLoaixe;


            return View();
        }
        public bool DKVexe()
        {
            bool kq = false;

            return kq;
        }
    }
}