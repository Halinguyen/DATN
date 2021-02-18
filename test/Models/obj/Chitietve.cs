using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using test.Models;

namespace test.Models.obj
{
    public class Chitietve:tbl_Xe
    {
        string tenLoaixe;
        string mavexe;

        public Chitietve(string pK_iXeID, string sBiensoxe, string fK_iLoaixeID, string sAnhxe, string fk_iVeID, string tenLoaixe,string mavexe)
        {
            PK_iXeID = Convert.ToInt64(pK_iXeID);
            this.sBiensoxe = sBiensoxe;
            FK_iLoaixeID = Convert.ToInt16(fK_iLoaixeID);
            this.sAnhxe = sAnhxe;
            FK_iVeID = Convert.ToInt64(fk_iVeID);
            this.TenLoaixe = tenLoaixe;
            this.Mavexe = mavexe;
        }
        public Chitietve() { }

        public string TenLoaixe { get => tenLoaixe; set => tenLoaixe = value; }
        public string Mavexe { get => mavexe; set => mavexe = value; }

        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Database"].ConnectionString);

        public List<Chitietve> GetChitietVeByVexeID (long vexeID)
        {
            List<Chitietve> dschitietve = new List<Chitietve>();
            if(vexeID > 0)
            {
                try
                {
                    SqlDataReader dar;
                    SqlCommand cmd = new SqlCommand("sp_GetChitietve", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter mavexe = cmd.Parameters.Add("@vexeID", SqlDbType.BigInt);
                    mavexe.Value = vexeID;
                    conn.Open();
                    dar = cmd.ExecuteReader();
                    if (dar.HasRows)
                    {
                        while (dar.Read())
                        {
                            Chitietve ctve = new Chitietve(
                                dar["PK_iXeID"].ToString(),
                                dar["sBiensoxe"].ToString(),
                                dar["FK_iLoaixeID"].ToString(),
                                dar["sAnhxe"].ToString(),
                                dar["FK_iVeID"].ToString(),
                                dar["TenLoaixe"].ToString(),
                                dar["Mavexe"].ToString()
                            );
                            dschitietve.Add(ctve);
                        }

                    }
                }
                catch (Exception)
                {

                }
            }
            return dschitietve;
        }
    }
}