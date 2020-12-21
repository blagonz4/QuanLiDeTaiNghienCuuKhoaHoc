﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyDeTaiKhoaHoc.GUI;
using QuanLyDeTaiKhoaHoc.BUS;
using QuanLyDeTaiKhoaHoc.DTO;
using System.Data;
using System.Data.SqlClient;
using QuanLyDeTaiKhoaHoc.DAL;


namespace QuanLyDeTaiKhoaHoc.GUI
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            dgv_GiangVien.DataSource = BUS_GIANGVIEN.Instance.GetListGV();
            dgv_DeTai.DataSource = BUS_DETAI.Instance.GetListDeTai();
        }

        private void dgv_GiangVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            BUS_GIANGVIEN.Instance.AddGV();
            dgv_GiangVien.DataSource = BUS_GIANGVIEN.Instance.GetListGV();
        }

        private void tb_ThemDT_Click(object sender, EventArgs e)
        {
            BUS_DETAI.Instance.AddDeTai();
        }

        private void dgv_GiangVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                tb_MaGV.Text = dgv_GiangVien.Rows[e.RowIndex].Cells["maGiangVien"].Value.ToString();
                tb_TenGV.Text = dgv_GiangVien.Rows[e.RowIndex].Cells["tenGiangVien"].Value.ToString();
                dt_NgSinh.Text= dgv_GiangVien.Rows[e.RowIndex].Cells["ngaySinh"].Value.ToString();
                tb_HopDong.Text = dgv_GiangVien.Rows[e.RowIndex].Cells["maHopDong"].Value.ToString();
                tb_ChuyenNganh.Text = dgv_GiangVien.Rows[e.RowIndex].Cells["Nganh"].Value.ToString();
            }
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            BUS_GIANGVIEN.Instance.XoaGV();
            dgv_GiangVien.DataSource = BUS_GIANGVIEN.Instance.GetListGV();
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            BUS_GIANGVIEN.Instance.SuaGV();
            dgv_GiangVien.DataSource = BUS_GIANGVIEN.Instance.GetListGV();
        }

        private void btn_XoaDT_Click(object sender, EventArgs e)
        {
            BUS_DETAI.Instance.XoaDeTai();
        }

        private void dgv_DeTai_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                tb_MaDT1.Text = dgv_DeTai.Rows[e.RowIndex].Cells["maDeTai"].Value.ToString();
                tb_TenDT1.Text = dgv_DeTai.Rows[e.RowIndex].Cells["tenDeTai"].Value.ToString();
                tb_LinhVuc1.Text = dgv_DeTai.Rows[e.RowIndex].Cells["linhVuc"].Value.ToString();
                cb_CapDo1.Text = dgv_DeTai.Rows[e.RowIndex].Cells["capDo"].Value.ToString();
                cb_TrangThai3.Text = dgv_DeTai.Rows[e.RowIndex].Cells["maTrangThai"].Value.ToString();
                tb_KetQua1.Text = dgv_DeTai.Rows[e.RowIndex].Cells["ketQua"].Value.ToString();
                tb_MaGV1.Text = dgv_DeTai.Rows[e.RowIndex].Cells["maGiangVien"].Value.ToString();
                dt_NgTH1.Text = dgv_DeTai.Rows[e.RowIndex].Cells["ngayThucHien"].Value.ToString();
                tb_LinkDeTai2.Text = dgv_DeTai.Rows[e.RowIndex].Cells["linkDeTai"].Value.ToString();
            }
        }
    }
}
