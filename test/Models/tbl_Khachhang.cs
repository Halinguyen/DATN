namespace test.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Configuration;
    using System.Data;
    using System.Data.Entity.Spatial;
    using System.Data.SqlClient;
    using test.Models.obj;

    public partial class tbl_Khachhang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_Khachhang()
        {
            tbl_Hoadon = new HashSet<tbl_Hoadon>();
        }

        public tbl_Khachhang(string pK_iKhachhangID, string sHoten, string sSodienthoai, string sDiachi, string bGioitinh, string fK_iTaikhoanID, string sSoCMND, string fK_iVeID)
        {
            PK_iKhachhangID = Convert.ToInt64(pK_iKhachhangID);
            this.sHoten = sHoten;
            this.sSodienthoai = sSodienthoai;
            this.sDiachi = sDiachi;
            this.bGioitinh = Convert.ToBoolean(bGioitinh);
            FK_iTaikhoanID = Convert.ToInt64(fK_iTaikhoanID);
            this.sSoCMND = sSoCMND;
            FK_iVeID = Convert.ToInt64(fK_iVeID);
        }

        [Key]
        public long PK_iKhachhangID { get; set; }

        [Required]
        [StringLength(150)]
        public string sHoten { get; set; }

        [Required]
        [StringLength(10)]
        public string sSodienthoai { get; set; }

        [Required]
        [StringLength(150)]
        public string sDiachi { get; set; }

        public bool bGioitinh { get; set; }

        public long FK_iTaikhoanID { get; set; }

        [StringLength(12)]
        public string sSoCMND { get; set; }
        public long FK_iVeID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Database"].ConnectionString);
        public virtual ICollection<tbl_Hoadon> tbl_Hoadon { get; set; }

        public virtual tbl_Taikhoan tbl_Taikhoan { get; set; }
        public virtual tbl_Ve tbl_Ve { get; set; }
        public List<khachhangobj> GetKhachhangByPK(long khachhangID)
        {
            List<khachhangobj> danhsachKhachhang = new List<khachhangobj>();
            SqlCommand cmd;
            SqlDataReader dar;
            if (khachhangID == 0)
            {
                cmd = new SqlCommand("sp_GetKhachhangTaikhoan", conn);
                cmd.CommandType = CommandType.StoredProcedure;
            }
            else
            {
                cmd = new SqlCommand("sp_GetKhachhangTaikhoan", conn);                   
                cmd.CommandType = CommandType.StoredProcedure;

            }
            conn.Open();
            dar = cmd.ExecuteReader();
            if (dar.HasRows)
            {
                while (dar.Read())
                {
                    khachhangobj khachhang = new khachhangobj(
                        dar["PK_iKhachhangID"].ToString(),
                    dar["sHoten"].ToString(),
                    dar["sSodienthoai"].ToString(),
                    dar["sDiachi"].ToString(),
                    dar["bGioitinh"].ToString(),
                dar["FK_iTaikhoanID"].ToString(),
                dar["sSoCMND"].ToString(),
                dar["FK_iVeID"].ToString(),
                dar["sUsername"].ToString(),
                   dar["sMave"].ToString()

                        ); 
                    danhsachKhachhang.Add(khachhang);
                }
            }
            return danhsachKhachhang;
        }
        public bool ThemKhachhang(string hoten, string sodienthoai, string diachi, bool gioitinh, long mataikhoan, string socmnd, long maveID)
        {
            bool ketqua = false;
            try
            {
                SqlCommand cmd = new SqlCommand("sp_InsertKhachhang", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@hoten", hoten);
                cmd.Parameters.AddWithValue("@sodienthoai", sodienthoai);
                cmd.Parameters.AddWithValue("@diachi", diachi);
                cmd.Parameters.AddWithValue("@gioitinh", gioitinh);
                cmd.Parameters.AddWithValue("@mataikhoan", mataikhoan);
                cmd.Parameters.AddWithValue("@socmnd", socmnd);
                cmd.Parameters.AddWithValue("@mave", maveID);
                conn.Open();
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                    ketqua = true;
                else
                    ketqua = false;
            }
            catch (Exception ex)
            {
                ketqua = false;
            }
            return ketqua;
        }
        public bool SuaKhachhang(long khachhangID, string hoten, string sodienthoai, string diachi, bool gioitinh, long mataikhoan, string socmnd, long maveID)
        {
            bool ketquaSua = false;
            try
            {
                SqlCommand cmd = new SqlCommand("sp_UpdateKhachhang", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@makhachhang", khachhangID);
                cmd.Parameters.AddWithValue("@hoten", hoten);
                cmd.Parameters.AddWithValue("@sodienthoai", sodienthoai);
                cmd.Parameters.AddWithValue("@diachi", diachi);
                cmd.Parameters.AddWithValue("@gioitinh", gioitinh);
                cmd.Parameters.AddWithValue("@mataikhoan", mataikhoan);
                cmd.Parameters.AddWithValue("@socmnd", socmnd);
                cmd.Parameters.AddWithValue("@mave", maveID);
                conn.Open();
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                    ketquaSua = true;
                else
                    ketquaSua = false;
            }
            catch (Exception ex)
            {
                ketquaSua = false;
            }
            return ketquaSua;

        }
        public bool XoaKhachhang(long khachhangID)
        {
            bool ketquaXoa = false;
            try
            {
                SqlCommand cmd = new SqlCommand("sp_DeleteKhachhang", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@makhachhang", khachhangID);
                conn.Open();
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                    ketquaXoa = true;
                else
                    ketquaXoa = false;
            }
            catch (Exception ex)
            {
                ketquaXoa = false;
            }
            return ketquaXoa;
        }
    }
}
