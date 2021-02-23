using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace test.Models.obj
{
    public class Chitietxe : tbl_Xe
    {
        private string stenloaixe, sanhxe, sbiensoxe, smave, shoten;
        private DateTime tngaytao;
        private long pk_iXeID;
        public Chitietxe()
        {

        }
        public Chitietxe(string vexeID, string biensoxe, string hinhanh, string mavexe, string ngaydangky, string loaixe, string tenkhachhang)
        {

            this.PK_iXeID = Convert.ToInt64(vexeID);
            this.sBiensoxe = biensoxe;
            this.sAnhxe = hinhanh;
            this.sMave = mavexe;
            this.tNgaytao = Convert.ToDateTime(ngaydangky);
            this.sTenLoaixe = loaixe;
            this.sHoten = tenkhachhang;

        }

        public string sTenLoaixe { get => stenloaixe; set => stenloaixe = value; }
        public string sAnhxe { get => sanhxe; set => sanhxe = value; }
        public string sBiensoxe { get => sbiensoxe; set => sbiensoxe = value; }
        public string sMave { get => smave; set => smave = value; }
        public string sHoten { get => shoten; set => shoten = value; }
        public DateTime tNgaytao { get => tngaytao; set => tngaytao = value; }
        public long PK_iXeID { get => pk_iXeID; set => pk_iXeID = value; }

        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Database"].ConnectionString);

        public List<Chitietxe> XemChitietXe()
        {
            List<Chitietxe> dsctxe = new List<Chitietxe>();
            try
            {
                SqlDataReader dar;
                SqlCommand cmd = new SqlCommand("sp_XemChitietXe", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();
                dar = cmd.ExecuteReader();
                if (dar.HasRows)
                {
                    while (dar.Read())
                    {
                        Chitietxe ctxe = new Chitietxe(

                            dar["PK_iXeID"].ToString(),
                            dar["sBiensoxe"].ToString(),
                            dar["sAnhxe"].ToString(),
                            dar["sMave"].ToString(),
                            dar["tNgaytao"].ToString(),
                            dar["sTenLoaixe"].ToString(),
                            dar["sHoten"].ToString()

                        );
                        dsctxe.Add(ctxe);
                    }

                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("error" + ex);
            }
            return dsctxe;
        }

    }
}