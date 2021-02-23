namespace test.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Configuration;
    using System.Data;
    using System.Data.Entity.Spatial;
    using System.Data.SqlClient;

    public partial class tbl_Xeravao
    {
        [Key]
        public long PK_iXeravaoID { get; set; }

        public long FK_iXeID { get; set; }

        public short FK_iNhanvienID { get; set; }

        public DateTime? dGiovao { get; set; }

        public DateTime? dGiora { get; set; }

        public virtual tbl_Nhanvien tbl_Nhanvien { get; set; }

        public virtual tbl_Ve tbl_Ve { get; set; }

        public virtual tbl_Xe tbl_Xe { get; set; }

        public tbl_Xeravao()
        {

        }

        public tbl_Xeravao(string pK_iXeravaoID, string fK_iXeID, string fK_iNhanvienID, string dGiovao, string dGiora)
        {
            PK_iXeravaoID = Convert.ToInt64(pK_iXeravaoID);
            FK_iXeID = Convert.ToInt64(fK_iXeID);
            FK_iNhanvienID = Convert.ToInt16(fK_iNhanvienID);
            this.dGiovao = Convert.ToDateTime(dGiovao);
            this.dGiora = Convert.ToDateTime(dGiora);
        }

        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Database"].ConnectionString);
         public List<tbl_Xeravao> GetXeravaoByBK(long xeravaoID)
        {
            List<tbl_Xeravao> dsXeravao = new List<tbl_Xeravao>();
            try
            {
                SqlDataReader dar;
                SqlCommand cmd = new SqlCommand("sp_GetXeravaoByPK", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter maxeravao = cmd.Parameters.Add("@xeravaoID", SqlDbType.BigInt);
                maxeravao.Value = xeravaoID;
                conn.Open();
                dar = cmd.ExecuteReader();
                if (dar.HasRows)
                {
                    while (dar.Read())
                    {
                        tbl_Xeravao xeravao = new tbl_Xeravao(
                            dar["PK_iXeravaoID"].ToString(),
                            dar["FK_iXeID"].ToString(),
                            dar["FK_iNhanvienID"].ToString(),
                            dar["dGiovao"].ToString(),
                            dar["dGiora"].ToString()
                        );
                        dsXeravao.Add(xeravao);
                    }

                }
            }
            catch (Exception)
            {

            }
            return dsXeravao;
        }
        /// <summary>
        /// thêm thông tin xe ra vào
        /// </summary>
        /// <param name="xeID"></param>
        /// <param name="veID"></param>
        /// <param name="nhanvienID"></param>
        /// <returns></returns>
        public bool Themxevao (long xeID, short nhanvienID)
        {
            bool ketqua = false;
            try
            {
                SqlCommand cmd = new SqlCommand("sp_ThemXeravao", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@maxe", xeID);
                cmd.Parameters.AddWithValue("@manhanvien", nhanvienID);
                cmd.Parameters.AddWithValue("@giovao", DateTime.Now);
                cmd.Parameters.AddWithValue("@giora", DateTime.Now);
                conn.Open();
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                    ketqua = true;
                else
                    ketqua = false;

                return ketqua;

            }
            catch (Exception ex)
            {
                return ketqua;
            }
        }
        /// <summary>
        /// Sửa thông tin xe ra vào
        /// </summary>
        /// <param name="xeravaoID"></param>
        /// <param name="xeID"></param>
        /// <param name="veID"></param>
        /// <param name="nhanvienID"></param>
        /// <param name="giovao"></param>
        /// <param name="giora"></param>
        /// <returns></returns>
        public bool SuaXeravao (long xeravaoID, long xeID, long veID, short nhanvienID, DateTime giovao, DateTime giora)
        {
            bool ketqua = false;
            try
            {
                SqlCommand cmd = new SqlCommand("sp_SuaXeravao", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@maxeravao", xeravaoID);
                cmd.Parameters.AddWithValue("@maxe", xeID);
                cmd.Parameters.AddWithValue("@manhanvien", nhanvienID);
                cmd.Parameters.AddWithValue("@giovao", giovao);
                cmd.Parameters.AddWithValue("@giora", giora);
                conn.Open();
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                    ketqua = true;
                else
                    ketqua = false;

                return ketqua;

            }
            catch (Exception ex)
            {
                return ketqua;
            }
        }
        /// <summary>
        /// Xóa xe ra vào theo mã xe ra vào
        /// </summary>
        /// <param name="xeravaoID"></param>
        /// <returns></returns>
        public bool XoaXeravao(long xeravaoID)
        {
            bool ketqua = false;
            try
            {
                SqlCommand cmd = new SqlCommand("sp_XoaXeravao", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@maxeravao", xeravaoID);
                conn.Open();
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                    ketqua = true;
                else
                    ketqua = false;

                return ketqua;

            }
            catch (Exception ex)
            {
                return ketqua;
            }
        }
        /// <summary>
        /// lấy thông tin xe ra vào theo mã vé xe
        /// </summary>
        /// <param name="vexeID"></param>
        /// <returns></returns>
        public List<tbl_Xeravao> GetXeravaoByFK_iVeID(long vexeID)
        {
            List<tbl_Xeravao> dsXeravao = new List<tbl_Xeravao>();
            try
            {
                SqlDataReader dar;
                SqlCommand cmd = new SqlCommand("sp_GetXeravaoByFKVeID", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter mavexe = cmd.Parameters.Add("@mave", SqlDbType.BigInt);
                mavexe.Value = vexeID;
                conn.Open();
                dar = cmd.ExecuteReader();
                if (dar.HasRows)
                {
                    while (dar.Read())
                    {
                        tbl_Xeravao xeravao = new tbl_Xeravao(
                            dar["PK_iXeravaoID"].ToString(),
                            dar["FK_iXeID"].ToString(),
                            dar["FK_iNhanvienID"].ToString(),
                            dar["dGiovao"].ToString(),
                            dar["dGiora"].ToString()
                        );
                        dsXeravao.Add(xeravao);
                    }

                }
            }
            catch (Exception)
            {

            }
            return dsXeravao;
        }
        /// <summary>
        /// lấy thông tin xe ra vào theo mã xe
        /// </summary>
        /// <param name="xeID"></param>
        /// <returns></returns>
        public List<tbl_Xeravao> GetXeravaoByFK_iXeID(long xeID)
        {
            List<tbl_Xeravao> dsXeravao = new List<tbl_Xeravao>();
            try
            {
                SqlDataReader dar;
                SqlCommand cmd = new SqlCommand("sp_GetXeravaoByFKXeID", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter maxe = cmd.Parameters.Add("@maxe", SqlDbType.BigInt);
                maxe.Value = xeID;
                conn.Open();
                dar = cmd.ExecuteReader();
                if (dar.HasRows)
                {
                    while (dar.Read())
                    {
                        tbl_Xeravao xeravao = new tbl_Xeravao(
                            dar["PK_iXeravaoID"].ToString(),
                            dar["FK_iXeID"].ToString(),                          
                            dar["FK_iNhanvienID"].ToString(),
                            dar["dGiovao"].ToString(),
                            dar["dGiora"].ToString()
                        );
                        dsXeravao.Add(xeravao);
                    }

                }
            }
            catch (Exception)
            {

            }
            return dsXeravao;
        }



    }
}
