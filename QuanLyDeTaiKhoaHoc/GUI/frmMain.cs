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
using QuanLyDeTaiKhoaHoc.BUS;
using QuanLyDeTaiKhoaHoc.DTO;
using System.Data;
using System.Data.SqlClient;
using QuanLyDeTaiKhoaHoc.DAL;
using System.Drawing.Printing;
using System.Runtime.Remoting.Messaging;



namespace QuanLyDeTaiKhoaHoc.GUI
{
    public partial class frmMain : Form
    {
        private Dictionary<string, string[]> listBBNT = new Dictionary<string, string[]>(); // lấy danh sách nghiệm thu


        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

            // load dgv vs combo box
            dgv_GiangVien.DataSource = BUS_GIANGVIEN.Instance.GetListGV();
            dgv_DeTai.DataSource = BUS_DETAI.Instance.GetListDeTai();
            cb_Khoa.DataSource = BUS_KHOA.Instance.GetListKhoa();
            cb_TrangThai3.DataSource = BUS_TRANGTHAI.Instance.GetListTrangThai();
            dgv_DuyetDeTai.DataSource = BUS_DETAI.Instance.GetListDeTaiChoDuyet();
            dgv_HD.DataSource = BUS_HOIDONGNT.Instance.GetListHOIDONGNT();
            dgv_BBNT.DataSource = BUS_BIENBANNT.Instance.GetListBBNT();


        }

