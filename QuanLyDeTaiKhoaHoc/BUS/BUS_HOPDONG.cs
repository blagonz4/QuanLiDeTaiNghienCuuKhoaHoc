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
    class BUS_HOPDONG
    {
        private static BUS_HOPDONG _instance;
        public static BUS_HOPDONG Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new BUS_HOPDONG();
                return _instance;
            }
        }

        private BUS_HOPDONG() { }
        public DataTable GetListHOPDONG()
        {
            return DAL_HOPDONG.Instance.LoadListHOPDONG();
        }
    }
}
