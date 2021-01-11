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
        string taikhoan = "", matkhau = "", maTypeAccount = "";
        private Dictionary<string, string[]> listBBNT = new Dictionary<string, string[]>(); // lấy danh sách nghiệm thu


        public frmMain(string taikhoan, string matkhau, string maTypeAccount)
        {
            InitializeComponent();
            this.taikhoan = taikhoan;
            this.matkhau = matkhau;
            this.maTypeAccount = maTypeAccount;
        }

        public void Phanquyen() // Phân quyền đăng nhập
        {
            if (this.maTypeAccount.CompareTo("2") == 0) // giảng viên 
            {
                tab_main.Controls.Remove(tab_DangKiDT);
                tab_main.Controls.Remove(tab_GHDT);
         

            }
            else if (this.maTypeAccount.CompareTo("1") == 0)// nhân viên phòng khoa học
            {
                tab_main.Controls.Remove(tab_GiangVien);
                tab_main.Controls.Remove(tab_HoiDong);
                tab_main.Controls.Remove(tab_DDT);
                tab_main.Controls.Remove(tab_BCTH);
                tab_main.Controls.Remove(tab_NghiemThu);
                tab_main.Controls.Remove(tab_QLDT);

            }
            else if (this.maTypeAccount.CompareTo("3") == 0)// nhân viên bảo trì
            {
              
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {


            Phanquyen();


            // hiển thị dữ liệu lên datagrid view
            dgv_GiangVien.DataSource = BUS_GIANGVIEN.Instance.GetListGV();
            dgv_DeTai.DataSource = BUS_DETAI.Instance.GetListDeTai();
            cb_Khoa.DataSource = BUS_KHOA.Instance.GetListKhoa();
            cb_Khoa1.DataSource = BUS_KHOA.Instance.GetListKhoa();
            cb_TrangThai3.DataSource = BUS_TRANGTHAI.Instance.GetListTrangThai();
            dgv_DuyetDeTai.DataSource = BUS_DETAI.Instance.GetListDeTaiChoDuyet();
            dgv_HD.DataSource = BUS_HOIDONGNT.Instance.GetListHOIDONGNT();
            dgv_BBNT.DataSource = BUS_BIENBANNT.Instance.GetListBBNT();
            dgv_GiaHan.DataSource = BUS_DONXINGIAHAN.Instance.GetListDXGH();



            // load combo box khoa
            cb_Khoa.AutoCompleteSource = AutoCompleteSource.ListItems;
            cb_Khoa.DropDownStyle = ComboBoxStyle.DropDownList;
            cb_Khoa.DisplayMember = "tenKhoa";
            cb_Khoa.ValueMember = "maKhoa";          
            cb_Khoa.Text = " Chọn tên khoa ";


            // load combobox khoa1
            cb_Khoa1.AutoCompleteSource = AutoCompleteSource.ListItems;
            cb_Khoa1.DropDownStyle = ComboBoxStyle.DropDownList;
            cb_Khoa1.DisplayMember = "tenKhoa";
            cb_Khoa1.ValueMember = "maKhoa";
            cb_Khoa1.Text = " Chọn tên khoa ";


            // load combo box trang thai
            cb_TrangThai3.AutoCompleteSource = AutoCompleteSource.ListItems;
            cb_TrangThai3.DropDownStyle = ComboBoxStyle.DropDownList;
            cb_TrangThai3.DisplayMember = "tenTrangThai";
            cb_TrangThai3.ValueMember = "maTrangThai";
            cb_TrangThai3.Text = " Chọn trạng thái ";


         
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
                tb_trinhDo.Text = dgv_GiangVien.Rows[e.RowIndex].Cells["trinhDo"].Value.ToString();
                cb_Khoa.SelectedValue = dgv_GiangVien.Rows[e.RowIndex].Cells["maKhoa1"].Value.ToString();
            }
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            tb_MaGV.Text = BUS_GIANGVIEN.Instance.GetnextID().ToString();
            BUS_GIANGVIEN.Instance.AddGV();
            dgv_GiangVien.DataSource = BUS_GIANGVIEN.Instance.GetListGV();
        }

        private void tb_ThemDT_Click(object sender, EventArgs e)
        {
            tb_MaDT.Text = BUS_DETAI.Instance.GetnextID().ToString();
            BUS_DETAI.Instance.AddDeTai();
            guna2DataGridView1.DataSource = BUS_DETAI.Instance.GetListDeTaiChoDuyet();
            dgv_DuyetDeTai.DataSource = BUS_DETAI.Instance.GetListDeTaiChoDuyet();
        }

        private void dgv_GiangVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                tb_MaGV.Text = dgv_GiangVien.Rows[e.RowIndex].Cells["maGiangVien"].Value.ToString();
                tb_TenGV.Text = dgv_GiangVien.Rows[e.RowIndex].Cells["tenGiangVien"].Value.ToString();
                dt_NgSinh.Text = dgv_GiangVien.Rows[e.RowIndex].Cells["ngaySinh"].Value.ToString();
                tb_HopDong.Text = dgv_GiangVien.Rows[e.RowIndex].Cells["maHopDong"].Value.ToString();
                tb_ChuyenNganh.Text = dgv_GiangVien.Rows[e.RowIndex].Cells["Nganh"].Value.ToString();
                tb_trinhDo.Text = dgv_GiangVien.Rows[e.RowIndex].Cells["trinhDo"].Value.ToString();
                cb_Khoa.SelectedValue = dgv_GiangVien.Rows[e.RowIndex].Cells["maKhoa1"].Value.ToString();
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
            dgv_DeTai.DataSource = BUS_DETAI.Instance.GetListDeTai();
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
                cb_Khoa1.SelectedValue = dgv_HD.Rows[e.RowIndex].Cells["maKhoa"].Value.ToString();
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
                cb_Khoa1.SelectedValue = dgv_HD.Rows[e.RowIndex].Cells["maKhoa"].Value.ToString();
            }
        }

        private void dgv_DuyetDeTai_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                tb_MaDT2.Text = dgv_DuyetDeTai.Rows[e.RowIndex].Cells["maDeTai3"].Value.ToString();
                tb_TenDT2.Text = dgv_DuyetDeTai.Rows[e.RowIndex].Cells["tenDeTai3"].Value.ToString();
                tb_LinhVuc2.Text = dgv_DuyetDeTai.Rows[e.RowIndex].Cells["linhVuc3"].Value.ToString();
                cb_CapDo2.SelectedValue = dgv_DuyetDeTai.Rows[e.RowIndex].Cells["capDo3"].Value.ToString();
                tb_MaGV3.Text = dgv_DuyetDeTai.Rows[e.RowIndex].Cells["maGiangVien"].Value.ToString();
                dt_NgTH2.Text = dgv_DuyetDeTai.Rows[e.RowIndex].Cells["ngayThucHien3"].Value.ToString();
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
                tb_MaDT2.Text = dgv_DuyetDeTai.Rows[e.RowIndex].Cells["maDeTai3"].Value.ToString();
                tb_TenDT2.Text = dgv_DuyetDeTai.Rows[e.RowIndex].Cells["tenDeTai3"].Value.ToString();
                tb_LinhVuc2.Text = dgv_DuyetDeTai.Rows[e.RowIndex].Cells["linhVuc3"].Value.ToString();
                cb_CapDo2.SelectedValue = dgv_DuyetDeTai.Rows[e.RowIndex].Cells["capDo3"].Value.ToString();
                tb_MaGV3.Text = dgv_DuyetDeTai.Rows[e.RowIndex].Cells["maGiangVien"].Value.ToString();
                dt_NgTH2.Text = dgv_DuyetDeTai.Rows[e.RowIndex].Cells["ngayThucHien3"].Value.ToString();
                // thiếu link đề tài
            }
        }

        private void btn_ThemHD_Click(object sender, EventArgs e)
        {
            tb_MaHD.Text = BUS_HOIDONGNT.Instance.GetNextID().ToString();
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
                tb_MaDT5.Text = dgv_BBNT.Rows[e.RowIndex].Cells["maDeTai"].Value.ToString();
                tb_LinkBienBan.Text = dgv_BBNT.Rows[e.RowIndex].Cells["linkBienBan"].Value.ToString();
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
                tb_MaDT5.Text = dgv_BBNT.Rows[e.RowIndex].Cells["maDeTai"].Value.ToString();
                tb_LinkBienBan.Text = dgv_BBNT.Rows[e.RowIndex].Cells["linkBienBan"].Value.ToString();
            }
        }

        private void btn_ThemBB_Click(object sender, EventArgs e)
        {
            tb_MaBB.Text = BUS_BIENBANNT.Instance.GetNextID().ToString();
            BUS_BIENBANNT.Instance.AddBB();
            dgv_BBNT.DataSource = BUS_BIENBANNT.Instance.GetListBBNT();

            int tongdiem = Int32.Parse(tb_TongDiem.Text);

            if (tongdiem < 65)
            {
                BUS_DETAI.Instance.Updateketqua("Không đạt");

            }

            else
            {
                BUS_DETAI.Instance.Updateketqua("Đạt");
            }
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
            string madetai = String.Format("Mã đề tài: {0}", tb_MaDT5.Text);
            string linkbb = String.Format("Link biên bản: {0}", tb_LinkBienBan.Text);

            string listHeader = String.Empty;
            listHeader += String.Format("{0,-15}", "Mã biên bản");
            listHeader += String.Format("{0,-15}", "Mã hội đồng");
            listHeader += String.Format("{0,-15}", "Mã đề tài");
            listHeader += String.Format("{0,-15}", "Nhận xét");
            listHeader += String.Format("{0,-15}", "Tổng điểm");
            listHeader += String.Format("{0,-15}", "Link biên bản");


            Graphics graphic = e.Graphics;
            graphic.DrawString(" Biên bản nghiệm thu", new Font("Courier New", 18, FontStyle.Bold), new SolidBrush(Color.Red), startX, 0);
            graphic.DrawString(maBB, font, brush, startX, startY + 20);
            graphic.DrawString(maHD, font, brush, startX, startY + 40);
            graphic.DrawString(madetai, font, brush, startX, startY + 40);
            graphic.DrawString(nhanxet, font, brush, startX, startY + 40);
            graphic.DrawString(tongdiem, font, brush, startX, startY + 40);
            graphic.DrawString(linkbb, font, brush, startX, startY + 40);

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

        private void btn_DuyetGiaHan_Click(object sender, EventArgs e)
        {
            BUS_DONXINGIAHAN.Instance.DuyetGiaHan();
            BUS_DONXINGIAHAN.Instance.SetTrangThaiGiaHan();
        }

        private void btn_GiaHan_Click(object sender, EventArgs e)
        {
            tb_maDXGH.Text = BUS_DONXINGIAHAN.Instance.GetnextID().ToString();
            BUS_DONXINGIAHAN.Instance.GiaHanDeTai();
            BUS_DONXINGIAHAN.Instance.SetTrangThaiGiaHan();
            dgv_GiaHan.DataSource = BUS_DONXINGIAHAN.Instance.GetListDXGH();
        }

        private void dgv_GiaHan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                dt_NgayHoanThanh.Text = dgv_GiaHan.Rows[e.RowIndex].Cells["ngayHoanThanh"].Value.ToString();
                dt_NgayGH.Text = dgv_GiaHan.Rows[e.RowIndex].Cells["ngayGiaHan"].Value.ToString();
                tb_maGV4.Text = dgv_GiaHan.Rows[e.RowIndex].Cells["maGV4"].Value.ToString();
                tb_maDeTai3.Text = dgv_GiaHan.Rows[e.RowIndex].Cells["maDeTai4"].Value.ToString();
                tb_maDXGH.Text = dgv_GiaHan.Rows[e.RowIndex].Cells["maDonXinGiaHan"].Value.ToString();
                tb_linkDonXin.Text = dgv_GiaHan.Rows[e.RowIndex].Cells["linkDonXin"].Value.ToString();
             
            }
        }

        private void dgv_GiaHan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                dt_NgayHoanThanh.Text = dgv_GiaHan.Rows[e.RowIndex].Cells["ngayHoanThanh"].Value.ToString();
                dt_NgayGH.Text = dgv_GiaHan.Rows[e.RowIndex].Cells["ngayGiaHan"].Value.ToString();
                tb_maGV4.Text = dgv_GiaHan.Rows[e.RowIndex].Cells["maGV4"].Value.ToString();
                tb_maDeTai3.Text = dgv_GiaHan.Rows[e.RowIndex].Cells["maDeTai4"].Value.ToString();
                tb_maDXGH.Text = dgv_GiaHan.Rows[e.RowIndex].Cells["maDonXinGiaHan"].Value.ToString();
                tb_linkDonXin.Text = dgv_GiaHan.Rows[e.RowIndex].Cells["linkDonXin"].Value.ToString();
            
            }
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                tb_MaDT2.Text = guna2DataGridView1.Rows[e.RowIndex].Cells["maDeTai1"].Value.ToString();
                tb_TenDT2.Text = guna2DataGridView1.Rows[e.RowIndex].Cells["tenDeTai1"].Value.ToString();
                tb_LinhVuc2.Text = guna2DataGridView1.Rows[e.RowIndex].Cells["linhVuc1"].Value.ToString();
                cb_CapDo2.SelectedValue = guna2DataGridView1.Rows[e.RowIndex].Cells["capDo1"].Value.ToString();
                tb_MaGV3.Text = guna2DataGridView1.Rows[e.RowIndex].Cells["maGiangVien1"].Value.ToString();
                dt_NgTH2.Text = guna2DataGridView1.Rows[e.RowIndex].Cells["ngayThucHien1"].Value.ToString();
                tb_LinkDeTai1.Text = guna2DataGridView1.Rows[e.RowIndex].Cells["ngayThucHien1"].Value.ToString();
            }
        }

        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                tb_MaDT2.Text = guna2DataGridView1.Rows[e.RowIndex].Cells["maDeTai1"].Value.ToString();
                tb_TenDT2.Text = guna2DataGridView1.Rows[e.RowIndex].Cells["tenDeTai1"].Value.ToString();
                tb_LinhVuc2.Text = guna2DataGridView1.Rows[e.RowIndex].Cells["linhVuc1"].Value.ToString();
                cb_CapDo2.SelectedValue = guna2DataGridView1.Rows[e.RowIndex].Cells["capDo1"].Value.ToString();
                tb_MaGV3.Text = guna2DataGridView1.Rows[e.RowIndex].Cells["maGiangVien1"].Value.ToString();
                dt_NgTH2.Text = guna2DataGridView1.Rows[e.RowIndex].Cells["ngayThucHien1"].Value.ToString();
                tb_LinkDeTai1.Text = guna2DataGridView1.Rows[e.RowIndex].Cells["ngayThucHien1"].Value.ToString();
            }
        }

        private void btn_SuaDT_Click(object sender, EventArgs e)
        {
            BUS_DETAI.Instance.SuaDeTai();
            dgv_DeTai.DataSource = BUS_DETAI.Instance.GetListDeTai();
            
        }

        private void cb_Khoa1_SelectedIndexChanged(object sender, EventArgs e)
        {
            cb_Khoa1.DisplayMember = "tenKhoa";
            cb_Khoa1.ValueMember = "maKhoa";
        }
    }
}
