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

    public partial class tbl_Phanquyen
    {
        [Key]
        public short PK_iNhomquyenID { get; set; }

        [StringLength(150)]
        public string sMota { get; set; }

        public short FK_iQuyenID { get; set; }

        public DateTime? dNgaybatdau { get; set; }

        public DateTime? dNgayhethan { get; set; }

        public long? FK_iTaikhoanID { get; set; }

        public virtual tbl_Quyen tbl_Quyen { get; set; }

        public virtual tbl_Taikhoan tbl_Taikhoan { get; set; }
        public tbl_Phanquyen()
        {

        }
        public tbl_Phanquyen(string phanquyenID, string mota, string FK_QuyenID, string ngaybatdau, string ngayhethan, string FK_TaikhoanID)
        {
            this.PK_iNhomquyenID = Convert.ToInt16(phanquyenID);
            this.sMota = mota;
            this.FK_iQuyenID = Convert.ToInt16(FK_QuyenID);
            this.dNgaybatdau = Convert.ToDateTime(ngaybatdau);
            this.dNgayhethan = Convert.ToDateTime(ngayhethan);
            this.FK_iTaikhoanID = Convert.ToInt64(FK_TaikhoanID);

        }
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Database"].ConnectionString);
        public List<tbl_Phanquyen> XemQuyenByFK_iTaikhoanID(long taikhoanID)
        {
            List<tbl_Phanquyen> danhsachQuyen = new List<tbl_Phanquyen>();
            SqlDataReader dar;
            SqlCommand cmd = new SqlCommand("sp_Xemquyen", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter username = cmd.Parameters.Add("@FK_iTaikhoanID", SqlDbType.BigInt);
            username.Value = taikhoanID;
            conn.Open();
            dar = cmd.ExecuteReader();
            if (dar.HasRows)
            {
                while (dar.Read())
                {
                    tbl_Phanquyen phanquyen = new tbl_Phanquyen(
                        dar["PK_iNhomquyenID"].ToString(),
                        dar["sMota"].ToString(),
                        dar["FK_iQuyenID"].ToString(),
                        dar["dNgaybatdau"].ToString(),
                        dar["dNgayhethan"].ToString(),
                        dar["FK_iTaikhoanID"].ToString()
                    );

                    danhsachQuyen.Add(phanquyen);
                }
            }
            return danhsachQuyen;
        }

        public bool ThemPhanQuyen (string mota, short maquyen, DateTime ngaybatdau, DateTime ngayketthuc, long taikhoanID)
        {
            bool ketqua = false;
            try
            {
                SqlCommand cmd = new SqlCommand("sp_InsertPhanquyen", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@mota", mota);
                cmd.Parameters.AddWithValue("@maquyen", maquyen);
                cmd.Parameters.AddWithValue("@ngaybatdau", ngaybatdau);
                cmd.Parameters.AddWithValue("@ngayketthuc", ngayketthuc);
                cmd.Parameters.AddWithValue("@mataikhoan", taikhoanID);
                conn.Open();
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                    ketqua = true;
                else
                    ketqua = false;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("ERROR: " + ex);
                ketqua = false;
            }
            return ketqua;
        }
    }
}
