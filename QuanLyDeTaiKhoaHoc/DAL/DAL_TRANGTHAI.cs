using System;
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
    class DAL_TRANGTHAI
    {

        //-----------------------Code mẫu-------------------//
        /*
        public int getNextID()
        {
            int nextID = 1;

            string Query = String.Empty;
            Query += "SELECT TOP 1 maDieuChinhHopDong FROM MaDieuChinhHopDong ";
            Query += "ORDER BY maDieuChinhHopDong DESC";

            DataTable dt = HandleDB.Instance.ExecuteQuery(Query, null);
            if (dt.Rows.Count > 0)
            {
                Int32.TryParse(dt.Rows[0]["maDieuChinhHopDong"].ToString(), out nextID);
                ++nextID;
            }

            return nextID;
        }

        public DataTable getDanhSach(int MaHopDong)
        {
            try
            {
                DataTable dt = new DataTable();

                Dictionary<string, string> param = new Dictionary<string, string>();

                string LoadQuery = "select maDieuKhoan, noiDungDieuKhoan " +
                                    "from DieuKhoan " +
                                    "where DieuKhoan.maHopDong = @maHopDong" +
                                    "and maDieuKhoan NOT IN (SELECT maDieuKhoan FROM DieuChinhHopDong)";

                param.Add("@maHopDong", MaHopDong.ToString());

                dt = HandleDB.Instance.ExecuteQuery(LoadQuery, param);
                return dt;
            }
            catch (Exception)
            {
                return null;
            }
        }


        public void themKhachHang(DTO_KhachHang kh)
        {
            Dictionary<string, string> param = new Dictionary<string, string>();

            string AddQuery = String.Empty;
            AddQuery += "INSERT INTO KhachHang ( cmnd,name, diachi, phone) ";
            AddQuery += "VALUES (@cmnd,@name,@diachi,@phone)";


            param.Add("@cmnd", kh.KhachHang_cmnd.ToString());
            param.Add("@name", kh.KhachHang_name);
            param.Add("@diachi", kh.KhachHang_diachi);
            param.Add("@phone", kh.KhachHang_phone.ToString());


            int result = HandleDB.Instance.ExecuteNonQuery(AddQuery, param);
            if (result > 0)
            {
                Console.WriteLine("Thêm khách hàng thành công");
            }
        }


        public Boolean suaYeuCau(DTO_YeuCauVayVon yc)
        {
            try
            {
                string UpdateQuery = "";
                UpdateQuery += "UPDATE YeuCauVayVon SET ";
                UpdateQuery += "mucDichVayVon = @MucDichVayVon, ";
                UpdateQuery += "thoiHanVay = @ThoiHanVay, ";
                UpdateQuery += "soTienVay = @SoTien, ";
                UpdateQuery += "kiHan = @KiHan,";
                UpdateQuery += "ngayBatDauVay = @Ngay, ";
                UpdateQuery += "laiSuat = @LaiSuat,";
                UpdateQuery += "trangThai = @TrangThai ";
                UpdateQuery += "WHERE maYeuCauVayVon = @MaYC ";
                //DataTable dt = ObjThuocBLL.Instance.GetInfoByName(((frmMain)main).tb_tenThuoc.Text);

                Dictionary<String, String> param = new Dictionary<string, string>();
                param.Add("@MucDichVayVon", yc.YCVV_mucdich);
                param.Add("@ThoiHanVay", yc.YCVV_thoiHanVay.ToString());
                param.Add("@SoTien", yc.YCVV_soTienVay.ToString());
                param.Add("@KiHan", yc.YCVV_kiHan.ToString());
                param.Add("@Ngay", yc.YCVV_ngayBatDauVay);
                param.Add("@LaiSuat", yc.YCVV_laisuat.ToString());
                param.Add("@TrangThai", yc.YCVV_trangThai.ToString());
                param.Add("@MaYC", yc.YCVV_maYeuCau.ToString());

                int result = HandleDB.Instance.ExecuteNonQuery(UpdateQuery, param);
                if (result > 0)
                {
                    MessageBox.Show("Sửa yêu cầu thành công");
                }
            }
            catch (Exception err)
            {
                return false;
            }
            return true;

        }


        public DTO_YeuCauVayVon fineOne(int maYeuCau)
        {
            try
            {
                DataTable dt = new DataTable();
                string LoadQuery = "select KhachHang.cmnd,KhachHang.name,diachi,phone,maYeuCauVayVon,soTienVay,ngayBatDauVay,thoiHanVay,laiSuat,mucDichVayVon " +
                                    "from YeuCauVayVon, KhachHang " +
                                    "where YeuCauVayVon.maYeuCauVayVon = '" + maYeuCau.ToString();
                dt = HandleDB.Instance.ExecuteQuery(LoadQuery, null);
                IEnumerable<DataRow> rows = dt.Rows.Cast<DataRow>();
                DataRow row = rows.First();
                DTO_YeuCauVayVon res = new DTO_YeuCauVayVon(
                    Convert.ToInt32(row["maYeuCauVayVon"]),
                    row["cmnd"].ToString(),
                    row["mucDichVayVon"].ToString(),
                    Convert.ToInt32(row["thoiHanVay"]),
                    Convert.ToInt32(row["soTienVay"]),
                    Convert.ToInt32(row["thoiHanVay"]),
                    row["ngayBatDauVay"].ToString(),
                    float.Parse(row["laiSuat"].ToString()),
                    0);
                return res;
            }
            catch (Exception)
            {
                return null;
            }

        }*/
        private static DAL_TRANGTHAI instance;
        public static DAL_TRANGTHAI Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DAL_TRANGTHAI();
                }
                return instance;
            }
            set { instance = value; }
        }
        public DataTable LoadListTrangThai()
        {
            Form main = Application.OpenForms["frmMain"];

            Dictionary<string, string> param = new Dictionary<string, string>();

            DataTable dt = new DataTable();
            string LoadQuery = "";
            LoadQuery += "SELECT * FROM TRANGTHAI";
            dt = HandleDB.Instance.ExecuteQuery(LoadQuery, param);
            return dt;
        }
    }
}
