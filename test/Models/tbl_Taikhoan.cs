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

    public partial class tbl_Taikhoan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_Taikhoan()
        {
            tbl_Khachhang = new HashSet<tbl_Khachhang>();
            tbl_Nhanvien = new HashSet<tbl_Nhanvien>();
            tbl_Phanquyen = new HashSet<tbl_Phanquyen>();
        }
        public tbl_Taikhoan(string taikhoanID, string username, string password, string ngaytao, string trangthai)
        {
            this.PK_iTaikhoanID = Convert.ToInt64(taikhoanID);
            this.sUsername = username;
            this.sMatkhau = password;
            this.dNgaytao = Convert.ToDateTime(ngaytao);
            this.bTrangthai = Convert.ToBoolean( trangthai);
        }
        [Key]
        public long PK_iTaikhoanID { get; set; }

        [Required]
        [StringLength(150)]
        public string sUsername { get; set; }

        [Required]
        [StringLength(50)]
        public string sMatkhau { get; set; }

        public DateTime dNgaytao { get; set; }

        public bool? bTrangthai { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Khachhang> tbl_Khachhang { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Nhanvien> tbl_Nhanvien { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Phanquyen> tbl_Phanquyen { get; set; }
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Database"].ConnectionString);
        public List<tbl_Taikhoan> GetTaikhoanByPK(long taikhoanID)
        {
            List<tbl_Taikhoan> danhsachTaikhoan = new List<tbl_Taikhoan>();
            SqlCommand cmd;
            SqlDataReader dar;
            if(taikhoanID == 0)
            {
                cmd = new SqlCommand("Select * from tbl_Taikhoan", conn);
                cmd.CommandType = CommandType.Text;
            }
            else
            {
                cmd = new SqlCommand("Select * from tbl_Taikhoan where PK_iTaikhoanID ="+taikhoanID, conn);
                cmd.CommandType = CommandType.Text;
                SqlParameter username = cmd.Parameters.Add("@FK_iTaikhoanID", SqlDbType.BigInt);
                username.Value = taikhoanID;
            }      
            conn.Open();
            dar = cmd.ExecuteReader();
            if (dar.HasRows)
            {
                while (dar.Read())
                {
                    tbl_Taikhoan taikhoan = new tbl_Taikhoan(
                        dar["PK_iTaikhoanID"].ToString(),
                        dar["sUsername"].ToString(),
                        dar["sMatkhau"].ToString(),
                        dar["dNgaytao"].ToString(),
                        dar["bTrangthai"].ToString()
                    );

                    danhsachTaikhoan.Add(taikhoan);
                }

            }
            return danhsachTaikhoan;
        }
        public string GetTaikhoanDangnhap(string tendangnhap, string matkhau)
        {
            string ketqua = "";
             List<tbl_Taikhoan> danhsachTaikhoan = new List<tbl_Taikhoan>();
            try
            {
                SqlDataReader dar;
                SqlCommand cmd = new SqlCommand("sp_Login", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter username = cmd.Parameters.Add("@username", SqlDbType.NVarChar);
                username.Value = tendangnhap;
                SqlParameter password = cmd.Parameters.Add("@matkhau", SqlDbType.VarChar);
                password.Value = matkhau;
                conn.Open();
                dar = cmd.ExecuteReader();
                if (dar.HasRows)
                {
                    while (dar.Read())
                    {
                        tbl_Taikhoan taikhoan = new tbl_Taikhoan(
                            dar["PK_iTaikhoanID"].ToString(),
                            dar["sUsername"].ToString(),
                            dar["sMatkhau"].ToString(),
                            dar["dNgaytao"].ToString(),
                            dar["bTrangthai"].ToString()
                        );
                        danhsachTaikhoan.Add(taikhoan);
                    }
                    tbl_Phanquyen phanquyen = new tbl_Phanquyen();
                    List<tbl_Phanquyen> glstPhanquyen = new List<tbl_Phanquyen>();

                    glstPhanquyen = phanquyen.XemQuyenByFK_iTaikhoanID(danhsachTaikhoan[0].PK_iTaikhoanID);
                    switch (glstPhanquyen[0].FK_iQuyenID)
                    {
                        case 1:
                            ketqua = "True1";
                            break;
                        case 2:
                            ketqua = "True2";
                            break;
                        case 3:
                            ketqua = "True3";
                            break;
                    }  
                }
                else
                    ketqua = "Sai";

            }
            catch (Exception)
            {
                
            }
            return ketqua;
        }
        public bool ThemTaiKhoan(string tendangnhap,string matkhau)
        {
            bool ketqua = false;
            try
            {
                    SqlCommand cmd = new SqlCommand("sp_Register", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@username", tendangnhap);
                    cmd.Parameters.AddWithValue("@password", matkhau);
                    cmd.Parameters.AddWithValue("@ngaytao", DateTime.Now);
                conn.Open();
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                    ketqua = true;
                else
                    ketqua = false;

                return ketqua;
                
            }
            catch (Exception ex)
            {
                return ketqua;
            }
        }
        public List<tbl_Taikhoan> getTaikhoanByTendangnhap (string tendangnhap)
        {
            List<tbl_Taikhoan> danhsachTaikhoan = new List<tbl_Taikhoan>();
            try
            {
                SqlDataReader dar;
                SqlCommand cmd = new SqlCommand("sp_GetTaikhoanByTendangnhap", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter username = cmd.Parameters.Add("@username", SqlDbType.NVarChar);
                username.Value = tendangnhap;
                conn.Open();
                dar = cmd.ExecuteReader();
                if (dar.HasRows)
                {
                    while (dar.Read())
                    {
                        tbl_Taikhoan taikhoan = new tbl_Taikhoan(
                            dar["PK_iTaikhoanID"].ToString(),
                            dar["sUsername"].ToString(),
                            dar["sMatkhau"].ToString(),
                            dar["dNgaytao"].ToString(),
                            dar["bTrangthai"].ToString()
                        );
                        danhsachTaikhoan.Add(taikhoan);
                    }
                  
                }
            }
            catch (Exception)
            {

            }
            return danhsachTaikhoan;
        
    }
        
    }
}
