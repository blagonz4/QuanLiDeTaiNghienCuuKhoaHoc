using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
