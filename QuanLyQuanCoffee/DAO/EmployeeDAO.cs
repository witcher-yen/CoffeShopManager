﻿using QuanLyQuanCoffee.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCoffee.DAO
{
    class EmployeeDAO
    {
        // Hàm lấy thông tin danh sách nhân viên
        public static DataTable GetEmployeeList()
        {
            string sql = "select nv.id, TenNhanVien, TenChucVu from NHANVIEN nv, CHUCVU cv where cv.id= nv.idChucVu";
            return KetNoiCSDL.Query(sql);
        }

        // Hàm lấy thông tin chi tiết nhân viên
        public static Employee GetEmployee(string id)
        {
            string sql = "select * from NHANVIEN where id = '" + id + "'";           
            DataTable data = KetNoiCSDL.Query(sql);
            DataRow row = data.Rows[0];
            Employee currentEmployee = new Employee(row);
            return currentEmployee;
        }

        public static DataTable GetChucVU()
        {
            string sql = "select * from CHUCVU ";
            return KetNoiCSDL.Query(sql);
        }

        //Thêm-xóa-sửa
        public static void ThemNhanVien(Employee emp)
        {
            string sql = "Insert into NHANVIEN(TenNhanVien, NgaySinh, DiaChi, Sdt, TenTaiKhoan, idChucVu)values (N'"+emp.TenNhanVien+"', '"+String.Format("{0:MM/dd/yyyy}",emp.NgaySinh)+"', N'"+emp.DiaChi+"', '"+emp.Sdt+"', '"+emp.TenTaiKhoan+"', '"+emp.IdChucVu+"')  ";
            KetNoiCSDL.NonQuery(sql);
        }

        public static void SuaNhanVien(Employee emp)
        {
            string sql = "Update NHANVIEN set TenNhanVien= N'"+emp.TenNhanVien+"' ,NgaySinh='"+String.Format("{0:MM/dd/yyyy}",emp.NgaySinh)+"', DiaChi=N'"+emp.DiaChi+"', Sdt='"+emp.Sdt+"',  TenTaiKhoan='"+emp.TenTaiKhoan+"', idChucVu='"+emp.IdChucVu+"' where id ='"+emp.Id+"'";
            KetNoiCSDL.NonQuery(sql);
        }

        public static void XoaNhanVien(int id)
        {
            string sql = "Delete from NHANVIEN where id='" + id + "' ";
            KetNoiCSDL.NonQuery(sql);
        }


    }
}
