﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using QuanLyDeTaiKhoaHoc.GUI;
using System.Windows.Forms;
namespace QuanLyDeTaiKhoaHoc.DAL
{
    class DAL_DETAI
    {
        private static DAL_DETAI instance;
        public static DAL_DETAI Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DAL_DETAI();
                }
                return instance;
            }
            set { instance = value; }
        }
        public DAL_DETAI() { }
        public DataTable LoadListDeTai()
        {
            Form main = Application.OpenForms["frmMain"];

            Dictionary<string, string> param = new Dictionary<string, string>();

            DataTable dt = new DataTable();
            string LoadQuery = "";
            LoadQuery += "SELECT * FROM DETAI WHERE maDeTai NOT IN (SELECT maDeTai FROM DETAI WHERE maTrangThai ='1')";
            dt = HandleDB.Instance.ExecuteQuery(LoadQuery, param);
            return dt;
        }
        /*   public DataTable LoadListDeTaiDK() //LOAD DANH SÁCH ĐỀ TÀI CÓ MÃ GIẢNG VIÊN ĐANG ĐĂNG NHẬP ĐÃ ĐĂNG KÍ
           {
               System.Windows.Forms.Form f = System.Windows.Forms.Application.OpenForms["frmMain"];
               String maGiangVien
               DataTable dt = new DataTable();
               string LoadQuery = "";
               LoadQuery += "SELECE *FROM DETAI WHERE maGiangVien='" + maGiangVien + "'";
               return dt;

           }*/
        public DataTable LoadListDeTaiChoDuyet() // load danh sách đề tài chờ duyệt trong form duyệt đề tài
        {
            Form main = Application.OpenForms["frmMain"];

            Dictionary<string, string> param = new Dictionary<string, string>();

            DataTable dt = new DataTable();
            string LoadQuery = "";
            LoadQuery += "SELECT maDeTai,tenDeTai,linhVuc,capDo,maGiangVien,ngayThucHien,linkDeTai FROM DETAI WHERE maTrangThai='1' "; // mã trạng thái =1: vừa đk chưa được duyệt
            dt = HandleDB.Instance.ExecuteQuery(LoadQuery, param);
            return dt;
        }
        public void AddDeTai()
        {
            System.Windows.Forms.Form f = System.Windows.Forms.Application.OpenForms["frmMain"];
            string AddQuery = "";
            AddQuery += "INSERT INTO DETAI(maDeTai,tenDeTai,ngayThucHien,linhVuc,capDo,maTrangThai,maGiangVien,linkDeTai)";
            AddQuery += "VALUES(@maDeTai,@tenDeTai,@ngayThucHien,@linhVuc,@capDo,'1',@maGiangVien,@linkDeTai)";

            Dictionary<string, string> param = new Dictionary<string, string>();

            param.Add("@maDeTai", ((frmMain)f).tb_MaDT.Text);
            param.Add("@tenDeTai", ((frmMain)f).tb_TenDT.Text);
            param.Add("@ngayThucHien", ((frmMain)f).dt_NgTH1.Value.ToString());
            param.Add("@linhVuc", ((frmMain)f).tb_LinhVuc.Text);
            param.Add("@capDo", ((frmMain)f).cb_CapDo.Text);
            param.Add("@maGiangVien", ((frmMain)f).tb_MaGV2.Text);
            param.Add("@linkDeTai", ((frmMain)f).tb_LinkDeTai1.Text);
            int result = HandleDB.Instance.ExecuteNonQuery(AddQuery, param);
            if (result > 0)
            {
                MessageBox.Show("Thêm đề tài thành công");
            }
        }
        public void XoaDeTai()
        {
            System.Windows.Forms.Form f = System.Windows.Forms.Application.OpenForms["frmMain"];
            string id_xoa = ((frmMain)f).tb_MaDT1.Text;
            string DeleteQuery = "DELETE FROM DETAI WHERE maDeTai ='" + id_xoa + "'";
            int result = HandleDB.Instance.ExecuteNonQuery(DeleteQuery, null);
            if (result > 0)
            {
                MessageBox.Show("Xóa đề tài thành công");
            }
        }
        public void SuaDeTai()
        {
            System.Windows.Forms.Form f = System.Windows.Forms.Application.OpenForms["frmMain"];
            string UpdateQuery = "";
            UpdateQuery += "UPDATE GIANGVIEN SET";
            UpdateQuery += "maDeTai=@maDeTai";
            UpdateQuery += "tenDeTai=@tenDeTai";
            UpdateQuery += "maGiangVien=@maGiangVien";
            UpdateQuery += "linhVuc=@linhVuc";
            UpdateQuery += "capDo=@capDo";
            UpdateQuery += "ketQua=@ketQua";
            UpdateQuery += "maGiangVien=@maGiangVien";
            UpdateQuery += "ngayTH=@ngayTH";
            UpdateQuery += "linkDeTai=@linkDeTai";
            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("@maDeTai", ((frmMain)f).tb_MaDT1.Text);
            param.Add("@tenDeTai", ((frmMain)f).tb_TenDT1.Text);
            param.Add("@ngayTH", ((frmMain)f).dt_NgTH1.Value.ToString());
            param.Add("@linhVuc", ((frmMain)f).tb_LinhVuc1.Text);
            param.Add("@capDo", ((frmMain)f).cb_CapDo1.Text);
            param.Add("@ketQua", ((frmMain)f).tb_KetQua1.Text);
            param.Add("@maTrangThai", ((frmMain)f).cb_TrangThai3.Text);
            param.Add("@maGiangVien", ((frmMain)f).tb_MaGV1.Text);
            param.Add("@linkDeTai", ((frmMain)f).tb_LinkDeTai2.Text);
            int result = HandleDB.Instance.ExecuteNonQuery(UpdateQuery, param);
            if (result > 0)
            {
                MessageBox.Show("Sửa đề tài thành công");
            }
        }
        public void DuyetDeTai()
        {
            System.Windows.Forms.Form f = System.Windows.Forms.Application.OpenForms["frmMain"];
            string DuyetDeTai = "";
            DuyetDeTai += "UPDATE DETAI SET maTrangThai='2' WHERE maDeTai=@maDeTai";
            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("@maDeTai", ((frmMain)f).tb_MaDT2.Text);
            int result = HandleDB.Instance.ExecuteNonQuery(DuyetDeTai, param);
            if (result > 0)
            {
                MessageBox.Show("Duyệt đề tài thành công");
            }
        }
        public int GetNextID()
        {
            int nextID = 1;

            string Query = String.Empty;
            Query += "SELECT TOP 1 maDeTai FROM DETAI ";
            Query += "ORDER BY maDeTai DESC";

            DataTable dt = HandleDB.Instance.ExecuteQuery(Query, null);
            if (dt.Rows.Count > 0)
            {
                Int32.TryParse(dt.Rows[0]["maDeTai"].ToString(), out nextID);
                ++nextID;
            }
            return nextID;
        }
    }
}
