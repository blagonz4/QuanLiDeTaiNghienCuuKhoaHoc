namespace QuanLyDeTaiKhoaHoc.GUI
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabmain = new System.Windows.Forms.TabControl();
            this.tab_DKDT = new System.Windows.Forms.TabPage();
            this.tab_DDT = new System.Windows.Forms.TabPage();
            this.tab_QLDT = new System.Windows.Forms.TabPage();
            this.tab_QLGV = new System.Windows.Forms.TabPage();
            this.tab_NTDT = new System.Windows.Forms.TabPage();
            this.tab_BCTH = new System.Windows.Forms.TabPage();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.tabmain.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabmain
            // 
            this.tabmain.Controls.Add(this.tab_DKDT);
            this.tabmain.Controls.Add(this.tab_DDT);
            this.tabmain.Controls.Add(this.tab_QLDT);
            this.tabmain.Controls.Add(this.tab_QLGV);
            this.tabmain.Controls.Add(this.tab_NTDT);
            this.tabmain.Controls.Add(this.tab_BCTH);
            this.tabmain.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabmain.Location = new System.Drawing.Point(0, 1);
            this.tabmain.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.tabmain.Name = "tabmain";
            this.tabmain.SelectedIndex = 0;
            this.tabmain.Size = new System.Drawing.Size(1239, 709);
            this.tabmain.TabIndex = 0;
            // 
            // tab_DKDT
            // 
            this.tab_DKDT.Location = new System.Drawing.Point(4, 34);
            this.tab_DKDT.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.tab_DKDT.Name = "tab_DKDT";
            this.tab_DKDT.Padding = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.tab_DKDT.Size = new System.Drawing.Size(1231, 671);
            this.tab_DKDT.TabIndex = 0;
            this.tab_DKDT.Text = "Đăng kí đề tài";
            this.tab_DKDT.UseVisualStyleBackColor = true;
            // 
            // tab_DDT
            // 
            this.tab_DDT.Location = new System.Drawing.Point(4, 34);
            this.tab_DDT.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.tab_DDT.Name = "tab_DDT";
            this.tab_DDT.Padding = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.tab_DDT.Size = new System.Drawing.Size(1231, 671);
            this.tab_DDT.TabIndex = 1;
            this.tab_DDT.Text = "Duyệt đề tài";
            this.tab_DDT.UseVisualStyleBackColor = true;
            // 
            // tab_QLDT
            // 
            this.tab_QLDT.Location = new System.Drawing.Point(4, 34);
            this.tab_QLDT.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.tab_QLDT.Name = "tab_QLDT";
            this.tab_QLDT.Padding = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.tab_QLDT.Size = new System.Drawing.Size(1231, 671);
            this.tab_QLDT.TabIndex = 2;
            this.tab_QLDT.Text = "Quản lí đề tài";
            this.tab_QLDT.UseVisualStyleBackColor = true;
            // 
            // tab_QLGV
            // 
            this.tab_QLGV.Location = new System.Drawing.Point(4, 34);
            this.tab_QLGV.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.tab_QLGV.Name = "tab_QLGV";
            this.tab_QLGV.Padding = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.tab_QLGV.Size = new System.Drawing.Size(1231, 671);
            this.tab_QLGV.TabIndex = 3;
            this.tab_QLGV.Text = "Quản lí giảng viên";
            this.tab_QLGV.UseVisualStyleBackColor = true;
            // 
            // tab_NTDT
            // 
            this.tab_NTDT.Location = new System.Drawing.Point(4, 34);
            this.tab_NTDT.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.tab_NTDT.Name = "tab_NTDT";
            this.tab_NTDT.Padding = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.tab_NTDT.Size = new System.Drawing.Size(1231, 671);
            this.tab_NTDT.TabIndex = 4;
            this.tab_NTDT.Text = "Nghiệm thu đề tài";
            this.tab_NTDT.UseVisualStyleBackColor = true;
            // 
            // tab_BCTH
            // 
            this.tab_BCTH.Location = new System.Drawing.Point(4, 34);
            this.tab_BCTH.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.tab_BCTH.Name = "tab_BCTH";
            this.tab_BCTH.Padding = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.tab_BCTH.Size = new System.Drawing.Size(1231, 671);
            this.tab_BCTH.TabIndex = 5;
            this.tab_BCTH.Text = "Báo cáo tổng hợp";
            this.tab_BCTH.UseVisualStyleBackColor = true;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1240, 711);
            this.Controls.Add(this.tabmain);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "frmMain";
            this.Text = "Quản lí đề tài nghiên cứu khoa học";
            this.tabmain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabmain;
        private System.Windows.Forms.TabPage tab_DKDT;
        private System.Windows.Forms.TabPage tab_DDT;
        private System.Windows.Forms.TabPage tab_QLDT;
        private System.Windows.Forms.TabPage tab_QLGV;
        private System.Windows.Forms.TabPage tab_NTDT;
        private System.Windows.Forms.TabPage tab_BCTH;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}