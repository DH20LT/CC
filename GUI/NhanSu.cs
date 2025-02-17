﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChinhChien.DAL_DAO;
using ChinhChien.BUS;


namespace ChinhChien.GUI
{
    public partial class NhanSu : Form
    {
        public string MaQuan;
        NhanVienBUS nvBus;
        public string MaNhanVien;

        public NhanSu()
        {
            InitializeComponent();
            nvBus = new NhanVienBUS();

        }

        private void NhanSu_Load(object sender, EventArgs e)
        {
            RefreshDGV();
            if (dgvNhanVien.SelectedRows[0].Cells[10].Value.ToString() == "")
            {
                btnTaoTK.Text = "Tạo tai khoản";
            }
            else
            {
                btnTaoTK.Text = "Sửa tài khoản";

            }
        }

        public void ibtbRefresh_Click(object sender, EventArgs e)
        {
            RefreshDGV();
        }

        public void RefreshDGV()
        {
            var fMainUI = (ChinhChien.UI.frmMainUI)this.Owner;
            MaQuan = fMainUI.MaQuan;
            
            dgvNhanVien.DataSource
                = nvBus.getNhanVienBUS(MaQuan);
            
            dgvNhanVien.Columns[0].HeaderText = "Mã Nhân Viên";
            //dgvNhanVien.Columns[0].DisplayIndex = 1;
            dgvNhanVien.Columns[0].FillWeight = 60;
            dgvNhanVien.Columns[0].DataPropertyName = "MaNhanVien";

            dgvNhanVien.Columns[1].HeaderText = "Tên Nhân Viên";
            dgvNhanVien.Columns[1].FillWeight = 60;
            //dgvNhanVien.Columns[1].DisplayIndex = 0;
            dgvNhanVien.Columns[1].DataPropertyName = "TenNhanVien";


            dgvNhanVien.Columns[2].HeaderText = "Lương trên giờ";
            dgvNhanVien.Columns[2].FillWeight = 60;
            dgvNhanVien.Columns[2].DataPropertyName = "LuongTrenGio";


            dgvNhanVien.Columns[3].HeaderText = "Ngày vào làm";
            dgvNhanVien.Columns[3].FillWeight = 60;
            dgvNhanVien.Columns[3].DataPropertyName = "NgayVaoLam";


            dgvNhanVien.Columns[4].HeaderText = "Giới tính";
            dgvNhanVien.Columns[4].DataPropertyName = "GioiTinh";


            dgvNhanVien.Columns[5].HeaderText = "Ngày sinh";
            dgvNhanVien.Columns[5].DataPropertyName = "NgaySinh";


            dgvNhanVien.Columns[6].HeaderText = "Số điện thoại";
            dgvNhanVien.Columns[6].DataPropertyName = "SoDienThoai";


            dgvNhanVien.Columns[7].HeaderText = "Địa chỉ";
            dgvNhanVien.Columns[7].DataPropertyName = "DiaChi";


            dgvNhanVien.Columns[8].HeaderText = "Loại nhân viên";
            dgvNhanVien.Columns[8].DataPropertyName = "LoaiNhanVien";

            dgvNhanVien.Columns[9].Visible = false;
            dgvNhanVien.Columns[9].HeaderText = "Mã quán";
            dgvNhanVien.Columns[9].DataPropertyName = "MaQuan";


            dgvNhanVien.Columns[10].HeaderText = "Tên tài khoản";
            dgvNhanVien.Columns[10].DataPropertyName = "TenTaiKhoan";

           

        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            formThem.ThemCapnhatNhanVien ThemCapnhatNhanVien = new formThem.ThemCapnhatNhanVien();
            ThemCapnhatNhanVien.Owner = this;
            ThemCapnhatNhanVien.Show();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            string MaNhanVien = dgvNhanVien.SelectedRows[0].Cells[0].Value.ToString();
            string TenNhanVien = dgvNhanVien.SelectedRows[0].Cells[1].Value.ToString();
            int LuongTrenGio = int.Parse(dgvNhanVien.SelectedRows[0].Cells[2].Value.ToString());
            DateTime NgayVaoLam = DateTime.Parse(dgvNhanVien.SelectedRows[0].Cells[3].Value.ToString());
            string GioiTinh = dgvNhanVien.SelectedRows[0].Cells[4].Value.ToString();
            DateTime NgaySinh = DateTime.Parse(dgvNhanVien.SelectedRows[0].Cells[5].Value.ToString());
            string SoDienThoai = dgvNhanVien.SelectedRows[0].Cells[6].Value.ToString();
            string DiaChi = dgvNhanVien.SelectedRows[0].Cells[7].Value.ToString();
            string LoaiNhanVien = dgvNhanVien.SelectedRows[0].Cells[8].Value.ToString();
            string TaiKhoan = dgvNhanVien.SelectedRows[0].Cells[10].Value.ToString();

            formThem.ThemCapnhatNhanVien ThemCapnhatNhanVien
                = new formThem.ThemCapnhatNhanVien(
                    MaNhanVien, TenNhanVien, LuongTrenGio, NgayVaoLam,
                    GioiTinh, NgaySinh, SoDienThoai, DiaChi, LoaiNhanVien,TaiKhoan
                    );
            ThemCapnhatNhanVien.Owner = this;
            ThemCapnhatNhanVien.Show();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                
                string MaNhanVien = dgvNhanVien.SelectedRows[0].Cells[0].Value.ToString();
                nvBus.XoaNhanVienBUS(MaNhanVien);
                RefreshDGV();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: "+ex.Message);    
                
            }
           

        }

        private void btnTaoTK_Click(object sender, EventArgs e)
        {
            if (dgvNhanVien.SelectedRows[0] == null)
            {
                return;
            }
            string MaNhanVien = dgvNhanVien.SelectedRows[0].Cells[0].Value.ToString();
            if (dgvNhanVien.SelectedRows[0].Cells[10].Value.ToString() == "")
            {

                formThem.frmTaoTaiKhoan f = new formThem.frmTaoTaiKhoan(MaNhanVien);
                f.Owner = this;
                f.Show();
            }
            else
            {
                TaiKhoanBUS tkBus = new TaiKhoanBUS();
                DataTable dt = tkBus.getAccountBUS(dgvNhanVien.SelectedRows[0].Cells[10].Value.ToString());
                string TaiKhoan = dt.Rows[0][0].ToString();
                string MatKhau = dt.Rows[0][1].ToString();
                string Email = dt.Rows[0][3].ToString();
                formThem.frmTaoTaiKhoan f = new formThem.frmTaoTaiKhoan(TaiKhoan,MatKhau,Email,MaNhanVien);
                f.Owner = this;
                f.Show();
            }
           
        }

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            MaNhanVien = dgvNhanVien.SelectedRows[0].Cells[0].Value.ToString();
            if (dgvNhanVien.SelectedRows[0].Cells[10].Value.ToString() == "")
            {
                btnTaoTK.Text = "Tạo tài khoản";
            }
            else
            {
                btnTaoTK.Text = "Sửa tài khoản";

            }
        }
    }
}
