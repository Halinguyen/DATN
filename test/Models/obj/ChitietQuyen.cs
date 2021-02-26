using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace test.Models.obj
{
    public class ChitietQuyen
    {
        string shoten, susername, stenquyen;
        DateTime dngaybatdau, dngayhethan;
        short pk_iNhomquyenID, pk_iQuyenID;

        public string sHoten { get => shoten; set => shoten = value; }
        public string sUsername { get => susername; set => susername = value; }
        public string sTenquyen { get => stenquyen; set => stenquyen = value; }
        public DateTime dNgaybatdau { get => dngaybatdau; set => dngaybatdau = value; }
        public DateTime dNgayhethan { get => dngayhethan; set => dngayhethan = value; }
        public short PK_iNhomquyenID { get => pk_iNhomquyenID; set => pk_iNhomquyenID = value; }
        public short PK_iQuyenID { get => pk_iQuyenID; set => pk_iQuyenID = value; }

        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Database"].ConnectionString);
        public ChitietQuyen() { }

        public ChitietQuyen(string shoten, string susername, string stenquyen, string dngaybatdau, string dngayhethan, string pk_iNhomquyenID, string pk_iQuyenID)
        {
            this.shoten = shoten;
            this.susername = susername;
            this.stenquyen = stenquyen;
            this.dngaybatdau =Convert.ToDateTime(dngaybatdau);
            this.dngayhethan =Convert.ToDateTime(dngayhethan);
            this.pk_iNhomquyenID = Convert.ToInt16(pk_iNhomquyenID);
            this.pk_iQuyenID = Convert.ToInt16(pk_iQuyenID);
        }


        public List<ChitietQuyen> XemChitietQuyen()
        {           
            List<ChitietQuyen> dsctquyen = new List<ChitietQuyen>();
            SqlDataReader dar;
            SqlCommand cmd = new SqlCommand("sp_Xemphanquyen", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            conn.Open();
            dar = cmd.ExecuteReader();
            if (dar.HasRows)
            {
                while (dar.Read())
                {
                    ChitietQuyen ctq = new ChitietQuyen(
                        dar["sHoten"].ToString(),
                        dar["sUsername"].ToString(),
                        dar["sTenquyen"].ToString(),
                        dar["dNgaybatdau"].ToString(),
                        dar["dNgayhethan"].ToString(),
                        dar["PK_iNhomquyenID"].ToString(),
                        dar["PK_iQuyenID"].ToString()
                    );
                    dsctquyen.Add(ctq);
                }
            }
            return dsctquyen;
        }
    }
}