using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace test.Models.obj
{
    public class Doanhthuthang
    {
        int soluong;
        decimal dongia;
        string loaixe;
        string loaive;

        public int Soluong { get => soluong; set => soluong = value; }
        public decimal mGia { get => dongia; set => dongia = value; }
        public string sTenLoaixe { get => loaixe; set => loaixe = value; }
        public string sTenloaive { get => loaive; set => loaive = value; }
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Database"].ConnectionString);


        public Doanhthuthang()
        {

        }
        public Doanhthuthang(int soluong, decimal dongia, string loaixe, string loaive)
        {
            this.soluong = soluong;
            this.dongia = dongia;
            this.loaixe = loaixe;
            this.loaive = loaive;
        }
        public List<Doanhthuthang> GetDoanhthuByLoaivethang(DateTime ngaybatdau, DateTime ngayketthuc, byte loaiveID)
        {
            List<Doanhthuthang> dsDoanhthu = new List<Doanhthuthang>();
            SqlCommand cmd;
            SqlDataReader dar;
            cmd = new SqlCommand("sp_GetLoaiveByPK", conn);
            cmd.Parameters.AddWithValue("@loaiveID", loaiveID);
            cmd.CommandType = CommandType.StoredProcedure;
            conn.Open();
            dar = cmd.ExecuteReader();
            if (dar.HasRows)
            {
                //while (dar.Read())
                //{
                //    tbl_Loaive loaive = new tbl_Loaive(
                //        dar["PK_iLoaiveID"].ToString(),
                //    dar["sTenloaive"].ToString()
                //        );
                //    danhsachLoaive.Add(loaive);
                //}
            }
            return dsDoanhthu;
        }
        public List<Doanhthuthang> GetDoanhthuByLoaivengay(DateTime ngaybatdau, DateTime ngayketthuc, byte loaiveID)
        {
            List<Doanhthuthang> dsDoanhthu = new List<Doanhthuthang>();
            SqlCommand cmd;
            SqlDataReader dar;
            cmd = new SqlCommand("sp_GetLoaiveByPK", conn);
            cmd.Parameters.AddWithValue("@loaiveID", loaiveID);
            cmd.CommandType = CommandType.StoredProcedure;
            conn.Open();
            dar = cmd.ExecuteReader();
            if (dar.HasRows)
            {
                //while (dar.Read())
                //{
                //    tbl_Loaive loaive = new tbl_Loaive(
                //        dar["PK_iLoaiveID"].ToString(),
                //    dar["sTenloaive"].ToString()
                //        );
                //    danhsachLoaive.Add(loaive);
                //}
            }
            return dsDoanhthu;
        }
    }
} 