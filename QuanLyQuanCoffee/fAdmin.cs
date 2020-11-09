﻿using QuanLyQuanCoffee.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQuanCoffee
{
    public partial class fAdmin : Form
    {
        public fAdmin()
        {
            InitializeComponent();
        }

        private void fAdmin_Load(object sender, EventArgs e)
        {
            DisplayProductTreeView();
            DisplayListViewAccount();
            DisplayLoaiTK();

        }

        // Gọi hàm khi thay đổi selected tab
        private void tabAdmin_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabAdmin.SelectedTab.Name)
            {
                case "tabProduct":
                    DisplayProductTreeView();
                    break;

            }
        }

                // --------------------Các hàm xử lý tab sản phẩm----------------------
        // Hiển thị tree view loại sản phẩm
        private void DisplayProductTreeView()
        {
            tvProduct.Nodes.Clear();
            DataTable data = LoaiSanPhamDAO.GetLoaiSP();
            TreeNode parentNode = new TreeNode();
            foreach(DataRow row in data.Rows)
            {
                parentNode = tvProduct.Nodes.Add(row["TenLoai"].ToString());
                PopulateTreeView(row["id"].ToString(), parentNode);
            }
        }

        // Hiển thị thông tin các node con thuộc node parent
        private void PopulateTreeView(string idLoaiSP, TreeNode parentNode)
        {
            DataTable data = SanPhamDAO.GetSanPham(idLoaiSP);
            TreeNode childNode;
            foreach(DataRow row in data.Rows)
            {
                if (parentNode == null)
                {
                    childNode = tvProduct.Nodes.Add(row["TenMon"].ToString() + "_" + row["GiaTien"].ToString());
                }
                else
                {
                    childNode = parentNode.Nodes.Add(row["TenMon"].ToString() + "_" + row["GiaTien"].ToString());
                    //gọi lại hàm này nếu có thêm node con
                }
            }
            
        }

        //--------------TAB TAI KHOAN--------------
        void DisplayListViewAccount()
        {
            listAccounts.Items.Clear();
            DataTable dt = AccountDAO.GetTTAccount();
            int sl = dt.Rows.Count;
            //string loaiTK;            
            for (int i = 0; i < sl; i++)
            {
                //if (dt.Rows[i]["LoaiTK"].ToString() == "1")
                //    loaiTK = "Admin";
                //else loaiTK = "Staff";
                listAccounts.Items.Add(dt.Rows[i]["TenNguoiDung"].ToString());
                listAccounts.Items[i].SubItems.Add(dt.Rows[i]["TenHienThi"].ToString());
                listAccounts.Items[i].SubItems.Add(KTLoaiTK(dt.Rows[i]["LoaiTK"].ToString()));
            }
        }
        string KTLoaiTK(string loaitk)
        {
            string loai = "";
            if (loaitk == "1")
                loai = "Admin";
            if (loaitk == "0")
                loai = "Staff";
            return loai;
        }
        void DisplayLoaiTK()
        {
            cbLoaiTK.DataSource = AccountDAO.GetTTAccount();
            cbLoaiTK.DisplayMember = "LoaiTK";
            cbLoaiTK.ValueMember = "LoaiTK";

        }

        private void listAccounts_Click(object sender, EventArgs e)
        {
            tbUserName.Text = listAccounts.SelectedItems[0].SubItems[0].Text;
            tbDisplayName.Text = listAccounts.SelectedItems[0].SubItems[1].Text;
            cbLoaiTK.Text =listAccounts.SelectedItems[0].SubItems[2].Text;
        }
    }
}
