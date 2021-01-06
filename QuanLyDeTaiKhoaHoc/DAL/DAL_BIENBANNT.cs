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
            LoadQuery += "SELECT maBienBan, BIENBANNGHIEMTHU.maHoiDong, BIENBANNGHIEMTHU.maDeTai ,tongDiem, nhanXet,linkBienBan, ngayNghiemThu as 'Ngày nghiệm thu' FROM BIENBANNGHIEMTHU, HOIDONGNGHIEMTHU,DETAI " +
                " WHERE BIENBANNGHIEMTHU.maHoiDong = HOIDONGNGHIEMTHU.maHoiDong and DETAI.maDeTai = BIENBANNGHIEMTHU.maDeTai";
            dt = HandleDB.Instance.ExecuteQuery(LoadQuery, param);
            return dt;
        }


        public void Add()
        {
            Form main = Application.OpenForms["frmMain"];

            Dictionary<string, string> param = new Dictionary<string, string>();

            DataTable dt = new DataTable();

            string MaBB = ((frmMain)main).tb_MaBB.Text.ToString();
            string MaHoiDong = ((frmMain)main).tb_MaHD1.Text.ToString();
            string MaDeTai = ((frmMain)main).tb_MaDT5.Text.ToString();
            string tongdiem = ((frmMain)main).tb_TongDiem.Text.ToString();
            string nhanxet = ((frmMain)main).tb_NhanXet.Text.ToString();
            string linkBB = ((frmMain)main).tb_LinkBienBan.Text.ToString();



            string AddQuery = String.Empty;

            AddQuery = "INSERT INTO BIENBANNGHIEMTHU (maBienBan,maHoiDong,maDeTai,tongDiem,nhanXet,linkBienBan) values ('" + MaBB + "','" + MaHoiDong + "','" + MaDeTai + "','" + tongdiem + "', N'" + nhanxet + "',N'" + linkBB + "')";

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



        public int GetNextID()
        {
            int nextID = 1;

            string Query = String.Empty;
            Query += "SELECT TOP 1 MaBienBan FROM BienBanNghiemThu ";
            Query += "ORDER BY MaBienBan DESC";

            DataTable dt = HandleDB.Instance.ExecuteQuery(Query, null);
            if (dt.Rows.Count > 0)
            {
                Int32.TryParse(dt.Rows[0]["MaBienBan"].ToString(), out nextID);
                ++nextID;
            }
            return nextID;
        }



    }
}