        private void dgv_GiangVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                tb_MaGV.Text = dgv_GiangVien.Rows[e.RowIndex].Cells["maGiangVien"].Value.ToString();
                tb_TenGV.Text = dgv_GiangVien.Rows[e.RowIndex].Cells["tenGiangVien"].Value.ToString();
                dt_NgSinh.Text = dgv_GiangVien.Rows[e.RowIndex].Cells["ngaySinh"].Value.ToString();
                tb_HopDong.Text = dgv_GiangVien.Rows[e.RowIndex].Cells["maHopDong"].Value.ToString();
                tb_ChuyenNganh.Text = dgv_GiangVien.Rows[e.RowIndex].Cells["Nganh"].Value.ToString();
            }
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            BUS_GIANGVIEN.Instance.AddGV();
            dgv_GiangVien.DataSource = BUS_GIANGVIEN.Instance.GetListGV();
        }

        private void tb_ThemDT_Click(object sender, EventArgs e)
        {
            BUS_DETAI.Instance.AddDeTai();
        }

        private void dgv_GiangVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                tb_MaGV.Text = dgv_GiangVien.Rows[e.RowIndex].Cells["maGiangVien"].Value.ToString();
                tb_TenGV.Text = dgv_GiangVien.Rows[e.RowIndex].Cells["tenGiangVien"].Value.ToString();
                dt_NgSinh.Text= dgv_GiangVien.Rows[e.RowIndex].Cells["ngaySinh"].Value.ToString();
                tb_HopDong.Text = dgv_GiangVien.Rows[e.RowIndex].Cells["maHopDong"].Value.ToString();
                tb_ChuyenNganh.Text = dgv_GiangVien.Rows[e.RowIndex].Cells["Nganh"].Value.ToString();
            }
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            BUS_GIANGVIEN.Instance.XoaGV();
            dgv_GiangVien.DataSource = BUS_GIANGVIEN.Instance.GetListGV();
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            BUS_GIANGVIEN.Instance.SuaGV();
            dgv_GiangVien.DataSource = BUS_GIANGVIEN.Instance.GetListGV();
        }

        private void btn_XoaDT_Click(object sender, EventArgs e)
        {
            BUS_DETAI.Instance.XoaDeTai();
        }

        private void dgv_DeTai_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                tb_MaDT1.Text = dgv_DeTai.Rows[e.RowIndex].Cells["maDeTai"].Value.ToString();
                tb_TenDT1.Text = dgv_DeTai.Rows[e.RowIndex].Cells["tenDeTai"].Value.ToString();
                tb_LinhVuc1.Text = dgv_DeTai.Rows[e.RowIndex].Cells["linhVuc"].Value.ToString();
                cb_CapDo1.Text = dgv_DeTai.Rows[e.RowIndex].Cells["capDo"].Value.ToString();
                cb_TrangThai3.Text = dgv_DeTai.Rows[e.RowIndex].Cells["maTrangThai"].Value.ToString();
                tb_KetQua1.Text = dgv_DeTai.Rows[e.RowIndex].Cells["ketQua"].Value.ToString();
                tb_MaGV1.Text = dgv_DeTai.Rows[e.RowIndex].Cells["maGiangVien"].Value.ToString();
                dt_NgTH1.Text = dgv_DeTai.Rows[e.RowIndex].Cells["ngayThucHien"].Value.ToString();
                tb_LinkDeTai2.Text = dgv_DeTai.Rows[e.RowIndex].Cells["linkDeTai"].Value.ToString();
            }
        }

        private void cb_Khoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            cb_Khoa.DisplayMember="tenKhoa";
            cb_Khoa.ValueMember = "maKhoa";
        }

        private void cb_TrangThai3_SelectedIndexChanged(object sender, EventArgs e)
        {
            cb_TrangThai3.DisplayMember = "tenTrangThai";
            cb_TrangThai3.ValueMember = "maTrangThai";
        }

        private void dgv_DeTai_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                tb_MaDT1.Text = dgv_DeTai.Rows[e.RowIndex].Cells["maDeTai"].Value.ToString();
                tb_TenDT1.Text = dgv_DeTai.Rows[e.RowIndex].Cells["tenDeTai"].Value.ToString();
                tb_LinhVuc1.Text = dgv_DeTai.Rows[e.RowIndex].Cells["linhVuc"].Value.ToString();
                cb_CapDo1.Text = dgv_DeTai.Rows[e.RowIndex].Cells["capDo"].Value.ToString();
                cb_TrangThai3.Text = dgv_DeTai.Rows[e.RowIndex].Cells["maTrangThai"].Value.ToString();
                tb_KetQua1.Text = dgv_DeTai.Rows[e.RowIndex].Cells["ketQua"].Value.ToString();
                tb_MaGV1.Text = dgv_DeTai.Rows[e.RowIndex].Cells["maGiangVien"].Value.ToString();
                dt_NgTH1.Text = dgv_DeTai.Rows[e.RowIndex].Cells["ngayThucHien"].Value.ToString();
                tb_LinkDeTai2.Text = dgv_DeTai.Rows[e.RowIndex].Cells["linkDeTai"].Value.ToString();
            }
        }

        private void dgv_HD_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                tb_MaHD.Text = dgv_HD.Rows[e.RowIndex].Cells["maHoiDong"].Value.ToString();
                tb_ChuTichHD.Text = dgv_HD.Rows[e.RowIndex].Cells["chuTichHoiDong"].Value.ToString();
                tb_PB1.Text = dgv_HD.Rows[e.RowIndex].Cells["phanBien1"].Value.ToString();
                tb_PB2.Text = dgv_HD.Rows[e.RowIndex].Cells["phanBien2"].Value.ToString();
                tb_ThuKy.Text = dgv_HD.Rows[e.RowIndex].Cells["thuKi"].Value.ToString();
                tb_NgNT.Text = dgv_HD.Rows[e.RowIndex].Cells["ngayNghiemThu"].Value.ToString();
                cb_Khoa1.Text = dgv_HD.Rows[e.RowIndex].Cells["maKhoa"].Value.ToString();
            }
        }

        private void dgv_HD_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                tb_MaHD.Text = dgv_HD.Rows[e.RowIndex].Cells["maHoiDong"].Value.ToString();
                tb_ChuTichHD.Text = dgv_HD.Rows[e.RowIndex].Cells["chuTichHoiDong"].Value.ToString();
                tb_PB1.Text = dgv_HD.Rows[e.RowIndex].Cells["phanBien1"].Value.ToString();
                tb_PB2.Text = dgv_HD.Rows[e.RowIndex].Cells["phanBien2"].Value.ToString();
                tb_ThuKy.Text = dgv_HD.Rows[e.RowIndex].Cells["thuKi"].Value.ToString();
                tb_NgNT.Text = dgv_HD.Rows[e.RowIndex].Cells["ngayNghiemThu"].Value.ToString();
                cb_Khoa1.Text = dgv_HD.Rows[e.RowIndex].Cells["maKhoa"].Value.ToString();
            }
        }

        private void dgv_DuyetDeTai_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                tb_MaDT2.Text = dgv_DuyetDeTai.Rows[e.RowIndex].Cells["maDeTai"].Value.ToString();
                tb_TenDT2.Text = dgv_DuyetDeTai.Rows[e.RowIndex].Cells["tenDeTai"].Value.ToString();
                tb_LinhVuc2.Text = dgv_DuyetDeTai.Rows[e.RowIndex].Cells["linhVuc"].Value.ToString();
                cb_CapDo2.Text = dgv_DuyetDeTai.Rows[e.RowIndex].Cells["capDo"].Value.ToString();
                tb_MaGV3.Text = dgv_DuyetDeTai.Rows[e.RowIndex].Cells["maGiangVien"].Value.ToString();
                dt_NgTH2.Text = dgv_DuyetDeTai.Rows[e.RowIndex].Cells["ngayThucHien"].Value.ToString();
                // thiếu link đề tài
            }
        }

        private void btn_DuyetDeTai_Click(object sender, EventArgs e)
        {
            BUS_DETAI.Instance.DuyetDeTai();
        }

        private void dgv_DuyetDeTai_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                tb_MaDT2.Text = dgv_DuyetDeTai.Rows[e.RowIndex].Cells["maDeTai"].Value.ToString();
                tb_TenDT2.Text = dgv_DuyetDeTai.Rows[e.RowIndex].Cells["tenDeTai"].Value.ToString();
                tb_LinhVuc2.Text = dgv_DuyetDeTai.Rows[e.RowIndex].Cells["linhVuc"].Value.ToString();
                cb_CapDo2.Text = dgv_DuyetDeTai.Rows[e.RowIndex].Cells["capDo"].Value.ToString();
                tb_MaGV3.Text = dgv_DuyetDeTai.Rows[e.RowIndex].Cells["maGiangVien"].Value.ToString();
                dt_NgTH2.Text = dgv_DuyetDeTai.Rows[e.RowIndex].Cells["ngayThucHien"].Value.ToString();
                // thiếu link đề tài
            }
        }

        private void btn_ThemHD_Click(object sender, EventArgs e)
        {
            BUS_HOIDONGNT.Instance.ThemHD();
            dgv_HD.DataSource = BUS_HOIDONGNT.Instance.GetListHOIDONGNT();
        }

        private void btn_XoaHD_Click(object sender, EventArgs e)
        {
            BUS_HOIDONGNT.Instance.XoaHD();
            dgv_HD.DataSource = BUS_HOIDONGNT.Instance.GetListHOIDONGNT();
        }

        private void btn_SuaHD_Click(object sender, EventArgs e)
        {
            BUS_HOIDONGNT.Instance.SuaHD();
            dgv_HD.DataSource = BUS_HOIDONGNT.Instance.GetListHOIDONGNT();
        }

        private void guna2TextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgv_BBNT_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                tb_MaBB.Text = dgv_BBNT.Rows[e.RowIndex].Cells["maBienBan"].Value.ToString();
                tb_MaHD1.Text = dgv_BBNT.Rows[e.RowIndex].Cells["maHoiDong1"].Value.ToString();
                tb_TongDiem.Text = dgv_BBNT.Rows[e.RowIndex].Cells["tongDiem"].Value.ToString();
                tb_NhanXet.Text = dgv_BBNT.Rows[e.RowIndex].Cells["nhanXet"].Value.ToString();
            }
        }
        private void dgv_BBNT_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                tb_MaBB.Text = dgv_BBNT.Rows[e.RowIndex].Cells["maBienBan"].Value.ToString();
                tb_MaHD1.Text = dgv_BBNT.Rows[e.RowIndex].Cells["maHoiDong1"].Value.ToString();
                tb_TongDiem.Text = dgv_BBNT.Rows[e.RowIndex].Cells["tongDiem"].Value.ToString();
                tb_NhanXet.Text = dgv_BBNT.Rows[e.RowIndex].Cells["nhanXet"].Value.ToString();
            }
        }

        private void btn_ThemBB_Click(object sender, EventArgs e)
        {
            BUS_BIENBANNT.Instance.AddBB();
            dgv_BBNT.DataSource = BUS_BIENBANNT.Instance.GetListBBNT();
        }

      

        private bool PrintBBNT() // hiển thị print dialog biên bản nghiệm thu
        {
            printDocument3.DefaultPageSettings.Landscape = true;
            printDocument3.DefaultPageSettings.PaperSize.RawKind = (int)PaperKind.A3;

            var resultDialog = printDialog1.ShowDialog();

            if (resultDialog == DialogResult.OK)
            {
                try
                {
                    printDocument3.Print();
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
            }

            return false;
        }

        private void printDocument3_PrintPage(object sender, PrintPageEventArgs e) // in biên bản nghiệm thu
        {
            e.Graphics.ScaleTransform(0.6f, 0.6f);

            Font font = new Font("Courier New", 12);
            Brush brush = new SolidBrush(Color.Black);

            float fontHeight = font.GetHeight();

            int startX = 10, startY = 10, offset = 100;

            //get max string length
            int maxLen = 0;
            foreach (string[] item in listBBNT.Values.ToList())
            {
                int maxLenStr = item.Max(str => str.Length);
                if (maxLenStr > maxLen)
                {
                    maxLen = maxLenStr;
                }
            }

            //info biên bản nghiêm thu
            string maBB = String.Format("Mã biên bản: {0}", tb_MaBB.Text);
            string maHD = String.Format("Mã hội đồng: {0}", tb_MaHD1.Text);
            string nhanxet = String.Format("Nhận xét: {0}", tb_MaHD1.Text);
            string tongdiem= String.Format("Tổng điểm: {0}", tb_TongDiem.Text);

            string listHeader = String.Empty;
            listHeader += String.Format("{0,-15}", "Mã biên bản");
            listHeader += String.Format("{0,-15}", "Mã hội đồng");
            listHeader += String.Format("{0,-15}", "Nhận xét");
            listHeader += String.Format("{0,-15}", "Tổng điểm");


            Graphics graphic = e.Graphics;
            graphic.DrawString(" Biên bản nghiệm thu", new Font("Courier New", 18, FontStyle.Bold), new SolidBrush(Color.Red), startX, 0);
            graphic.DrawString(maBB, font, brush, startX, startY + 20);
            graphic.DrawString(maHD, font, brush, startX, startY + 40);
            graphic.DrawString(nhanxet, font, brush, startX, startY + 40);
            graphic.DrawString(tongdiem, font, brush, startX, startY + 40);

            graphic.DrawString("--------------------------------", font, brush, startX, startY + 60);

            graphic.DrawString(listHeader, font, brush, startX, startY + 80);

            string format = "{0,-" + maxLen + "}\t";
            foreach (string[] items in listBBNT.Values.ToList())
            {
                string itemStr = String.Empty;

                for (int itemInd = 0; itemInd < items.Length; ++itemInd)
                {
                    itemStr += String.Format(format, items[itemInd]);
                }

                graphic.DrawString(itemStr, font, new SolidBrush(Color.Gray), startX, startY + offset);

                offset += (int)fontHeight + 5;
            }

            graphic.DrawImage(Properties.Resources.pill, startX, startY + offset);
        }

        private void btn_InBB_Click(object sender, EventArgs e) // in biên bản nghiệm thu
        {
            var resultDialog = MessageBox.Show("In phiếu biên bản nghiệm thu?", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            if (resultDialog == DialogResult.OK)
            {
                bool result = PrintBBNT();

                if (result)
                {
                    MessageBox.Show("In biên bản nghiệm thu thành công");
                 //  BUS_BIENBANNT.Instance.AddBB();
                }
                else
                {
                    MessageBox.Show("In biên bản nghiệm thu thất bại");
                }
            }

        }
    }
}
