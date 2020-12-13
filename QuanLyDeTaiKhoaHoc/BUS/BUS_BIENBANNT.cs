using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
