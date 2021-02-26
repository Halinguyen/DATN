using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace test.Models.obj
{
    public class CtGiave
    {
        private short pK_iGiaveID;
        private DateTime ngaybatdauApdung;
        private Decimal gia;
        private string tenloaive;
        private string tenloaixe;
        private string giobatdau;
        private string giohet;

        public CtGiave() { }

        public CtGiave(string pK_iGiaveID, string ngaybatdauApdung, string gia, string tenloaive, string tenloaixe, string giobatdau, string giohet)
        {
            this.PK_iGiaveID =Convert.ToInt16(pK_iGiaveID);
            this.dNgaybatdauApdung = Convert.ToDateTime(ngaybatdauApdung);
            this.mGia = Convert.ToDecimal(gia);
            this.sTenloaive = tenloaive;
            this.sTenLoaixe = tenloaixe;
            this.dGiobatdau = giobatdau;
            this.dGiohet = giohet;
        }

        public short PK_iGiaveID { get => pK_iGiaveID; set => pK_iGiaveID = value; }
        public DateTime dNgaybatdauApdung { get => ngaybatdauApdung; set => ngaybatdauApdung = value; }
        public decimal mGia { get => gia; set => gia = value; }
        public string sTenloaive { get => tenloaive; set => tenloaive = value; }
        public string sTenLoaixe { get => tenloaixe; set => tenloaixe = value; }
        public string dGiobatdau { get => giobatdau; set => giobatdau = value; }
        public string dGiohet { get => giohet; set => giohet = value; }
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Database"].ConnectionString);
        public List<CtGiave> GetChitietGiave()
        {
            List<CtGiave> dsgiave = new List<CtGiave>();
            SqlDataReader dar;
            SqlCommand cmd = new SqlCommand("sp_GetGiavexe", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            conn.Open();
            dar = cmd.ExecuteReader();
            if (dar.HasRows)
            {
                while (dar.Read())
                {
                    CtGiave ctv = new CtGiave(
                        dar["PK_iGiaveID"].ToString(),
                        dar["dNgaybatdauApdung"].ToString(),
                        dar["mGia"].ToString(),
                        dar["sTenloaive"].ToString(),
                        dar["sTenLoaixe"].ToString(),
                        dar["dGiobatdau"].ToString(),
                        dar["dGiohet"].ToString()
                    );
                    dsgiave.Add(ctv);
                }
            }
            return dsgiave;
        }

    }
}