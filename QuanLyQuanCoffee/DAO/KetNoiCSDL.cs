﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQuanCoffee.DAO
{
    class KetNoiCSDL
    {
        private static SqlConnection cn = new SqlConnection();

        public static object Instance { get; internal set; }

        private static void MoKetNoi()
        {
            string sqlcon = @"Data Source=YEN_PC;Initial Catalog=QLCoffee;Integrated Security=True";
            cn.ConnectionString = sqlcon;
            if (cn.State == System.Data.ConnectionState.Closed)
                cn.Open();
        }
        private static void DongKetNoi()
        {
            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();
        }

        public static DataTable Query(string sql)
        {
            MoKetNoi();
            SqlCommand cd = new SqlCommand(sql, cn);
            SqlDataReader dr = cd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            DongKetNoi();
            return dt;
        }
        public static void NonQuery(string sql)
        {
            MoKetNoi();
            SqlCommand cmd = new SqlCommand(sql, cn);
            cmd.ExecuteNonQuery();
            DongKetNoi();
        }

    }
}