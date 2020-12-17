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
        public DataTable LoadListGV()
        {
            Form main = Application.OpenForms["frmMain"];

            Dictionary<string, string> param = new Dictionary<string, string>();

            DataTable dt = new DataTable();
            string LoadQuery = "";
            dt = HandleDB.Instance.ExecuteQuery(LoadQuery, param);
            return dt;
        }


    }

}
