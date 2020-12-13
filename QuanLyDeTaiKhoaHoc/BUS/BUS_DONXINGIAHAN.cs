using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDeTaiKhoaHoc.BUS
{
    class BUS_DONXINGIAHAN
    {
        private static BUS_DONXINGIAHAN _instance;
        public static BUS_DONXINGIAHAN Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new BUS_DONXINGIAHAN();
                return _instance;
            }
        }
    }
}
