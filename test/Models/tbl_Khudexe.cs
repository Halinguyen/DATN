namespace test.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_Khudexe
    {
        [Key]
        public short PK_iKhuID { get; set; }

        [Required]
        [StringLength(50)]
        public string sTenkhu { get; set; }

        public short FK_iLoaixeID { get; set; }

        public virtual tbl_Loaixe tbl_Loaixe { get; set; }
    }
}
