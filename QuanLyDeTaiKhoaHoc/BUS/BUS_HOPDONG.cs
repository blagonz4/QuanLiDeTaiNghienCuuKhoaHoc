using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
