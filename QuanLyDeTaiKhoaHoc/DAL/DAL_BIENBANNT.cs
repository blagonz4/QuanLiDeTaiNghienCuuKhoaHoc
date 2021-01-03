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
    class DAL_BIENBANNT
    {
        private static DAL_BIENBANNT instance;

        public static DAL_BIENBANNT Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DAL_BIENBANNT();
                }
                return instance;
            }
            set { instance = value; }
        }


        public DataTable LoadListBBNT()
        {
            Form main = Application.OpenForms["frmMain"];

            Dictionary<string, string> param = new Dictionary<string, string>();

            DataTable dt = new DataTable();
            string LoadQuery = "";
            LoadQuery += "SELECT maBienBan, BIENBANNGHIEMTHU.maHoiDong, tongDiem, nhanXet, ngayNghiemThu as 'Ngày nghiệm thu' FROM BIENBANNGHIEMTHU, HOIDONGNGHIEMTHU " +
                " WHERE BIENBANNGHIEMTHU.maHoiDong = HOIDONGNGHIEMTHU.maHoiDong ";
            dt = HandleDB.Instance.ExecuteQuery(LoadQuery, param);
            return dt;
        }


        public void Add()
        {
            Form main = Application.OpenForms["frmMain"];

            Dictionary<string, string> param = new Dictionary<string, string>();

            DataTable dt = new DataTable();

           // string MaBB = ((frmMain)main).tb_MaBB.Text.ToString();
            string MaHoiDong = ((frmMain)main).tb_MaHD1.Text.ToString();
            string tongdiem = ((frmMain)main).tb_TongDiem.Text.ToString();
            string nhanxet = ((frmMain)main).tb_NhanXet.Text.ToString();
          


            string AddQuery = String.Empty;

            AddQuery = "INSERT INTO BIENBANNGHIEMTHU (maHoiDong,tongDiem,nhanXet) values ('" + MaHoiDong + "','" + tongdiem + "', '" + nhanxet + "')";

            int result = HandleDB.Instance.ExecuteNonQuery(AddQuery, param);

            if (result > 0)
            {
                MessageBox.Show(" Thêm biên bản thành công ");
            }
            else
            {
                MessageBox.Show("Thêm biên bản thất bại");
            }
        }



    }
}
