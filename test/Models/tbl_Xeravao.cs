namespace test.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_Xeravao
    {
        [Key]
        public long PK_iXeravaoID { get; set; }

        public long FK_iXeID { get; set; }

        public long FK_iVeID { get; set; }

        public short FK_iNhanvienID { get; set; }

        public DateTime? dGiovao { get; set; }

        public DateTime? dGiora { get; set; }

        public virtual tbl_Nhanvien tbl_Nhanvien { get; set; }

        public virtual tbl_Ve tbl_Ve { get; set; }

        public virtual tbl_Xe tbl_Xe { get; set; }
    }
}
