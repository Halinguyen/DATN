using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using test.Models;

namespace test.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public string Dangnhap()
        {
            tbl_Taikhoan tk = new tbl_Taikhoan();
            var tendangnhap = Request["tendangnhap"];
            var matkhau = Request["matkhau"];
            string kq = tk.GetTaikhoanDangnhap(tendangnhap, matkhau);
            if (!kq.Equals("Sai"))
            {
                Session["IsLogin"] = true;
                Session["username"] = tendangnhap;
                Session["password"] = matkhau;
                List<tbl_Taikhoan> dsTaikhoan = new List<tbl_Taikhoan>();
                dsTaikhoan = tk.getTaikhoanByTendangnhap(tendangnhap);
                if(dsTaikhoan.Count > 0)
                {
                    Session["userID"] = dsTaikhoan[0].PK_iTaikhoanID;
                }                
            }
            else
            {
                Session["IsLogin"] = false;
                Session["username"] = "";
                Session["password"] = "";
                Session["userID"] = 0;
            }
            return kq;
        }
    }
}