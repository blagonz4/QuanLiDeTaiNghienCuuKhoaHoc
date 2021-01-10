using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyDeTaiKhoaHoc.GUI;
using QuanLyDeTaiKhoaHoc.DAL;

namespace QuanLyDeTaiKhoaHoc.GUI
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }


        public void LoginCheck()
        {

            if (this.tb_TaiKhoan.Text == String.Empty || this.tb_Matkhau.Text == String.Empty)
            {
                MessageBox.Show("Nhập lại tài khoản/mật khẩu");
                return;
            }

            System.Windows.Forms.Form f = System.Windows.Forms.Application.OpenForms["Login"];
            string taikhoan = ((Login)f).tb_TaiKhoan.Text;
            string matkhau = ((Login)f).tb_Matkhau.Text;

            string query = "";
            query += "SELECT * ";
            query += "FROM [QUANLYDETAI].[dbo].[ACCOUNT] ";
            query += "WHERE [Email] = @tk ";
            query += "AND [Pass] = @mk";

            Dictionary<String, String> dic = new Dictionary<string, string>();
            dic.Add("@tk", taikhoan);
            dic.Add("@mk", matkhau);

            DataTable result = HandleDB.Instance.ExecuteQuery(query, dic);
            if (result.Rows.Count > 0)
            {
                frmMain form = new frmMain(result.Rows[0][0].ToString(), result.Rows[0][1].ToString(), result.Rows[0][2].ToString());
                this.Hide();
                form.ShowDialog();
            }
            else
            {
                MessageBox.Show("Sai tài khoản/mật khẩu");
            }


        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            LoginCheck();
        }
    }


}
