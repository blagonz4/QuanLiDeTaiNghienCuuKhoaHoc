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
            UpdateQuery += "UPDATE DETAI SET ";
            UpdateQuery += "tenDeTai=@tenDeTai,";
            UpdateQuery += "maGiangVien=@maGiangVien,";
            UpdateQuery += "linhVuc=@linhVuc,";
            UpdateQuery += "capDo=@capDo,";
            UpdateQuery += "ketQua=@ketQua,";
            UpdateQuery += "ngayThucHien=@ngayTH,";
            UpdateQuery += "linkDeTai=@linkDeTai";
            UpdateQuery += " WHERE maDeTai=@maDeTai";
            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("@maDeTai", ((frmMain)f).tb_MaDT1.Text);
            param.Add("@tenDeTai", ((frmMain)f).tb_TenDT1.Text);
            param.Add("@ngayTH", ((frmMain)f).dt_NgTH1.Value.ToString());
            param.Add("@linhVuc", ((frmMain)f).tb_LinhVuc1.Text);
            param.Add("@capDo", ((frmMain)f).cb_CapDo1.Text);
            param.Add("@ketQua", ((frmMain)f).tb_KetQua1.Text);
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


        public void Updateketqua(string ketQua)
        {
            System.Windows.Forms.Form f = System.Windows.Forms.Application.OpenForms["frmMain"];
            string UpdateQuery = "";
            UpdateQuery += "UPDATE DETAI SET ";
            UpdateQuery += "ketQua=@ketQua ";
            UpdateQuery += "WHERE maDeTai = @maDeTai ";

            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("@ketQua", ketQua);
            param.Add("@maDeTai", ((frmMain)f).tb_MaDT5.Text);

            int result = HandleDB.Instance.ExecuteNonQuery(UpdateQuery, param);
            if (result > 0)
            {
                MessageBox.Show("Cập nhật kết quả đề tài thành công");
            }
        }
        public void AddHoiDong()
        {
            System.Windows.Forms.Form f = System.Windows.Forms.Application.OpenForms["frmMain"];
            string UpdateQuery = "";
            UpdateQuery += "UPDATE DETAI SET ";
            UpdateQuery += "maHoiDong=@maHoiDong ";
            UpdateQuery += "WHERE maDeTai = @maDeTai ";

            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("@maHoiDong", ((frmMain)f).tb_MaHoiDongPhanCong.Text);
            param.Add("@maDeTai", ((frmMain)f).tb_MaDeTaiPhanCong.Text);
            int result = HandleDB.Instance.ExecuteNonQuery(UpdateQuery, param);
            if (result > 0)
            {
                MessageBox.Show("Phân công hội đồng phản biện đề tài thành công");
            }
        }
        public DataTable LoadListPhanCong()
        {
            Form main = Application.OpenForms["frmMain"];

            Dictionary<string, string> param = new Dictionary<string, string>();

            DataTable dt = new DataTable();
            string LoadQuery = "";
            LoadQuery += "SELECT A.maHoiDong, B.maDeTai, A.ngayNghiemThu FROM DETAI B, HOIDONGNGHIEMTHU A WHERE B.maHoiDong = A.maHoiDong ";
            dt = HandleDB.Instance.ExecuteQuery(LoadQuery, param);
            return dt;
        }
        public bool GetError()
        {
            System.Windows.Forms.Form f = System.Windows.Forms.Application.OpenForms["frmMain"];
            Dictionary<string, string> param = new Dictionary<string, string>();
            DataTable dt = new DataTable();

            string LoadQuery = "SELECT A.tenGiangVien FROM GIANGVIEN A, DETAI B, HOIDONGNGHIEMTHU C " +
                "WHERE A.maGiangVien = B.maGiangVien AND B.maHoiDong = C.maHoiDong AND B.maDeTai = @maDeTai AND " +
                "((A.tenGiangVien IN (SELECT chuTichHoiDong FROM HOIDONGNGHIEMTHU WHERE maHoiDong = @maHoiDong)) OR (A.tenGiangVien IN (SELECT phanBien1 FROM HOIDONGNGHIEMTHU WHERE maHoiDong = @maHoiDong)) " +
                "OR (A.tenGiangVien IN (SELECT phanBien2 FROM HOIDONGNGHIEMTHU WHERE maHoiDong = @maHoiDong)) OR (A.tenGiangVien IN (SELECT thuKi FROM HOIDONGNGHIEMTHU WHERE maHoiDong = @maHoiDong)))";
            param.Add("@maDeTai", ((frmMain)f).tb_MaDeTaiPhanCong.Text);
            param.Add("@maHoiDong", ((frmMain)f).tb_MaHoiDongPhanCong.Text);
            dt = HandleDB.Instance.ExecuteQuery(LoadQuery, param);
            if (dt != null)
            {
                if(dt.Rows.Count > 0)
                {
                    MessageBox.Show("Thành viên hội đồng là chủ nhiệm đề tài");
                    return false;
                }
                else
                    return true;
            }
            return false;
        }
        public DataTable BaoCaoNamKhoa()
        {
            System.Windows.Forms.Form f = System.Windows.Forms.Application.OpenForms["frmMain"];

            Dictionary<string, string> param = new Dictionary<string, string>();

            DataTable dt = new DataTable();
            string LoadQuery = "";
            LoadQuery += "SELECT A.maDeTai as 'Mã đề tài', A.tenDeTai as 'Tên đề tài' from DETAI A, GIANGVIEN B WHERE A.maGiangVien = B.maGiangVien and " +
                "B.maKhoa = @maKhoa and Year(A.ngayThucHien) = @nam ";
            param.Add("@maKhoa", ((frmMain)f).cb_Khoabc.SelectedValue.ToString());
            param.Add("@nam", ((frmMain)f).tb_Nambc.Text);
            dt = HandleDB.Instance.ExecuteQuery(LoadQuery, param);
            return dt;
        }

        public DataTable BaoCaoLoai()
        {
            System.Windows.Forms.Form f = System.Windows.Forms.Application.OpenForms["frmMain"];

            Dictionary<string, string> param = new Dictionary<string, string>();

            DataTable dt = new DataTable();
            string LoadQuery = "";
            LoadQuery += "SELECT maDeTai as 'Mã đề tài', tenDeTai as 'Tên đề tài' from DETAI WHERE ketQua = @ketQua ";
            param.Add("@ketQua", ((frmMain)f).cb_KetQuabc.Text);
            dt = HandleDB.Instance.ExecuteQuery(LoadQuery, param);
            return dt;
        }
        
        public DataTable BaoCaoTinhTrang()
        {
            System.Windows.Forms.Form f = System.Windows.Forms.Application.OpenForms["frmMain"];

            Dictionary<string, string> param = new Dictionary<string, string>();

            DataTable dt = new DataTable();
            string LoadQuery = "";
            LoadQuery += "SELECT maDeTai as 'Mã đề tài', tenDeTai as 'Tên đề tài' from DETAI WHERE maTrangThai = @maTrangThai ";
            param.Add("@maTrangThai", ((frmMain)f).cb_TinhTrangbc.SelectedValue.ToString());
            dt = HandleDB.Instance.ExecuteQuery(LoadQuery, param);
            return dt;
        }
        public DataTable BaoCaoLinhVuc()
        {
            System.Windows.Forms.Form f = System.Windows.Forms.Application.OpenForms["frmMain"];

            Dictionary<string, string> param = new Dictionary<string, string>();

            DataTable dt = new DataTable();
            string LoadQuery = "";
            LoadQuery += "SELECT maDeTai as 'Mã đề tài', tenDeTai as 'Tên đề tài' from DETAI WHERE linhVuc = @linhVuc ";
            param.Add("@linhVuc", ((frmMain)f).tb_Linhvucbc.Text);
            dt = HandleDB.Instance.ExecuteQuery(LoadQuery, param);
            return dt;
        }
        public DataTable BaoCaoGiangVienThucHienDeTai()
        {
            System.Windows.Forms.Form f = System.Windows.Forms.Application.OpenForms["frmMain"];

            Dictionary<string, string> param = new Dictionary<string, string>();

            DataTable dt = new DataTable();
            string LoadQuery = "";
            LoadQuery += "SELECT A.maGiangVien, A.tenGiangVien, B.maDeTai, B.tenDeTai FROM GIANGVIEN A, DETAI B WHERE A.maGiangVien = B.maGiangVien AND A.tenGiangVien = @tenGiangVien";
            param.Add("@tenGiangVien", ((frmMain)f).tb_TenGVbc.Text);
            dt = HandleDB.Instance.ExecuteQuery(LoadQuery, param);
            return dt;
        }
        public DataTable BaoCaoChiTiet()
        {
            System.Windows.Forms.Form f = System.Windows.Forms.Application.OpenForms["frmMain"];

            Dictionary<string, string> param = new Dictionary<string, string>();

            DataTable dt = new DataTable();
            string LoadQuery = "SELECT maDeTai as 'Mã đề tài', tenDeTai as 'Tên đề tài', ngayThucHien as 'Ngày thực hiện', linhVuc as 'Lĩnh vực', capDo as 'Cấp độ', ketQua as 'Kết quả', " +
                "linkDeTai as 'Link đề tài', maTrangThai as 'Mã trạng thái', maHoiDong as 'Mã hội đồng' from DETAI WHERE maDeTai = @maDeTai";
            param.Add("@maDeTai", ((frmMain)f).tb_MaDTbc.Text);
            dt = HandleDB.Instance.ExecuteQuery(LoadQuery, param);
            return dt;
        }
    }
}
