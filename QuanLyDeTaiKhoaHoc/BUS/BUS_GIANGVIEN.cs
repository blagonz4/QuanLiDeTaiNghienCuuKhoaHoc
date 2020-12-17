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
using QuanLyDeTaiKhoaHoc.DAL;

namespace QuanLyDeTaiKhoaHoc.BUS
{
    class BUS_GIANGVIEN
    {
        private static BUS_GIANGVIEN _instance;
        public static BUS_GIANGVIEN Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new BUS_GIANGVIEN();
                return _instance;
            }
        }

        public DataTable GetListGV()
        {
            return DAL_GIANGVIEN.Instance.LoadListGV();
        }

    }
}
