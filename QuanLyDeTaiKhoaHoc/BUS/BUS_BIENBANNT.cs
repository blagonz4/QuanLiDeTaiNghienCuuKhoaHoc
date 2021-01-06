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
    class BUS_BIENBANNT
    {
        private static BUS_BIENBANNT _instance;
        public static BUS_BIENBANNT Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new BUS_BIENBANNT();
                return _instance;
            }
        }

        private BUS_BIENBANNT() { }

        public DataTable GetListBBNT()
        {
            return DAL_BIENBANNT.Instance.LoadListBBNT();
        }


        public void AddBB()
        {
            DAL_BIENBANNT.Instance.Add();
        }


        public int GetNextID()
        {
            return DAL_BIENBANNT.Instance.GetNextID();
        }
    }
}
