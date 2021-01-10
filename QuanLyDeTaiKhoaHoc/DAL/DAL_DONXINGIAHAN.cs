using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyDeTaiKhoaHoc.GUI;
using QuanLyDeTaiKhoaHoc.BUS;
using QuanLyDeTaiKhoaHoc.DTO;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace QuanLyDeTaiKhoaHoc.DAL
{
    class DAL_DONXINGIAHAN
    {
        private static DAL_DONXINGIAHAN instance;

        public static DAL_DONXINGIAHAN Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DAL_DONXINGIAHAN();
                }
                return instance;
            }
            set { instance = value; }
        }

        public DataTable LoadListDXGH()
        {
            Form main = Application.OpenForms["frmMain"];

            Dictionary<string, string> param = new Dictionary<string, string>();

            DataTable dt = new DataTable();
            string LoadQuery = "";
            LoadQuery += "SELECT B.maDonXinGiaHan, B.maGiangVien, B.maDeTai,A.maCTDXGH,A.ngayGiaHan, A.ngayHoanThanh,A.linkDonXin FROM CHITIETDONXINGIAHAN A, DONXINGIAHAN B";
            LoadQuery += " WHERE B.maDeTai IN (SELECT maDeTai FROM DETAI WHERE maTrangThai=6) AND A.maCTDXGH = B.maCTDXGH"; // mã trạng thái =6: đề tài ở trạng thái chờ duyệt gia hạn
            dt = HandleDB.Instance.ExecuteQuery(LoadQuery, param);
            return dt;
        }


        public void GiaHanDeTai()
        {
            System.Windows.Forms.Form f = System.Windows.Forms.Application.OpenForms["frmMain"];
            Dictionary<string, string> param = new Dictionary<string, string>();
            string maDonXinGiaHan = ((frmMain)f).tb_maCTDXGH.Text;
            string maGiangVien = ((frmMain)f).tb_maGV4.Text;
            string maCTDXGH = ((frmMain)f).tb_maCTDXGH.Text;
            string maDeTai = ((frmMain)f).tb_maDeTai3.Text;
            string ngayGiaHan = ((frmMain)f).dt_NgayGH.Value.ToString("MM/dd/yyyy");
            string ngayHoanThanh = ((frmMain)f).dt_NgayHoanThanh.Value.ToString("MM/dd/yyyy");
            string linkDonXin = ((frmMain)f).tb_linkDonXin.Text;
            string AddDXGH = String.Empty;
            string AddCTDXGH = String.Empty;
            AddCTDXGH = "INSERT INTO CHITIETDONXINGIAHAN(maCTDXGH, ngayGiaHan, ngayHoanThanh, linkDonXin) VALUES ('" + maCTDXGH + "', '" + ngayGiaHan + "', '" + ngayHoanThanh + "', '" + linkDonXin + "')";
            AddDXGH = "INSERT INTO DONXINGIAHAN(maDonXinGiaHan,maGiangVien,maCTDXGH,maDeTai) VALUES ('" + maDonXinGiaHan + "', '" + maGiangVien + "','" + maCTDXGH + "','" + maDeTai + "' )";

            int result1 = HandleDB.Instance.ExecuteNonQuery(AddCTDXGH, param);
            int result2 = HandleDB.Instance.ExecuteNonQuery(AddDXGH, param);


            if (result1 > 0 && result2 > 0)
            {
                MessageBox.Show("Thêm đơn gia hạn thành công");
            }
            else
            {
                MessageBox.Show("Thêm thất bại");
            }
        }
        public void SetTrangThaiGiaHan()
        {
            System.Windows.Forms.Form f = System.Windows.Forms.Application.OpenForms["frmMain"];
            string DuyetDeTai = "";
            DuyetDeTai += "UPDATE DETAI SET maTrangThai= 6 WHERE maDeTai=@maDeTai"; //mã trạng thái=6: set đề tài ở trạng thái chờ duyệt
            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("@maDeTai", ((frmMain)f).tb_maDeTai3.Text);
            int result = HandleDB.Instance.ExecuteNonQuery(DuyetDeTai, param);
        }

        public void UpdateNgayHoanThanh()
        {
            System.Windows.Forms.Form f = System.Windows.Forms.Application.OpenForms["frmMain"];
            string Update = "";
            Update += "UPDATE DETAI SET ngayHoanThanhDeTai=@ngayHoanThanhDeTai WHERE maDeTai=@maDeTai";
            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("@maDeTai", ((frmMain)f).tb_maDeTai3.Text);
            param.Add("@ngayHoanThanhDeTai", ((frmMain)f).dt_NgayHoanThanh.Value.ToString());
            int result = HandleDB.Instance.ExecuteNonQuery(Update, param);
        }

        public void DuyetGiaHan()
        {
            System.Windows.Forms.Form f = System.Windows.Forms.Application.OpenForms["frmMain"];
            string DuyetDeTai = "";
            DuyetDeTai += "UPDATE DETAI SET maTrangThai= 4 WHERE maDeTai=@maDeTai"; //mã trạng thái=4: đã được duyệt gia hạn
            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("@maDeTai", ((frmMain)f).tb_maDeTai3.Text);
            int result = HandleDB.Instance.ExecuteNonQuery(DuyetDeTai, param);
            if (result > 0)
            {
                MessageBox.Show("Duyệt gia hạn đề tài thành công");
            }
        }
    }
}

