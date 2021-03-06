USE [master]
GO
/****** Object:  Database [QUANLYDETAI]    Script Date: 1/12/2021 5:45:59 PM ******/
CREATE DATABASE [QUANLYDETAI]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'QUANLYDETAI', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\QUANLYDETAI.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'QUANLYDETAI_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\QUANLYDETAI_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [QUANLYDETAI] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QUANLYDETAI].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QUANLYDETAI] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QUANLYDETAI] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QUANLYDETAI] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QUANLYDETAI] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QUANLYDETAI] SET ARITHABORT OFF 
GO
ALTER DATABASE [QUANLYDETAI] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [QUANLYDETAI] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QUANLYDETAI] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QUANLYDETAI] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QUANLYDETAI] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QUANLYDETAI] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QUANLYDETAI] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QUANLYDETAI] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QUANLYDETAI] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QUANLYDETAI] SET  ENABLE_BROKER 
GO
ALTER DATABASE [QUANLYDETAI] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QUANLYDETAI] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QUANLYDETAI] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QUANLYDETAI] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QUANLYDETAI] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QUANLYDETAI] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QUANLYDETAI] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QUANLYDETAI] SET RECOVERY FULL 
GO
ALTER DATABASE [QUANLYDETAI] SET  MULTI_USER 
GO
ALTER DATABASE [QUANLYDETAI] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QUANLYDETAI] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QUANLYDETAI] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QUANLYDETAI] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [QUANLYDETAI] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'QUANLYDETAI', N'ON'
GO
ALTER DATABASE [QUANLYDETAI] SET QUERY_STORE = OFF
GO
USE [QUANLYDETAI]
GO
/****** Object:  Table [dbo].[ACCOUNT]    Script Date: 1/12/2021 5:45:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ACCOUNT](
	[maAccount] [int] NOT NULL,
	[tenAccount] [varchar](255) NULL,
	[Email] [varchar](255) NULL,
	[Pass] [varchar](255) NULL,
	[Phone] [varchar](10) NULL,
	[maTypeAccount] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[maAccount] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BIENBANNGHIEMTHU]    Script Date: 1/12/2021 5:45:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BIENBANNGHIEMTHU](
	[maBienBan] [int] NOT NULL,
	[maHoiDong] [int] NULL,
	[maDeTai] [int] NULL,
	[tongDiem] [int] NULL,
	[nhanXet] [nvarchar](max) NULL,
	[linkBienBan] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[maBienBan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CHITIETDONXINGIAHAN]    Script Date: 1/12/2021 5:45:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CHITIETDONXINGIAHAN](
	[maCTDXGH] [int] NOT NULL,
	[ngayGiaHan] [date] NULL,
	[ngayHoanThanh] [date] NULL,
	[linkDonXin] [nvarchar](max) NULL,
	[isAccept] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[maCTDXGH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DETAI]    Script Date: 1/12/2021 5:45:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DETAI](
	[maDeTai] [int] NOT NULL,
	[tenDeTai] [nvarchar](255) NULL,
	[ngayThucHien] [date] NULL,
	[linhVuc] [nvarchar](255) NULL,
	[capDo] [nvarchar](50) NULL,
	[ketQua] [nvarchar](10) NULL,
	[linkDeTai] [nvarchar](max) NULL,
	[maTrangThai] [int] NULL,
	[maGiangVien] [int] NULL,
	[maHoiDong] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[maDeTai] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DONXINGIAHAN]    Script Date: 1/12/2021 5:45:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DONXINGIAHAN](
	[maDonXinGiaHan] [int] NOT NULL,
	[maGiangVien] [int] NULL,
	[maCTDXGH] [int] NULL,
	[maDeTai] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[maDonXinGiaHan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GIANGVIEN]    Script Date: 1/12/2021 5:45:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GIANGVIEN](
	[maGiangVien] [int] NOT NULL,
	[tenGiangVien] [nvarchar](255) NULL,
	[Nganh] [nvarchar](50) NULL,
	[trinhDo] [nvarchar](50) NULL,
	[ngaySinh] [date] NULL,
	[maHopDong] [int] NULL,
	[maAccount] [int] NULL,
	[maKhoa] [nvarchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[maGiangVien] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HOIDONGNGHIEMTHU]    Script Date: 1/12/2021 5:45:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HOIDONGNGHIEMTHU](
	[maHoiDong] [int] NOT NULL,
	[chuTichHoiDong] [nvarchar](255) NULL,
	[phanBien1] [nvarchar](255) NULL,
	[phanBien2] [nvarchar](255) NULL,
	[thuKi] [nvarchar](255) NULL,
	[ngayNghiemThu] [date] NULL,
	[maKhoa] [nvarchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[maHoiDong] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HOPDONG]    Script Date: 1/12/2021 5:45:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HOPDONG](
	[maHopDong] [int] IDENTITY(1,1) NOT NULL,
	[tenHopDong] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[maHopDong] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KHOA]    Script Date: 1/12/2021 5:45:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KHOA](
	[maKhoa] [nvarchar](10) NOT NULL,
	[tenKhoa] [nvarchar](1000) NULL,
PRIMARY KEY CLUSTERED 
(
	[maKhoa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TRANGTHAI]    Script Date: 1/12/2021 5:45:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TRANGTHAI](
	[maTrangThai] [int] IDENTITY(1,1) NOT NULL,
	[tenTrangThai] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[maTrangThai] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TYPEACCOUNT]    Script Date: 1/12/2021 5:45:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TYPEACCOUNT](
	[maTypeAccount] [int] IDENTITY(1,1) NOT NULL,
	[tenTypeAccount] [varchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[maTypeAccount] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[ACCOUNT] ([maAccount], [tenAccount], [Email], [Pass], [Phone], [maTypeAccount]) VALUES (1, N'Nguy?n Thành Ð?t', N'datnguyen777@gmail.com', N'1', N'0945135184', 1)
INSERT [dbo].[ACCOUNT] ([maAccount], [tenAccount], [Email], [Pass], [Phone], [maTypeAccount]) VALUES (2, N'Tr?n Thanh Lâm', N'thanhlam@gmail.com', N'1', N'0913758984', 1)
INSERT [dbo].[ACCOUNT] ([maAccount], [tenAccount], [Email], [Pass], [Phone], [maTypeAccount]) VALUES (3, N'Nguy?n Van A', N'nguyenvana@gmail.com', N'1', N'0945135186', 1)
INSERT [dbo].[ACCOUNT] ([maAccount], [tenAccount], [Email], [Pass], [Phone], [maTypeAccount]) VALUES (4, N'Nguy?n Van B', N'nguyenvanb@gmail.com', N'1', N'0913758987', 1)
INSERT [dbo].[ACCOUNT] ([maAccount], [tenAccount], [Email], [Pass], [Phone], [maTypeAccount]) VALUES (5, N'Nguy?n Van C', N'nguyenvanc@gmail.com', N'1', N'0913758988', 1)
INSERT [dbo].[ACCOUNT] ([maAccount], [tenAccount], [Email], [Pass], [Phone], [maTypeAccount]) VALUES (6, N'Luong Duy B?o', N'duybao@gmail.com', N'1', N'0782856984', 2)
INSERT [dbo].[ACCOUNT] ([maAccount], [tenAccount], [Email], [Pass], [Phone], [maTypeAccount]) VALUES (7, N'Tr?n Van A', N'tranvana@gmail.com', N'1', N'0782856995', 2)
INSERT [dbo].[BIENBANNGHIEMTHU] ([maBienBan], [maHoiDong], [maDeTai], [tongDiem], [nhanXet], [linkBienBan]) VALUES (1, 1, 1, 75, N'Tốt', NULL)
INSERT [dbo].[BIENBANNGHIEMTHU] ([maBienBan], [maHoiDong], [maDeTai], [tongDiem], [nhanXet], [linkBienBan]) VALUES (2, 2, 2, 67, N'Không tốt', NULL)
INSERT [dbo].[BIENBANNGHIEMTHU] ([maBienBan], [maHoiDong], [maDeTai], [tongDiem], [nhanXet], [linkBienBan]) VALUES (3, 1, 3, 90, N'Chưa hoàn thiện', NULL)
INSERT [dbo].[CHITIETDONXINGIAHAN] ([maCTDXGH], [ngayGiaHan], [ngayHoanThanh], [linkDonXin], [isAccept]) VALUES (1, CAST(N'2018-01-03' AS Date), CAST(N'2020-05-06' AS Date), NULL, 1)
INSERT [dbo].[DETAI] ([maDeTai], [tenDeTai], [ngayThucHien], [linhVuc], [capDo], [ketQua], [linkDeTai], [maTrangThai], [maGiangVien], [maHoiDong]) VALUES (1, N'TRI TUE NHAN TAO', CAST(N'2018-01-01' AS Date), N'AI', N'KHOA', N'DAT', NULL, 2, 3, 1)
INSERT [dbo].[DETAI] ([maDeTai], [tenDeTai], [ngayThucHien], [linhVuc], [capDo], [ketQua], [linkDeTai], [maTrangThai], [maGiangVien], [maHoiDong]) VALUES (2, N'MANG XA HOI CHO MEO', CAST(N'2020-05-06' AS Date), N'PHAN MEM', N'KHOA', N'DAT', NULL, 2, 1, 2)
INSERT [dbo].[DETAI] ([maDeTai], [tenDeTai], [ngayThucHien], [linhVuc], [capDo], [ketQua], [linkDeTai], [maTrangThai], [maGiangVien], [maHoiDong]) VALUES (3, N'MACH DEN CAY THONG NOEL', CAST(N'2019-10-12' AS Date), N'KTMT', N'KHOA', N'DAT', NULL, 2, 2, 1)
INSERT [dbo].[DETAI] ([maDeTai], [tenDeTai], [ngayThucHien], [linhVuc], [capDo], [ketQua], [linkDeTai], [maTrangThai], [maGiangVien], [maHoiDong]) VALUES (4, N'Facebook', CAST(N'2018-05-06' AS Date), N'Xã hội', N'Trường', N'Đạt', NULL, 5, 3, 2)
INSERT [dbo].[DETAI] ([maDeTai], [tenDeTai], [ngayThucHien], [linhVuc], [capDo], [ketQua], [linkDeTai], [maTrangThai], [maGiangVien], [maHoiDong]) VALUES (5, N'Instagram', CAST(N'2017-10-12' AS Date), N'Chat', N'Bộ', N'Không đạt', NULL, 5, 4, 1)
INSERT [dbo].[GIANGVIEN] ([maGiangVien], [tenGiangVien], [Nganh], [trinhDo], [ngaySinh], [maHopDong], [maAccount], [maKhoa]) VALUES (1, N'Nguyễn Thành Đạt', N'Phần mềm', N'Giáo sư', CAST(N'2000-07-06' AS Date), 1, 1, N'CNPM')
INSERT [dbo].[GIANGVIEN] ([maGiangVien], [tenGiangVien], [Nganh], [trinhDo], [ngaySinh], [maHopDong], [maAccount], [maKhoa]) VALUES (2, N'Trần Thanh Lâm', N'Phần cứng', N'Thạc Sĩ', CAST(N'2000-07-06' AS Date), 2, 2, N'KTMT')
INSERT [dbo].[GIANGVIEN] ([maGiangVien], [tenGiangVien], [Nganh], [trinhDo], [ngaySinh], [maHopDong], [maAccount], [maKhoa]) VALUES (3, N'Nguyễn Văn A', N'Toán Lí', N'Thạc Sĩ', CAST(N'2000-07-06' AS Date), 3, 3, N'KHMT')
INSERT [dbo].[GIANGVIEN] ([maGiangVien], [tenGiangVien], [Nganh], [trinhDo], [ngaySinh], [maHopDong], [maAccount], [maKhoa]) VALUES (4, N'Nguyễn Văn B', N'Khoa học', N'Thạc Sĩ', CAST(N'2000-07-06' AS Date), 2, 4, N'BMTL')
INSERT [dbo].[GIANGVIEN] ([maGiangVien], [tenGiangVien], [Nganh], [trinhDo], [ngaySinh], [maHopDong], [maAccount], [maKhoa]) VALUES (5, N'Nguyễn Văn C', N'Mạng', N'Thạc Sĩ', CAST(N'2000-07-06' AS Date), 1, 5, N'MMTT')
INSERT [dbo].[HOIDONGNGHIEMTHU] ([maHoiDong], [chuTichHoiDong], [phanBien1], [phanBien2], [thuKi], [ngayNghiemThu], [maKhoa]) VALUES (1, N'Trần Thanh Lâm', N'Lương Duy Bảo', N'Nguyễn Thành Đạt', N'Lê Thanh Trọng', CAST(N'2020-05-06' AS Date), N'CNPM')
INSERT [dbo].[HOIDONGNGHIEMTHU] ([maHoiDong], [chuTichHoiDong], [phanBien1], [phanBien2], [thuKi], [ngayNghiemThu], [maKhoa]) VALUES (2, N'Nguyễn Thành Đạt', N'Trần Thanh Lâm', N'LÊ Thanh Trọng', N'Lương Duy Bảo', CAST(N'2020-05-06' AS Date), N'CNPM')
SET IDENTITY_INSERT [dbo].[HOPDONG] ON 

INSERT [dbo].[HOPDONG] ([maHopDong], [tenHopDong]) VALUES (1, N'Biên ch?')
INSERT [dbo].[HOPDONG] ([maHopDong], [tenHopDong]) VALUES (2, N'Hợp đồng')
INSERT [dbo].[HOPDONG] ([maHopDong], [tenHopDong]) VALUES (3, N'Thỉnh giảng')
SET IDENTITY_INSERT [dbo].[HOPDONG] OFF
INSERT [dbo].[KHOA] ([maKhoa], [tenKhoa]) VALUES (N'BMTL', N'Bộ môn toán lí')
INSERT [dbo].[KHOA] ([maKhoa], [tenKhoa]) VALUES (N'CNPM', N'Công nghệ phần mềm')
INSERT [dbo].[KHOA] ([maKhoa], [tenKhoa]) VALUES (N'KHMT', N'Khoa học máy tính')
INSERT [dbo].[KHOA] ([maKhoa], [tenKhoa]) VALUES (N'KTMT', N'Kĩ thuật máy tính')
INSERT [dbo].[KHOA] ([maKhoa], [tenKhoa]) VALUES (N'MMTT', N'Mạng máy tính')
SET IDENTITY_INSERT [dbo].[TRANGTHAI] ON 

INSERT [dbo].[TRANGTHAI] ([maTrangThai], [tenTrangThai]) VALUES (1, N'DA DANG KI')
INSERT [dbo].[TRANGTHAI] ([maTrangThai], [tenTrangThai]) VALUES (2, N'DA DUYET DANG KI')
INSERT [dbo].[TRANGTHAI] ([maTrangThai], [tenTrangThai]) VALUES (3, N'DA HUY')
INSERT [dbo].[TRANGTHAI] ([maTrangThai], [tenTrangThai]) VALUES (4, N'DA GIA HAN')
INSERT [dbo].[TRANGTHAI] ([maTrangThai], [tenTrangThai]) VALUES (5, N'DA NGHIEM THU')
INSERT [dbo].[TRANGTHAI] ([maTrangThai], [tenTrangThai]) VALUES (6, N'CHO DUYET GIA HAN')
SET IDENTITY_INSERT [dbo].[TRANGTHAI] OFF
SET IDENTITY_INSERT [dbo].[TYPEACCOUNT] ON 

INSERT [dbo].[TYPEACCOUNT] ([maTypeAccount], [tenTypeAccount]) VALUES (1, N'Gi?ng Vien')
INSERT [dbo].[TYPEACCOUNT] ([maTypeAccount], [tenTypeAccount]) VALUES (2, N'Cán b?')
SET IDENTITY_INSERT [dbo].[TYPEACCOUNT] OFF
ALTER TABLE [dbo].[ACCOUNT]  WITH CHECK ADD FOREIGN KEY([maTypeAccount])
REFERENCES [dbo].[TYPEACCOUNT] ([maTypeAccount])
GO
ALTER TABLE [dbo].[BIENBANNGHIEMTHU]  WITH CHECK ADD FOREIGN KEY([maHoiDong])
REFERENCES [dbo].[HOIDONGNGHIEMTHU] ([maHoiDong])
GO
ALTER TABLE [dbo].[DETAI]  WITH CHECK ADD FOREIGN KEY([maGiangVien])
REFERENCES [dbo].[GIANGVIEN] ([maGiangVien])
GO
ALTER TABLE [dbo].[DETAI]  WITH CHECK ADD FOREIGN KEY([maHoiDong])
REFERENCES [dbo].[HOIDONGNGHIEMTHU] ([maHoiDong])
GO
ALTER TABLE [dbo].[DETAI]  WITH CHECK ADD FOREIGN KEY([maTrangThai])
REFERENCES [dbo].[TRANGTHAI] ([maTrangThai])
GO
ALTER TABLE [dbo].[DONXINGIAHAN]  WITH CHECK ADD FOREIGN KEY([maCTDXGH])
REFERENCES [dbo].[CHITIETDONXINGIAHAN] ([maCTDXGH])
GO
ALTER TABLE [dbo].[DONXINGIAHAN]  WITH CHECK ADD FOREIGN KEY([maDeTai])
REFERENCES [dbo].[DETAI] ([maDeTai])
GO
ALTER TABLE [dbo].[DONXINGIAHAN]  WITH CHECK ADD FOREIGN KEY([maGiangVien])
REFERENCES [dbo].[GIANGVIEN] ([maGiangVien])
GO
ALTER TABLE [dbo].[GIANGVIEN]  WITH CHECK ADD FOREIGN KEY([maAccount])
REFERENCES [dbo].[ACCOUNT] ([maAccount])
GO
ALTER TABLE [dbo].[GIANGVIEN]  WITH CHECK ADD FOREIGN KEY([maHopDong])
REFERENCES [dbo].[HOPDONG] ([maHopDong])
GO
ALTER TABLE [dbo].[GIANGVIEN]  WITH CHECK ADD FOREIGN KEY([maKhoa])
REFERENCES [dbo].[KHOA] ([maKhoa])
GO
ALTER TABLE [dbo].[HOIDONGNGHIEMTHU]  WITH CHECK ADD FOREIGN KEY([maKhoa])
REFERENCES [dbo].[KHOA] ([maKhoa])
GO
USE [master]
GO
ALTER DATABASE [QUANLYDETAI] SET  READ_WRITE 
GO
