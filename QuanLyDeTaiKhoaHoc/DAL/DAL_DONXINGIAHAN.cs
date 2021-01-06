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
            LoadQuery += "SELECT maDonXinGiaHan,maGiangVien,maCTDXGH,maDeTai,ngayHoanThanh,ngayGiaHan FROM DONXINGIAHAN WHERE maDeTai IN";
            LoadQuery += "(SELECT maDeTai FROM DETAI WHERE maTrangThai=6)"; // mã trạng thái =6: đề tài ở trạng thái chờ duyệt gia hạn
            // cần bổ sung link đề tài
            dt = HandleDB.Instance.ExecuteQuery(LoadQuery, param);
            return dt;
        }


        public void GiaHanDeTai()
        {
            System.Windows.Forms.Form f = System.Windows.Forms.Application.OpenForms["frmMain"];
            string AddQuery = "";
            AddQuery += "INSERT INTO DONXINGIAHAN(maDonXinGiaHan,maGiangVien,maDeTai,ngayHoanThanh,ngayGiaHan)"; // thiếu link, thiếu mã CTDXGH
            AddQuery += "VALUES(@maDonXinGiaHan,@maGiangVien,@maDeTai,@ngayHoanThanh,@ngayGiaHan)";

            Dictionary<string, string> param = new Dictionary<string, string>();

            param.Add("@maDonXinGiaHan", ((frmMain)f).tb_maDXGH.Text);
            param.Add("@maGiangVien", ((frmMain)f).tb_maGV4.Text);
            //param.Add("@maCTDXGH", ((frmMain)f).dt_NgayTH.Value.ToString());
            param.Add("@maDeTai", ((frmMain)f).tb_maDeTai3.Text);
            param.Add("@ngayHoanThanh", ((frmMain)f).dt_NgayHoanThanh.Value.ToString());
            param.Add("@ngayGiaHan", ((frmMain)f).dt_NgayGH.Value.ToString());
            int result = HandleDB.Instance.ExecuteNonQuery(AddQuery, param);
            if (result > 0)
            {
                MessageBox.Show("Đăng kí gia hạn đề tài thành công");
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

