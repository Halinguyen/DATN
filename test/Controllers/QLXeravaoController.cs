using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using test.Models;

namespace test.Controllers
{
    public class QLXeravaoController : Controller
    {
        // GET: QLXeravao
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult Upload()
        {
            string path ="";
            for (int i = 0; i < Request.Files.Count; i++)
            {
                HttpPostedFileBase file = Request.Files[i]; //Uploaded file
                                                            //Use the following properties to get file's name, size and MIMEType
                int fileSize = file.ContentLength;
                string fileName = file.FileName;
                string mimeType = file.ContentType;
                System.IO.Stream fileContent = file.InputStream;
                //To save file, use SaveAs method
                file.SaveAs(Server.MapPath("~/uploads/") + fileName); //File will be saved in application root
                path = Server.MapPath("~/uploads/") + fileName;
            }
           
            return Json(""+path);
        }

        public string NhandienBsx()
        {
            string imageUrl = Request["name_image"];
            String server_ip = "192.168.1.214";
            String server_path = "http://" + server_ip + ":5000/detect";
            String retStr = sendPOST(server_path,imageUrl);
            return retStr;

        }
        // Ham goi HTTP POST len server de detect
        private String sendPOST(String url,string nameImage )
        {
            try
            {
                var request = (HttpWebRequest)WebRequest.Create(url);
                request.Timeout = 5000;
                var postData = "image=" + nameImage;

                var data = Encoding.ASCII.GetBytes(postData);
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = data.Length;

                using (var stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }
                var response = (HttpWebResponse)request.GetResponse();

                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

                return responseString;
            }
            catch (Exception ex)
            {
                return "Exception" + ex.ToString();
            }
        }

        public bool Luuxe()
        {
            tbl_Xe xe = new tbl_Xe();
            tbl_Ve ve = new tbl_Ve();
            long vexeID = 0;
            string biensoxe = Request["biensoxe"];
            string hinhanh = Request["hinhanh"];
            string mavexe = Request["mavexe"];
            short loaixeID = Convert.ToInt16(Request["loaixe"]);
            List<tbl_Ve> dsve = ve.GetVeBySoSeri(mavexe);
            if(dsve.Count > 0)
            {
                vexeID = dsve[0].PK_iVeID;
            }
            if (xe.InsertXe(biensoxe, loaixeID, hinhanh, vexeID)){
                return true;
            }
            else {
                return false;
            }


        }
    }
}