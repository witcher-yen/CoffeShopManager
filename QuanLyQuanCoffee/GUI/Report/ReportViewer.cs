﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQuanCoffee.GUI.Report
{
    public partial class ReportViewer : Form
    {
        private MenuBill menuBill;
        private DoanhThuReport doanhThu;

        public ReportViewer()
        {
            InitializeComponent();
        }

        public ReportViewer(MenuBill menuBill)
        {
            InitializeComponent();
            this.menuBill = menuBill;
            MessageBox.Show("Đang xuất bill");
        }

        public ReportViewer(DoanhThuReport doanhThu, int demo)
        {
            InitializeComponent();
            this.doanhThu = doanhThu;
            MessageBox.Show("Đang xuất báo cáo doanh thu");
        }

        private void ReportViewer_Load(object sender, EventArgs e)
        {
            if(menuBill != null)
                crystalReportViewer1.ReportSource = menuBill;
            if (doanhThu != null)
                crystalReportViewer1.ReportSource = doanhThu;
            //DataTable dt = new DataTable();
            //dt = DAO.MenuDAO.GetDataReport("1");
            //MenuBill reportData = new MenuBill();
            //reportData.SetDataSource(dt);
            //crystalReportViewer1.ReportSource = reportData;

        }
    }
}
