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

    public partial class tbl_Ve
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_Ve()
        {
            tbl_CT_Hoadon = new HashSet<tbl_CT_Hoadon>();
            tbl_Xeravao = new HashSet<tbl_Xeravao>();
        }

        [Key]
        public long PK_iVeID { get; set; }

        public tbl_Ve(string pK_iVeID, string sMave, string tNgaytao, string bTrangthai, string tNgayhethan)
        {
            PK_iVeID = Convert.ToInt64(pK_iVeID);
            this.sMave = sMave;
            this.tNgaytao = Convert.ToDateTime(tNgaytao);
            this.bTrangthai = Convert.ToBoolean(bTrangthai);
            this.tNgayhethan = Convert.ToDateTime(tNgayhethan);
        }

        [Required]
        [StringLength(10)]
        public string sMave { get; set; }

        public DateTime tNgaytao { get; set; }

        public bool bTrangthai { get; set; }
        public DateTime tNgayhethan { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_CT_Hoadon> tbl_CT_Hoadon { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Xeravao> tbl_Xeravao { get; set; }
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Database"].ConnectionString);
        public List<tbl_Ve> GetVexeByPK(long vexeID)
        {
            List<tbl_Ve> danhsachVexe = new List<tbl_Ve>();
            SqlCommand cmd;
            SqlDataReader dar;
            if (vexeID == 0)
            {
                cmd = new SqlCommand("Select * from tbl_Ve", conn);
                cmd.CommandType = CommandType.Text;
            }
            else
            {
                cmd = new SqlCommand("Select * from tbl_Ve where PK_iVeID =" + vexeID, conn);
                cmd.CommandType = CommandType.Text;
                SqlParameter mavexe = cmd.Parameters.Add("PK_iVeID", SqlDbType.BigInt);
                mavexe.Value = vexeID;
            }
            conn.Open();
            dar = cmd.ExecuteReader();
            if (dar.HasRows)
            {
                while (dar.Read())
                {
                    tbl_Ve taikhoan = new tbl_Ve(
                        dar["PK_iVeID"].ToString(),
                        dar["sMave"].ToString(),
                        dar["tNgaytao"].ToString(),
                        dar["bTrangthai"].ToString(),
                        dar["tNgayhethan"].ToString()
                    );
                    danhsachVexe.Add(taikhoan);
                }
            }
            return danhsachVexe;
        }

        public List<tbl_Ve> GetVeBySoSeri(string masove)
        {
            List<tbl_Ve> danhsachvexe = new List<tbl_Ve>();
            SqlCommand cmd;
            SqlDataReader dar;
            cmd = new SqlCommand("sp_GetveBySeri", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter soseri = cmd.Parameters.Add("@masove", SqlDbType.NVarChar);
            soseri.Value = masove;
            conn.Open();
            dar = cmd.ExecuteReader();
            if (dar.HasRows)
            {
                while (dar.Read())
                {
                    tbl_Ve vexe = new tbl_Ve(
                       dar["PK_iVeID"].ToString(),
                       dar["sMave"].ToString(),
                       dar["tNgaytao"].ToString(),
                       dar["bTrangthai"].ToString(),
                       dar["tNgayhethan"].ToString()
                   );

                    danhsachvexe.Add(vexe);

                }
            }
            return danhsachvexe;
        }

        public bool InsertVexe(string maVexe, DateTime ngayhethan)
        {
            bool ketqua = false;
            try
            {
                SqlCommand cmd;
                SqlDataReader dar;
                cmd = new SqlCommand("sp_InsertVe", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@serive", maVexe);
                cmd.Parameters.AddWithValue("@ngaytao", DateTime.Now);
                cmd.Parameters.AddWithValue("@trangthai", 1);
                cmd.Parameters.AddWithValue("@ngayhethan", ngayhethan);
                conn.Open();
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                    ketqua = true;
                else
                    ketqua = false;
                conn.Close();
            }
            catch (Exception ex)
            {
                ketqua = false;
            }
            return ketqua;
           
        }

        public bool UpdateVexe (long vexeID, string maVexe, DateTime ngaytao, DateTime ngayhethan)
        {
            bool kq = false;
            try
            {
                SqlCommand cmd;
                cmd = new SqlCommand("sp_UpdateVexe", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@mavexe", vexeID);
                cmd.Parameters.AddWithValue("@serive", maVexe);
                cmd.Parameters.AddWithValue("@ngaytao", DateTime.Now);
                cmd.Parameters.AddWithValue("@trangthai", 1);
                cmd.Parameters.AddWithValue("@ngayhethan", ngayhethan);
                conn.Open();
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                    kq = true;
                else
                    kq = false;
                conn.Close();

            }
            catch(Exception ex)
            {
                kq = false;
            }
            return kq;
        }
        /// <summary>
        /// chuyển trạng thái vé xe
        /// </summary>
        /// <param name="vexeID"></param>
        /// <param name="trangthai"></param>
        /// <returns></returns>
        public bool ChuyentrangthaiVexe (long vexeID, bool trangthai)
        {
            bool kq = false;
            try
            {
                SqlCommand cmd;
                cmd = new SqlCommand("sp_ChuyentrangthaiVexe", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@mavexe", vexeID);
                cmd.Parameters.AddWithValue("@trangthai", trangthai);
                conn.Open();
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                    kq = true;
                else
                    kq = false;
                conn.Close();
            } catch(Exception ex)
            {
                kq = false;
            }
            return kq;
        }
    }
}
