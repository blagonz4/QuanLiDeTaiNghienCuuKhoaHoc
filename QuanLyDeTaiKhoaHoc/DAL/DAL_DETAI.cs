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
        public string maDeTai { get; set; }
        public string tenDeTai { get; set; }
        public DateTime ngayTH { get; set; }
        public string linhVuc { get; set; }
        public string capDo { get; set; }
        public string ketQua { get; set; }
        public string maTrangThai { get; set; }
        public string maGiangVien { get; set; }
        public DAL_DETAI() { }
        public void AddDeTai()
        {
            System.Windows.Forms.Form f = System.Windows.Forms.Application.OpenForms["frmMain"];
            string AddQuery = "";
            AddQuery += "INSERT INTO DETAI(maDeTai,tenDeTai,ngayTH,,linhVuc,capDo,ketQua,maTrangThai,maGiangVien)";
            AddQuery += "VALUES(@maDeTai,@tenDeTai,@ngayTH,@linhVuc,@capDo,@ketQua,@maTrangThai,@maGiangVien)";

            Dictionary<string, string> param = new Dictionary<string, string>();

            param.Add("@maDeTai", ((frmMain)f).tb_MaDT1.Text);
            param.Add("@tenGiangVien", ((frmMain)f).tb_TenDT1.Text);
            param.Add("@ngayTH", ((frmMain)f).dt_NgTH1.Value.ToString());
            param.Add("@linhVuc", ((frmMain)f).tb_LinhVuc1.Text);
            param.Add("@capDo", ((frmMain)f).cb_CapDo1.Text);
            param.Add("@ketQua", ((frmMain)f).tb_KetQua1.Text);
            param.Add("@maTrangThai", ((frmMain)f).cb_TrangThai1.Text);
            param.Add("@maGiangVien", ((frmMain)f).tb_MaGV1.Text);
            int result = HandleDB.Instance.ExecuteNonQuery(AddQuery, param);
            if (result > 0)
            {
                MessageBox.Show("Thêm đề tài thành công");
            }
        }


    }
}
