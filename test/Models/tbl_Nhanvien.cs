namespace test.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_Nhanvien
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_Nhanvien()
        {
            tbl_Calam_Nhanvien = new HashSet<tbl_Calam_Nhanvien>();
            tbl_Hoadon = new HashSet<tbl_Hoadon>();
            tbl_Xeravao = new HashSet<tbl_Xeravao>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short PK_iNhanvienID { get; set; }

        [Required]
        [StringLength(150)]
        public string sHoten { get; set; }

        public DateTime dNgaysinh { get; set; }

        public DateTime dNgayvaolam { get; set; }

        public bool bGioitinh { get; set; }

        [Required]
        [StringLength(10)]
        public string sSodienthoai { get; set; }

        [Required]
        [StringLength(200)]
        public string sDiachi { get; set; }

        public byte bTrangthailamviec { get; set; }

        public long FK_iTaikhoanID { get; set; }

        [StringLength(12)]
        public string sSoCMND { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Calam_Nhanvien> tbl_Calam_Nhanvien { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Hoadon> tbl_Hoadon { get; set; }

        public virtual tbl_Taikhoan tbl_Taikhoan { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Xeravao> tbl_Xeravao { get; set; }
    }
}
