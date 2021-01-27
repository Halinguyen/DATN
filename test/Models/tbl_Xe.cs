namespace test.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_Xe
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_Xe()
        {
            tbl_Xeravao = new HashSet<tbl_Xeravao>();
        }

        [Key]
        public long PK_iXeID { get; set; }

        [Required]
        [StringLength(50)]
        public string sBiensoxe { get; set; }

        public short FK_iLoaixeID { get; set; }

        public virtual tbl_Loaixe tbl_Loaixe { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Xeravao> tbl_Xeravao { get; set; }
    }
}
