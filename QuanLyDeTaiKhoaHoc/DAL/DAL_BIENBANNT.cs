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
            LoadQuery += "SELECT * FROM BIENBANNGHIEMTHU";
            dt = HandleDB.Instance.ExecuteQuery(LoadQuery, param);
            return dt;
        }


        public void Add()
        {
            Form main = Application.OpenForms["frmMain"];

            Dictionary<string, string> param = new Dictionary<string, string>();

            DataTable dt = new DataTable();

            string MaHD = ((frmMain)main).tb_MaHD.Text.ToString();
            string ChuTich = ((frmMain)main).tb_ChuTichHD.Text.ToString();
            string PB1 = ((frmMain)main).tb_PB1.Text.ToString();
            string PB2 = ((frmMain)main).tb_PB2.Text.ToString();
            string NgNT = ((frmMain)main).tb_NgNT.Value.ToString("MM/dd/yyyy");
            string ThuKy = ((frmMain)main).tb_ThuKy.Text.ToString();

            string maKhoa = ((frmMain)main).cb_Khoa1.Text.ToString();


            string AddQuery = String.Empty;

            AddQuery = "INSERT INTO HOIDONGNGHIEMTHU (maHoiDong, chuTichHoiDong, phanbien1,phanbien2,ngayNghiemThu,thuKi, maKhoa) values ('" + MaHD + "','" + ChuTich + "','" + PB1 + "', '" + PB2 + "','" + NgNT + "','" + ThuKy + "','" + maKhoa + "')";

            int result = HandleDB.Instance.ExecuteNonQuery(AddQuery, param);

            if (result > 0)
            {
                MessageBox.Show("Thành lập hội đồng nghiệm thu thành công  thành công");
            }
            else
            {
                MessageBox.Show("Thành lập thất bại bại");
            }
        }



    }
}
