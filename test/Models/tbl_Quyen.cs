namespace test.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_Quyen
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_Quyen()
        {
            tbl_Phanquyen = new HashSet<tbl_Phanquyen>();
        }

        [Key]
        public short PK_iQuyenID { get; set; }

        [Required]
        [StringLength(150)]
        public string sTenquyen { get; set; }

        [StringLength(150)]
        public string sMota { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Phanquyen> tbl_Phanquyen { get; set; }
    }
}
