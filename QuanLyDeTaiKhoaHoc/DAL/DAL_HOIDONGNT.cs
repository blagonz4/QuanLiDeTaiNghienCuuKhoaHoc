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
    class DAL_HOIDONGNT
    {
        private static DAL_HOIDONGNT instance;

        public static DAL_HOIDONGNT Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DAL_HOIDONGNT();
                }
                return instance;
            }
            set { instance = value; }
        }

        public DataTable LoadListHOIDONGNT()
        {
            Form main = Application.OpenForms["frmMain"];

            Dictionary<string, string> param = new Dictionary<string, string>();

            DataTable dt = new DataTable();
            string LoadQuery = "";
            LoadQuery += "SELECT * FROM HOIDONGNGHIEMTHU";
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



        public void Sua()
        {
            System.Windows.Forms.Form f = System.Windows.Forms.Application.OpenForms["frmMain"];
            

            string MaHD = ((frmMain)f).tb_MaHD.Text.ToString();
            string ChuTich = ((frmMain)f).tb_ChuTichHD.Text.ToString();
            string PB1 = ((frmMain)f).tb_PB1.Text.ToString();
            string PB2 = ((frmMain)f).tb_PB2.Text.ToString();
            string NgNT = ((frmMain)f).tb_NgNT.Value.ToString("MM/dd/yyyy");
            string ThuKy = ((frmMain)f).tb_ThuKy.Text.ToString();

            string maKhoa = ((frmMain)f).cb_Khoa1.Text.ToString();



            string UpdateQuery = "UPDATE HOIDONGNGHIEMTHU " +
             "SET  chuTichHoiDong = '" + ChuTich + "', phanBien1 = '" + PB1 + "', PhanBien2 = '" + PB2 + "', ngayNghiemThu ='" + NgNT + "', thuKi ='" + ThuKy + "' ,maKhoa ='" + maKhoa + "' WHERE maHoiDong = '" + MaHD + "' ";
       


            int result = HandleDB.Instance.ExecuteNonQuery(UpdateQuery,null);
            if (result > 0)
            {
                MessageBox.Show("Cầu thủ đã được cập nhật", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
         

        public void Xoa()
        {
            System.Windows.Forms.Form f = System.Windows.Forms.Application.OpenForms["frmMain"];
            string id_xoa = ((frmMain)f).tb_MaHD.Text.ToString();

            string DeleteQuery = "DELETE FROM HOIDONGNGHIEMTHU WHERE MaHD = '" + id_xoa + "'";
            int result = HandleDB.Instance.ExecuteNonQuery(DeleteQuery, null);
            if (result > 0)
            {
                MessageBox.Show("Thông tin hội đồng bị xóa,bấm xem để xem dữ liệu mới", "Thông báo", MessageBoxButtons.OK);
            }
        }


     
    }
}
