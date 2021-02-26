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

    public partial class tbl_Giave
    {
        [Key]
        public short PK_iGiaveID { get; set; }

        public DateTime dNgaybatdauApdung { get; set; }

        public decimal mGia { get; set; }

        public short FK_iLoaixeID { get; set; }

        public byte FK_iLoaiveID { get; set; }

        public short FK_iKhunggioID { get; set; }

        public virtual tbl_Khunggio tbl_Khunggio { get; set; }

        public virtual tbl_Loaive tbl_Loaive { get; set; }

        public virtual tbl_Loaixe tbl_Loaixe { get; set; }
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Database"].ConnectionString);
        
        public bool ThemGiave(short loaixeID, byte loaiveID, short khunggioID, decimal giave, DateTime ngayapdung)
        {
            bool ketqua = false;
            try
            {
                SqlCommand cmd = new SqlCommand("sp_InsertGiave", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ngayapdung", ngayapdung);
                cmd.Parameters.AddWithValue("@gia", giave);
                cmd.Parameters.AddWithValue("@loaixeID", loaixeID);
                cmd.Parameters.AddWithValue("@loaiveID", loaiveID );
                cmd.Parameters.AddWithValue("@khunggioID", khunggioID);
               
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
