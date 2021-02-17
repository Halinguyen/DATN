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

    public partial class tbl_Loaixe
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        
        [Key]
        public short PK_iLoaixeID { get; set; }

        [Required]
        [StringLength(100)]
        public string sTenLoaixe { get; set; }

        public tbl_Loaixe(string pK_iLoaixeID, string sTenLoaixe)
        {
            PK_iLoaixeID = Convert.ToInt16(pK_iLoaixeID);
            this.sTenLoaixe = sTenLoaixe;
        }
        public tbl_Loaixe() { }
       
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Giave> tbl_Giave { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Khudexe> tbl_Khudexe { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Xe> tbl_Xe { get; set; }
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Database"].ConnectionString);

        public List<tbl_Loaixe> GetLoaixeByPK(long loaixeID)
        {
            List<tbl_Loaixe> danhsachLoaixe = new List<tbl_Loaixe>();
            SqlCommand cmd;
            SqlDataReader dar;
            if (loaixeID == 0)
            {
                cmd = new SqlCommand("Select * from tbl_Loaixe", conn);
                cmd.CommandType = CommandType.Text;
            }
            else
            {
                cmd = new SqlCommand("sp_GetloaixeByPK", conn);
                cmd.Parameters.AddWithValue("@loaixeID", loaixeID);
                cmd.CommandType = CommandType.StoredProcedure;

            }
            conn.Open();
            dar = cmd.ExecuteReader();
            if (dar.HasRows)
            {
                while (dar.Read())
                {
                    tbl_Loaixe loaixe = new tbl_Loaixe(
                        dar["PK_iLoaixeID"].ToString(),
                    dar["sTenLoaixe"].ToString()
                        );
                    danhsachLoaixe.Add(loaixe);
                }
            }
            return danhsachLoaixe;
        }

        public bool ThemLoaixe (string tenloaixe)
        {
            bool ketqua = false;
            try
            {
                SqlCommand cmd = new SqlCommand("sp_ThemLoaixe", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@tenloaixe", tenloaixe);              
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

        public bool SuaLoaixe(short loaixeID, string tenloaixe)
        {
            bool ketqua = false;
            try
            {
                SqlCommand cmd = new SqlCommand("sp_SuaLoaixe", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@loaixeID", loaixeID);
                cmd.Parameters.AddWithValue("@tenloaixe", tenloaixe);
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
        public bool XoaLoaixe (short loaixeID)
        {
            bool ketqua = false;
            try
            {
                SqlCommand cmd = new SqlCommand("sp_XoaLoaixe", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@loaixeID", loaixeID);
                conn.Open();
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                    ketqua = true;
                else
                    ketqua = false;
         
            }catch(Exception ex)
            {
                ketqua = false;
            }
            return ketqua;
        }
        
    }
}
