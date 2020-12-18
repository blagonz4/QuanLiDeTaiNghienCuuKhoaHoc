using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using QuanLyDeTaiKhoaHoc.GUI;
using QuanLyDeTaiKhoaHoc.BUS;
using System.Windows.Forms;
namespace QuanLyDeTaiKhoaHoc.DAL
{
    class DAL_GIANGVIEN
    {
        private static DAL_GIANGVIEN instance;
        public static DAL_GIANGVIEN Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DAL_GIANGVIEN();
                }
                return instance;
            }
            set { instance = value; }
        }
        public string maGiangVien { get; set; }
        public string tenGiangVien { get; set; }
        public string nganh { get; set; }
        public string maHopDong { get; set; }
        public string maKhoa { get; set; }
        public string maAccount { get; set; }
        public DateTime ngaysinh { get; set; }
        public DAL_GIANGVIEN() { }
        public void AddGV()
        {
            System.Windows.Forms.Form f = System.Windows.Forms.Application.OpenForms["frmMain"];
            string AddQuery = "";
            AddQuery += "INSERT INTO GIANGVIEN(maGiangVien,tenGiangVien,Nganh,maHopDong,maAccount,maKhoa,trinhDo,ngaySinh)";
            AddQuery+=  "VALUES(@maGiangVien,@tenGiangVien,@Nganh,@maHopDong,'1','1','dai hoc',@ngaySinh)";
           
            Dictionary<string, string> param = new Dictionary<string, string>();

            param.Add("@maGiangVien", ((frmMain)f).tb_MaGV.Text);
            param.Add("@tenGiangVien", ((frmMain)f).tb_TenGV.Text);
            param.Add("@Nganh", ((frmMain)f).tb_ChuyenNganh.Text);
            param.Add("@maHopDong", ((frmMain)f).tb_HopDong.Text);
           // param.Add("@maKhoa", ((frmMain)f).cb_Khoa.Text);
            param.Add("@ngaySinh", ((frmMain)f).dt_NgSinh.Value.ToString());
            int result = HandleDB.Instance.ExecuteNonQuery(AddQuery,param);
            if(result > 0)
            {
                MessageBox.Show("Thêm giảng viên thành công");
            }
        }
        public void XoaGV()
        {
            System.Windows.Forms.Form f = System.Windows.Forms.Application.OpenForms["frmMain"];
            string id_xoa = ((frmMain)f).tb_MaGV.Text;
            string DeleteQuery = "DELETE FROM GIANGVIEN WHERE maGiangVien ='" + id_xoa + "'";
            int result = HandleDB.Instance.ExecuteNonQuery(DeleteQuery, null);
            if(result>0)
            {
                MessageBox.Show("Xóa giảng viên thành công");
            }
        }
        public void SuaGV()
        {
            System.Windows.Forms.Form f = System.Windows.Forms.Application.OpenForms["frmMain"];
            int id = int.Parse(((frmMain)f).tb_MaGV.Text.ToString());
            string ten = ((frmMain)f).tb_TenGV.Text;
            string nganh = ((frmMain)f).tb_ChuyenNganh.Text;
            int idHopDong = int.Parse(((frmMain)f).tb_HopDong.Text.ToString());
            int idKhoa = int.Parse(((frmMain)f).cb_Khoa.Text.ToString());
            string ngaysinh = ((frmMain)f).dt_NgSinh.Text;
            // string UpdateQuery = "UPDATE GIANGVIEN"+
            //"SET tenGiangVien='"+"'"
            string UpdateQuery = "";
            UpdateQuery += "UPDATE GIANGVIEN SET";
            UpdateQuery += "tenGiangVien=@tenGiangVien";
            UpdateQuery += "maGiangVien=@maGiangVien";
            UpdateQuery += "Nganh=@Nganh";
            UpdateQuery += "maHopDong=@maHopDong";
            UpdateQuery += "maAccount=@maAccount";
            UpdateQuery += "maKhoa=@maKhoa";
            UpdateQuery += "trinhDo=@trinhDo";
            UpdateQuery += "ngaySinh=@ngaySinh";
            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("@maGiangVien", ((frmMain)f).tb_MaGV.Text);
            param.Add("@tenGiangVien", ((frmMain)f).tb_TenGV.Text);
            param.Add("@Nganh", ((frmMain)f).tb_ChuyenNganh.Text);
            param.Add("@maHopDong", ((frmMain)f).tb_HopDong.Text);
            // param.Add("@maKhoa", ((frmMain)f).cb_Khoa.Text);
            param.Add("@ngaySinh", ((frmMain)f).dt_NgSinh.Value.ToString());
            int result = HandleDB.Instance.ExecuteNonQuery(UpdateQuery, param);
            if(result > 0)
            {
                MessageBox.Show("Sửa giảng viên thành công");
            }
        }
    }
}
