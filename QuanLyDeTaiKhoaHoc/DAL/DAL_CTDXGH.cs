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
    class DAL_CTDXGH
    {
        private static DAL_CTDXGH instance;

        public static DAL_CTDXGH Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DAL_CTDXGH();
                }
                return instance;
            }
            set { instance = value; }
        }


        public DataTable LoadListCTDXGH()
        {
            Form main = Application.OpenForms["frmMain"];

            Dictionary<string, string> param = new Dictionary<string, string>();

            DataTable dt = new DataTable();
            string LoadQuery = "";
            LoadQuery += "SELECT * FROM CHITIETDONXINGIAHAN";
            dt = HandleDB.Instance.ExecuteQuery(LoadQuery, param);
            return dt;
        }
    }
}
