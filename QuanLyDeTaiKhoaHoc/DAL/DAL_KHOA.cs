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
    class DAL_KHOA
    {
        private static DAL_KHOA instance;
        public static DAL_KHOA Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DAL_KHOA();
                }
                return instance;
            }
            set { instance = value; }
        }
        public DataTable LoadKhoa()
        {
            Form main = Application.OpenForms["frmMain"];

            Dictionary<string, string> param = new Dictionary<string, string>();

            DataTable dt = new DataTable();
            string LoadQuery = "";
            LoadQuery += "SELECT * FROM KHOA";
            dt = HandleDB.Instance.ExecuteQuery(LoadQuery, param);
            return dt;
        }

    }
}
