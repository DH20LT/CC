﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChinhChien.FormsChuQuan
{
    public partial class FormKhoHang : Form
    {
        public FormKhoHang()
        {
            InitializeComponent();
        }

        private void FormKhoHang_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'quanLyQuanTraSuaDataSet.VatLieu' table. You can move, or remove it, as needed.
            this.vatLieuTableAdapter.Fill(this.quanLyQuanTraSuaDataSet.VatLieu);
            // TODO: This line of code loads data into the 'khoHangDataSet.KhoHang' table. You can move, or remove it, as needed.
        }
    }
}
