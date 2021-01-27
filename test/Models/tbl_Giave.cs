namespace test.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_Giave
    {
        [Key]
        public short PK_iGiaveID { get; set; }

        public DateTime dNgaybatdauApdung { get; set; }

        public decimal mGia { get; set; }

        public short FK_iLoaixeID { get; set; }

        public byte FK_iLoaiveID { get; set; }

        public short FK_iKhunggioID { get; set; }

        public virtual tbl_Khunggio tbl_Khunggio { get; set; }

        public virtual tbl_Loaive tbl_Loaive { get; set; }

        public virtual tbl_Loaixe tbl_Loaixe { get; set; }
    }
}
