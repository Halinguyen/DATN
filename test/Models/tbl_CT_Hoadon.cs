namespace test.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_CT_Hoadon
    {
        [Key]
        public long PK_iCTHDID { get; set; }

        public long FK_iVexeID { get; set; }

        public decimal mDongia { get; set; }

        public int iSoluong { get; set; }

        public long FK_iHoadonID { get; set; }

        public virtual tbl_Hoadon tbl_Hoadon { get; set; }

        public virtual tbl_Ve tbl_Ve { get; set; }
    }
}
