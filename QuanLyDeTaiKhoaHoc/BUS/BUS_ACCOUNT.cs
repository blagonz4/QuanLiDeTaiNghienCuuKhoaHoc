using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using QuanLyDeTaiKhoaHoc.DAL;

namespace QuanLyDeTaiKhoaHoc.BUS
{
    class BUS_ACCOUNT
    {
        private static BUS_ACCOUNT _instance;
        public static BUS_ACCOUNT Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new BUS_ACCOUNT();
                return _instance;
            }
        }
    }
}
