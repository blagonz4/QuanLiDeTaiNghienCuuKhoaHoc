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
    }
}
