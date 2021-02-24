
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using test.Models;

namespace test.Controllers
{
    public class XeravaoController : Controller
    {
        // GET: Xeravao
        public ActionResult Index()
        {
            if (Session["IsLogin"].Equals(true))
            {
                tbl_Xeravao xeravao = new tbl_Xeravao();
                Database db = new Database();
                List<tbl_Xeravao> dsxeravao = db.tbl_Xeravao.ToList();
                List<tbl_Xe> dsXe = db.tbl_Xe.ToList();
                List<tbl_Ve> dsVe = db.tbl_Ve.ToList();
                ViewBag.danhsachXe = dsXe;
                ViewBag.danhsachVe = dsVe;
                ViewBag.danhsachxeravao = dsxeravao;

                return View();
            }
            else
                return RedirectToAction("Index", "Login");
        }

        public JsonResult NhandienBsx()
        {
            return Json(true);

        }
    }
}