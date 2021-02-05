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

    public partial class tbl_Nhanvien
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_Nhanvien()
        {
            tbl_Calam_Nhanvien = new HashSet<tbl_Calam_Nhanvien>();
            tbl_Hoadon = new HashSet<tbl_Hoadon>();
            tbl_Xeravao = new HashSet<tbl_Xeravao>();
        }

        public tbl_Nhanvien(string pK_iNhanvienID, string sHoten, string dNgaysinh, string dNgayvaolam, string bGioitinh, string sSodienthoai, string sDiachi, string bTrangthailamviec, string fK_iTaikhoanID, string sSoCMND)
        {
            PK_iNhanvienID = Convert.ToInt16(pK_iNhanvienID);
            this.sHoten = sHoten;
            this.dNgaysinh = Convert.ToDateTime(dNgaysinh);
            this.dNgayvaolam = Convert.ToDateTime(dNgayvaolam);
            this.bGioitinh = Convert.ToBoolean(bGioitinh);
            this.sSodienthoai = sSodienthoai;
            this.sDiachi = sDiachi;
            this.bTrangthailamviec = Convert.ToByte(bTrangthailamviec);
            FK_iTaikhoanID = Convert.ToInt64(fK_iTaikhoanID);
            this.sSoCMND = sSoCMND;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short PK_iNhanvienID { get; set; }

        [Required]
        [StringLength(150)]
        public string sHoten { get; set; }

        public DateTime dNgaysinh { get; set; }

        public DateTime dNgayvaolam { get; set; }

        public bool bGioitinh { get; set; }

        [Required]
        [StringLength(10)]
        public string sSodienthoai { get; set; }

        [Required]
        [StringLength(200)]
        public string sDiachi { get; set; }

        public byte bTrangthailamviec { get; set; }

        public long FK_iTaikhoanID { get; set; }

        [StringLength(12)]
        public string sSoCMND { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Calam_Nhanvien> tbl_Calam_Nhanvien { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Hoadon> tbl_Hoadon { get; set; }

        public virtual tbl_Taikhoan tbl_Taikhoan { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Xeravao> tbl_Xeravao { get; set; }
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Database"].ConnectionString);

      
        public List<tbl_Nhanvien> GetNhanvienByPK (short nhanvienID)
        {
            List<tbl_Nhanvien> danhsachnhanvien = new List<tbl_Nhanvien>();
            SqlCommand cmd;
            SqlDataReader dar;
            if(nhanvienID == 0)
            {
                cmd = new SqlCommand("Select * from tbl_Nhanvien", conn);
                cmd.CommandType = CommandType.Text;
            }
            else
            {
                cmd = new SqlCommand("Select * from tbl_Nhanvien where PK_iNhanvienID = " + nhanvienID, conn);
                cmd.CommandType = CommandType.Text;
            }
            conn.Open();
            dar = cmd.ExecuteReader();
            if (dar.HasRows)
            {
                while (dar.Read())
                {
                    tbl_Nhanvien nhanvien = new tbl_Nhanvien(
                        dar["PK_iNhanvienID"].ToString(),
                        dar["sHoten"].ToString(),
                        dar["dNgaysinh"].ToString(),
                        dar["dNgayvaolam"].ToString(),
                        dar["bGioitinh"].ToString(),
                    dar["sSodienthoai"].ToString(),
                       dar["sDiachi"].ToString(),
                    dar["bTrangthailamviec"].ToString(),
                        dar["FK_iTaikhoanID"].ToString(),
                        dar["sSoCMND"].ToString());
                 
                    danhsachnhanvien.Add(nhanvien);

                }
            }
            return danhsachnhanvien;
        }
        public bool ThemNhanvien (string hoten, DateTime ngaysinh, string diachi, bool gioitinh, string sodienthoai, string socmnd, DateTime ngayvaolam, long mataikhoan, byte trangthailamviec)
        {
            bool ketqua = false;
            try
            {
                SqlCommand cmd = new SqlCommand("sp_InsertNhanvien", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@hoten", hoten);
                cmd.Parameters.AddWithValue("@ngaysinh", ngaysinh);
                cmd.Parameters.AddWithValue("@ngayvaolam", ngayvaolam);              
                cmd.Parameters.AddWithValue("@gioitinh", gioitinh);
                cmd.Parameters.AddWithValue("@sodienthoai", sodienthoai);
                cmd.Parameters.AddWithValue("@diachi", diachi);
                cmd.Parameters.AddWithValue("@trangthailamviec", trangthailamviec);
                cmd.Parameters.AddWithValue("@mataikhoan", mataikhoan);
                cmd.Parameters.AddWithValue("@socmnd", socmnd);
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

        public bool SuaNhanvien ( short nhanvienID,string hoten, DateTime ngaysinh, string diachi, bool gioitinh, string sodienthoai, string socmnd, DateTime ngayvaolam, long mataikhoan, byte trangthailamviec)
        {
            bool ketqua = false;
            try
            {
                SqlCommand cmd = new SqlCommand("sp_UpdateNhanvien", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@manhanvien", nhanvienID);
                cmd.Parameters.AddWithValue("@hoten", hoten);
                cmd.Parameters.AddWithValue("@ngaysinh", ngaysinh);
                cmd.Parameters.AddWithValue("@ngayvaolam", ngayvaolam);
                cmd.Parameters.AddWithValue("@gioitinh", gioitinh);
                cmd.Parameters.AddWithValue("@sodienthoai", sodienthoai);
                cmd.Parameters.AddWithValue("@diachi", diachi);
                cmd.Parameters.AddWithValue("@trangthailamviec", trangthailamviec);
                cmd.Parameters.AddWithValue("@mataikhoan", mataikhoan);
                cmd.Parameters.AddWithValue("@socmnd", socmnd);
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
    }
}
