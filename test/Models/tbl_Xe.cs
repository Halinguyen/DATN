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

    public partial class tbl_Xe
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        [Key]
        public long PK_iXeID { get; set; }

        [Required]
        [StringLength(50)]
        public string sBiensoxe { get; set; }

        public short FK_iLoaixeID { get; set; }
        public string sAnhxe { get; set; }

        public virtual tbl_Loaixe tbl_Loaixe { get; set; }
       

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Xeravao> tbl_Xeravao { get; set; }

        public tbl_Xe()
        {

        }

        public tbl_Xe(string pK_iXeID, string sBiensoxe, string fK_iLoaixeID, string sAnhxe)
        {
            PK_iXeID = Convert.ToInt64(pK_iXeID);
            this.sBiensoxe = sBiensoxe;
            FK_iLoaixeID = Convert.ToInt16(fK_iLoaixeID);
            this.sAnhxe = sAnhxe;
        }

        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Database"].ConnectionString);

        public List<tbl_Xe> GetXeByPK(long xeID)
        {
            List<tbl_Xe> dsXe = new List<tbl_Xe>();
            try
            {
                SqlDataReader dar;
                SqlCommand cmd = new SqlCommand("sp_GetXeByPK", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter maxe = cmd.Parameters.Add("@maxe", SqlDbType.BigInt);
                maxe.Value = xeID;
                conn.Open();
                dar = cmd.ExecuteReader();
                if (dar.HasRows)
                {
                    while (dar.Read())
                    {
                        tbl_Xe xe = new tbl_Xe(
                            dar["PK_iXeID"].ToString(),
                            dar["sBiensoxe"].ToString(),
                            dar["FK_iLoaixeID"].ToString(),
                            dar["sAnhxe"].ToString()
                        );
                        dsXe.Add(xe);
                    }

                }
            }
            catch (Exception)
            {

            }
            return dsXe;
        }


        public List<tbl_Xe> GetXeByBiensoxe(string biensoxe)
        {
            List<tbl_Xe> dsXe = new List<tbl_Xe>();
            try
            {
                SqlDataReader dar;
                SqlCommand cmd = new SqlCommand("sp_GetXeByBiensoxe", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter soxe = cmd.Parameters.Add("@biensoxe", SqlDbType.BigInt);
                soxe.Value = biensoxe;
                conn.Open();
                dar = cmd.ExecuteReader();
                if (dar.HasRows)
                {
                    while (dar.Read())
                    {
                        tbl_Xe xe = new tbl_Xe(
                            dar["PK_iXeID"].ToString(),
                            dar["sBiensoxe"].ToString(),
                            dar["FK_iLoaixeID"].ToString(),
                             dar["sAnhxe"].ToString()
                        );
                        dsXe.Add(xe);
                    }

                }
            }
            catch (Exception)
            {

            }
            return dsXe;
        }






    }
}
