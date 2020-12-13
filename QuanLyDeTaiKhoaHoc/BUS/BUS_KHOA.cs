using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDeTaiKhoaHoc.BUS
{
    class BUS_KHOA
    {
        private static BUS_KHOA _instance;
        public static BUS_KHOA Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new BUS_KHOA();
                return _instance;
            }
        }
    }
}
