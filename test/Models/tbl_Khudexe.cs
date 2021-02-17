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
    using System.Linq;

    public partial class tbl_Khudexe
    {
        [Key]
        public short PK_iKhuID { get; set; }

        [Required]
        [StringLength(50)]
        public string sTenkhu { get; set; }

        public short FK_iLoaixeID { get; set; }
        public tbl_Khudexe() { }

        public tbl_Khudexe(string pK_iKhuID, string sTenkhu, string fK_iLoaixeID)
        {
            PK_iKhuID = Convert.ToInt16(pK_iKhuID);
            this.sTenkhu = sTenkhu;
            FK_iLoaixeID = Convert.ToInt16(fK_iLoaixeID);
        }

        public virtual tbl_Loaixe tbl_Loaixe { get; set; }

        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Database"].ConnectionString);

        public List<tbl_Khudexe> GetKhudexeByPK(short khudexeID)
        {
            List<tbl_Khudexe> dsKhudexe = new List<tbl_Khudexe>();
            SqlDataReader dar;
            SqlCommand cmd;
            if (khudexeID == 0)
            {
                cmd = new SqlCommand("Select * from tbl_Khudexe", conn);
                cmd.CommandType = System.Data.CommandType.Text;
            }
            else
            {
                cmd = new SqlCommand("sp_GetKhudexeByPK", conn);
                cmd.Parameters.AddWithValue("@khudexeID", khudexeID);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
            }
            conn.Open();
            dar = cmd.ExecuteReader();
            if (dar.HasRows)
            {
                while (dar.Read())
                {
                    tbl_Khudexe khudexe = new tbl_Khudexe(
                        dar["PK_iKhuID"].ToString(),
                    dar["sTenkhu"].ToString(),
                    dar["FK_iLoaixeID"].ToString());
                    dsKhudexe.Add(khudexe);
                }
            }
            return dsKhudexe;
        }
        public bool ThemKhudexe (string tenkhu, short loaixeID)
        {
            bool ketqua = false;
            try
            {
                SqlCommand cmd = new SqlCommand("sp_ThemKhudexe", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@tenkhu", tenkhu);
                cmd.Parameters.AddWithValue("@loaixe", loaixeID);               
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

        public bool SuaKhudexe (short khudexeID, string tenkhu, short loaixeID)
        {
            bool ketquaSua = false;
            try
            {
                SqlCommand cmd = new SqlCommand("sp_Suakhudexe", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@makhudexe", khudexeID);
                cmd.Parameters.AddWithValue("@tenkhu", tenkhu);
                cmd.Parameters.AddWithValue("@loaixe", loaixeID);
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

        public bool XoaKhudexe (short khudexeID)
        {
            bool ketquaXoa = false;
            try
            {
                SqlCommand cmd = new SqlCommand("sp_Xoakhudexe", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@makhudexe", khudexeID);
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
