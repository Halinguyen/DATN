using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace test.Models.obj
{
    public class khachhangobj:tbl_Khachhang
    {

        public khachhangobj()
        {    
            
        }

        public khachhangobj(string pK_iKhachhangID, string sHoten, string sSodienthoai, string sDiachi, string bGioitinh, string fK_iTaikhoanID, string sSoCMND, string fK_iVeID, string sUsername, string sMave)
        {
            PK_iKhachhangID = Convert.ToInt64(pK_iKhachhangID);
            this.sHoten = sHoten;
            this.sSodienthoai = sSodienthoai;
            this.sDiachi = sDiachi;
            this.bGioitinh = Convert.ToBoolean(bGioitinh);
            FK_iTaikhoanID = Convert.ToInt64(fK_iTaikhoanID);
            this.sSoCMND = sSoCMND;
            FK_iVeID = Convert.ToInt64(fK_iVeID);
            this.Username = sUsername;
            this.Soseri = sMave;
        }

        public string Username { get; set; }
        public string Soseri { get; set; }
    }
}