using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyDeTaiKhoaHoc.BUS;
namespace QuanLyDeTaiKhoaHoc.GUI
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            BUS_GIANGVIEN.Instance.AddGV();
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            BUS_GIANGVIEN.Instance.SuaGV();
        }
    }
}
