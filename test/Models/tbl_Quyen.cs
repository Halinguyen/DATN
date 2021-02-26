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

    public partial class tbl_Quyen
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]

        [Key]
        public short PK_iQuyenID { get; set; }

        [Required]
        [StringLength(150)]
        public string sTenquyen { get; set; }

        [StringLength(150)]
        public string sMota { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Phanquyen> tbl_Phanquyen { get; set; }
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Database"].ConnectionString);
        public tbl_Quyen()
        {

        }

        public tbl_Quyen(string pK_iQuyenID, string sTenquyen, string sMota)
        {
            PK_iQuyenID = Convert.ToInt16(pK_iQuyenID);
            this.sTenquyen = sTenquyen;
            this.sMota = sMota;
        }

        public List<tbl_Quyen> GetQuyenByPK(short quyenID)
        {
            List<tbl_Quyen> danhsachQuyen = new List<tbl_Quyen>();
            if (quyenID >= 0)
            {
                SqlCommand cmd;
                SqlDataReader dar;

                cmd = new SqlCommand("sp_GetQuyenByPK", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@maquyen", quyenID);
                conn.Open();
                dar = cmd.ExecuteReader();
                if (dar.HasRows)
                {
                    while (dar.Read())
                    {
                        tbl_Quyen quyen = new tbl_Quyen(
                            dar["PK_iQuyenID"].ToString(),
                            dar["sTenquyen"].ToString(),
                            dar["sMota"].ToString());
                        danhsachQuyen.Add(quyen);
                    }
                }
                conn.Close();
            }
            return danhsachQuyen;
        }
    }
}
