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
    public class Chitietve : tbl_Xe
    {
        string format = "dd-MM-yyyy";
        string tenLoaixe;
        string mavexe;

        public Chitietve(string pK_iXeID, string sBiensoxe, string fK_iLoaixeID, string sAnhxe, string fk_iVeID, string mave, string mavexe, string ngaydangky, string trangthai, string ngayhethan, string maloaixe, string tenLoaixe)
        {
            PK_iXeID = Convert.ToInt64(pK_iXeID);
            this.sBiensoxe = sBiensoxe;
            FK_iLoaixeID = Convert.ToInt16(fK_iLoaixeID);
            this.sAnhxe = sAnhxe;
            FK_iVeID = Convert.ToInt64(fk_iVeID);
            this.PK_iVeID = Convert.ToInt64(mave);
            this.sMave = mavexe;
            this.tNgaytao = Convert.ToDateTime(ngaydangky);           
            this.bTrangthai = Convert.ToBoolean(trangthai);
            this.tNgayhethan = Convert.ToDateTime(ngayhethan);
            this.PK_iLoaixeID = Convert.ToInt16(maloaixe);          
            this.sTenLoaixe = tenLoaixe;

        }
        public Chitietve() { }

        public string sTenLoaixe { get => tenLoaixe; set => tenLoaixe = value; }
        public string sMave { get => mavexe; set => mavexe = value; }
        public DateTime tNgaytao { get; set; }
        public DateTime tNgayhethan { get; set; }
        public bool bTrangthai { get; set; }
        public long PK_iVeID { get; set; }
        public short PK_iLoaixeID { get; set; }

        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Database"].ConnectionString);

        public List<Chitietve> GetChitietVeByVexeID(long vexeID)
        {
          
            List<Chitietve> dschitietve = new List<Chitietve>();
            if (vexeID > 0)
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
                                dar["PK_iVeID"].ToString(),
                                 dar["sMave"].ToString(),
                                dar["tNgaytao"].ToString(),
                                dar["bTrangthai"].ToString(),
                               dar["tNgayhethan"].ToString(),
                                 dar["PK_iLoaixeID"].ToString(),
                                dar["sTenLoaixe"].ToString()
                            );
                            dschitietve.Add(ctve);
                        }

                    }
                }
                catch (Exception ex)
                {
                    throw new ApplicationException("error" + ex);
                }
            }
            return dschitietve;
        }
    }
}