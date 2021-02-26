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

    public partial class tbl_Khunggio
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_Khunggio()
        {

        }

        public tbl_Khunggio(string pK_iKhunggioID, string dGiobatdau, string dGiohet)
        {
            PK_iKhunggioID = Convert.ToInt16(pK_iKhunggioID);
            this.dGiobatdau = dGiobatdau;
            this.dGiohet = dGiohet;
        }

        [Key]
        public short PK_iKhunggioID { get; set; }

        public string dGiobatdau { get; set; }

        public string dGiohet { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Giave> tbl_Giave { get; set; }
        //sp_GetKhunggio
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Database"].ConnectionString);
        public List<tbl_Khunggio> GetKhunggioByPK(short khunggioID)
        {
            List<tbl_Khunggio> dsKhunggio = new List<tbl_Khunggio>();
            SqlCommand cmd;
            SqlDataReader dar;
            cmd = new SqlCommand("sp_GetKhunggio", conn);
            cmd.Parameters.AddWithValue("@khunggioID", khunggioID);
            cmd.CommandType = CommandType.StoredProcedure;
            conn.Open();
            dar = cmd.ExecuteReader();
            if (dar.HasRows)
            {
                while (dar.Read())
                {
                    tbl_Khunggio kg = new tbl_Khunggio(
                        dar["PK_iKhunggioID"].ToString(),
                    dar["dGiobatdau"].ToString(),
                     dar["dGiohet"].ToString()
                        );
                    dsKhunggio.Add(kg);
                }
            }
            return dsKhunggio;
        }



    }
}
