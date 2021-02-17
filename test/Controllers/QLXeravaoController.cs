using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
    }
}