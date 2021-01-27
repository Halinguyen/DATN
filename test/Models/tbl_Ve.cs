namespace test.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

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

        [Required]
        [StringLength(10)]
        public string sMave { get; set; }

        public DateTime dNgaytao { get; set; }

        public bool bTrangthai { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_CT_Hoadon> tbl_CT_Hoadon { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Xeravao> tbl_Xeravao { get; set; }
    }
}
