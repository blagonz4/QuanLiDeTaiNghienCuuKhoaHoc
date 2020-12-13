using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDeTaiKhoaHoc.BUS
{
    class BUS_CTDXGH
    {
        private static BUS_CTDXGH _instance;
        public static BUS_CTDXGH Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new BUS_CTDXGH();
                return _instance;
            }
        }
    }
}
