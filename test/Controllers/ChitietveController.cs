using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using test.Models;
using test.Models.obj;
using System.Web.Script.Serialization;

namespace test.Controllers
{
    public class ChitietveController : Controller
    {
        // GET: Chitietve
        public ActionResult Index()
        {
            Database db = new Database();
            Chitietve ctve = new Chitietve();
            List<tbl_Xeravao> dsxeravao = db.tbl_Xeravao.ToList();
            tbl_Khachhang khachhang = new tbl_Khachhang();
            List<tbl_Ve> dsvexe = db.tbl_Ve.ToList();
            List<tbl_Loaixe> loaixe = db.tbl_Loaixe.ToList();
            List<tbl_Khachhang> dskh = db.tbl_Khachhang.ToList();
            List<tbl_Xe> dsXe = db.tbl_Xe.ToList();
            ViewBag.danhsachKhachhang = dskh;
            ViewBag.danhsachloaixe = loaixe;
            ViewBag.danhsachve = dsvexe;
            ViewBag.danhsachxe = dsXe;
            ViewBag.danhsachXeravao = dsxeravao;
            return View();
        }
        public JsonResult XemChitietve()
        {
            long vexeID = Convert.ToInt64(Request["mavexe"]);
            Chitietve ctv = new Chitietve();
            List<Chitietve> dsctv = new List<Chitietve>();


            if (vexeID > 0)
            {
                dsctv = ctv.GetChitietVeByVexeID(vexeID);
            }
            var jsonSerialiser = new JavaScriptSerializer();
            var result = jsonSerialiser.Serialize(dsctv);

            return Json(result);

        }
    }
}