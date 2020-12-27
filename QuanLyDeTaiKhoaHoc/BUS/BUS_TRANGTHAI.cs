using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyDeTaiKhoaHoc.DAL;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyDeTaiKhoaHoc.BUS
{
    class BUS_TRANGTHAI
    {
        private static BUS_TRANGTHAI _instance;
        public static BUS_TRANGTHAI Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new BUS_TRANGTHAI();
                return _instance;
            }
        }
        private BUS_TRANGTHAI() { }
        public DataTable GetListTrangThai()
        {
            return DAL_TRANGTHAI.Instance.LoadListTrangThai();
        }
    }
}
