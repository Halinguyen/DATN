using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace test.Models.obj
{
    public class Doanhthuthang
    {
        int soluong;
        decimal dongia;
        string loaixe;

        public int Soluong { get => soluong; set => soluong = value; }
        public decimal Dongia { get => dongia; set => dongia = value; }
        public string Loaixe { get => loaixe; set => loaixe = value; }
    }
}