using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using test.Models;

namespace test.Controllers
{
    public class BaocaoController : Controller
    {
        // GET: Baocao
        public ActionResult Index()
        {
            if (Session["IsLogin"].Equals(true))
            {
                tbl_Loaixe loaixe = new tbl_Loaixe();
                List<tbl_Loaixe> dsLoaixe = loaixe.GetLoaixeByPK(0);
                tbl_Loaive loaive = new tbl_Loaive();
                List<tbl_Loaive> dsLoaive = loaive.GetLoaiveByPK(0);
                ViewBag.dsLoaive = dsLoaive;
                ViewBag.dsLoaixe = dsLoaixe;

                return View();
            }
            else
                return RedirectToAction("Index", "Login");
            
        }

        public string BaocaoDoanhthuthang()
        {
            byte loaiveID = Convert.ToByte(Request["loaive"]);
            short loaixeID = Convert.ToInt16(Request["loaixe"]);
            DateTime ngaybatdau = Convert.ToDateTime(Request["ngaybatdau"]);
            DateTime ngayketthuc = Convert.ToDateTime(Request["ngayketthuc"]);
            if(loaiveID > 0)
            {
                if(loaiveID == 1)
                {

                }
                else
                {

                }
               
            }
            return "";

        }
        /*
        public void DownloadExcel()
        {
            HD_NCKH hD_NCKH = new HD_NCKH();
            List<HD_NCKH> listhdnckh = hD_NCKH.Get_NCKH_CANBO_REPORT(Session["canboID"].ToString(), Convert.ToDateTime(Session["ngaybatdau"]), Convert.ToDateTime(Session["ngayketthuc"]));
            if (listhdnckh.Count > 0)
            {
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                ExcelPackage Ep = new ExcelPackage();
                ExcelWorksheet Sheet = Ep.Workbook.Worksheets.Add("Report");
                Sheet.Cells["A1:C1"].Merge = true;
                Sheet.Cells["A1"].Style.Font.Bold = true;
                Sheet.Cells["A1"].Style.Font.Size = 18;
                Sheet.Cells["A1"].Style.Font.Name = "Times New Roman";
                Sheet.Cells["A1"].Value = "Báo cáo hoạt động nghiên cứu khoa học";
                Sheet.Cells["A1"].Style.Border.BorderAround(ExcelBorderStyle.Thin);

                Sheet.Cells["A2"].Value = "STT";
                Sheet.Cells["B2"].Value = "Họ tên cán bộ";
                Sheet.Cells["C2"].Value = "Tên hoạt động nghiên cứu khoa học";
                Sheet.Cells["A2:C2"].Style.Font.Bold = true;
                Sheet.Cells["A2:C2"].Style.Font.Name = "Times New Roman";
                Sheet.Cells["A2:C2"].Style.Font.Size = 13;
                Sheet.Cells["A2:C2"].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                int row = 3;
                int stt = 1;
                foreach (var item in listhdnckh)
                {
                    Sheet.Cells[string.Format("A{0}", row)].Value = stt++;
                    Sheet.Cells[string.Format("B{0}", row)].Value = item.ten_canbo;
                    Sheet.Cells[string.Format("C{0}", row)].Value = item.STenHoatDong;
                    Sheet.Cells[string.Format("A{0}", row)].Style.Font.Name = "Times New Roman";
                    Sheet.Cells[string.Format("B{0}", row)].Style.Font.Name = "Times New Roman";
                    Sheet.Cells[string.Format("C{0}", row)].Style.Font.Name = "Times New Roman";
                    Sheet.Cells[string.Format("A{0}", row)].Style.Font.Size = 11;
                    Sheet.Cells[string.Format("B{0}", row)].Style.Font.Size = 11;
                    Sheet.Cells[string.Format("C{0}", row)].Style.Font.Size = 11;
                    Sheet.Cells[string.Format("A{0}", row)].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                    Sheet.Cells[string.Format("B{0}", row)].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                    Sheet.Cells[string.Format("C{0}", row)].Style.Border.BorderAround(ExcelBorderStyle.Thin);

                    row++;
                }
                Sheet.Cells["A:AZ"].AutoFitColumns();

                Response.Clear();
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment: filename=" + "Report.xlsx");
                Response.BinaryWrite(Ep.GetAsByteArray());
                Response.End();

            }
        }*/

        public void ExportExcel()
        {

        }
    }
}