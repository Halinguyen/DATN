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

    public partial class tbl_Loaive
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_Loaive()
        {
            tbl_Giave = new HashSet<tbl_Giave>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte PK_iLoaiveID { get; set; }

        [Required]
        [StringLength(50)]
        public string sTenloaive { get; set; }

        public tbl_Loaive(string pK_iLoaiveID, string sTenloaive)
        {
            PK_iLoaiveID = Convert.ToByte(pK_iLoaiveID);
            this.sTenloaive = sTenloaive;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Giave> tbl_Giave { get; set; }
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Database"].ConnectionString);
    }
}
