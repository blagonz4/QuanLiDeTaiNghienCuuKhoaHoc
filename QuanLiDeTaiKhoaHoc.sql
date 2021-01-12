CREATE DATABASE QUANLYDETAI
USE QUANLYDETAI

CREATE TABLE TYPEACCOUNT(
    maTypeAccount int NOT NULL IDENTITY(1,1) PRIMARY KEY,
    tenTypeAccount varchar(255),
);

CREATE TABLE ACCOUNT(
    maAccount int NOT NULL PRIMARY KEY,
    tenAccount varchar(255),
	Email varchar(255),
	Pass varchar(255),
	Phone varchar(10),
	maTypeAccount int,
	FOREIGN KEY (maTypeAccount) REFERENCES TypeAccount(maTypeAccount)
);

CREATE TABLE HOPDONG(
	maHopDong int NOT NULL IDENTITY(1,1) PRIMARY KEY,
	tenHopDong nvarchar(50),
);
CREATE TABLE KHOA(
	maKhoa nvarchar(10) NOT NULL PRIMARY KEY,
	tenKhoa nvarchar(1000),
);

CREATE TABLE GIANGVIEN(
	maGiangVien int NOT NULL  PRIMARY KEY,
	tenGiangVien nvarchar(255),
	Nganh nvarchar(50),
	trinhDo nvarchar(50),
	ngaySinh date,
	maHopDong int,
	maAccount int,
	maKhoa nvarchar(10),
	FOREIGN KEY (maHopDong) REFERENCES HOPDONG(maHopDong),
	FOREIGN KEY (maAccount) REFERENCES Account(maAccount),
	FOREIGN KEY (maKhoa) REFERENCES KHOA(maKhoa),
);

CREATE TABLE TRANGTHAI(
	maTrangThai int NOT NULL IDENTITY(1,1) PRIMARY KEY,
	tenTrangThai nvarchar(50),
); 

CREATE TABLE DETAI(
	maDeTai int NOT NULL  PRIMARY KEY,
	tenDeTai nvarchar(255),
	ngayThucHien date,
	linhVuc nvarchar(255),
	capDo nvarchar(50),
	ketQua nvarchar(10),
	linkDeTai nvarchar(max),
	maTrangThai int,
	maGiangVien int,
	maHoiDong int,
	FOREIGN KEY (maTrangThai) REFERENCES TRANGTHAI(maTrangThai),
	FOREIGN KEY (maGiangVien) REFERENCES GIANGVIEN(maGiangVien),
	FOREIGN KEY (maHoiDong) REFERENCES HOIDONGNGHIEMTHU(maHoiDong),
);



CREATE TABLE CHITIETDONXINGIAHAN(
	maCTDXGH int NOT NUll  PRIMARY KEY,
	ngayGiaHan date,
	ngayHoanThanh date,
	linkDonXin nvarchar(max),
	isAccept int, /* 0 la bi huy, 1 la dc accept, 2 la pending */
);

CREATE TABLE DONXINGIAHAN (
	maDonXinGiaHan int NOT NULL PRIMARY KEY,
	maGiangVien int,
	maCTDXGH int,
	maDeTai int,
	FOREIGN KEY (maGiangVien) REFERENCES GIANGVIEN(maGiangVien),
	FOREIGN KEY (maCTDXGH) REFERENCES CHITIETDONXINGIAHAN(maCTDXGH),
	FOREIGN KEY (maDeTai) REFERENCES DeTai(maDeTai)
);



CREATE TABLE HOIDONGNGHIEMTHU(
	maHoiDong int NOT NULL PRIMARY KEY,
	chuTichHoiDong nvarchar(255),
	phanBien1 nvarchar(255),
	phanBien2 nvarchar(255),
	thuKi nvarchar(255),
	ngayNghiemThu date,
	maKhoa nvarchar(10),
	FOREIGN KEY (maKhoa) REFERENCES KHOA(maKhoa),
);
CREATE TABLE BIENBANNGHIEMTHU(
	maBienBan int NOT NULL PRIMARY KEY,
	maHoiDong int,
	maDeTai int,
	tongDiem int,
	nhanXet nvarchar(max),
	linkBienBan nvarchar(max),
	FOREIGN KEY (maHoiDong) REFERENCES HOIDONGNGHIEMTHU(maHoiDong),
);

-- Loại tài khoản

INSERT [dbo].[TYPEACCOUNT] ([tenTypeAccount]) VALUES (N'Giảng Vien')
INSERT [dbo].[TYPEACCOUNT] ([tenTypeAccount]) VALUES ( N'Cán bộ')

-- Tài khoản

INSERT [dbo].[ACCOUNT] ([maAccount], [tenAccount], [Email], [Pass], [Phone], [maTypeAccount]) VALUES (1, N'Nguy?n Thành Ð?t', N'datnguyen777@gmail.com', N'1', N'0945135184', 1)
INSERT [dbo].[ACCOUNT] ([maAccount], [tenAccount], [Email], [Pass], [Phone], [maTypeAccount]) VALUES (2, N'Tr?n Thanh Lâm', N'thanhlam@gmail.com', N'1', N'0913758984', 1)
INSERT [dbo].[ACCOUNT] ([maAccount], [tenAccount], [Email], [Pass], [Phone], [maTypeAccount]) VALUES (3, N'Nguyễn Văn A', N'nguyenvana@gmail.com', N'1', N'0945135186', 1)
INSERT [dbo].[ACCOUNT] ([maAccount], [tenAccount], [Email], [Pass], [Phone], [maTypeAccount]) VALUES (4, N'Nguyễn Văn B', N'nguyenvanb@gmail.com', N'1', N'0913758987', 1)
INSERT [dbo].[ACCOUNT] ([maAccount], [tenAccount], [Email], [Pass], [Phone], [maTypeAccount]) VALUES (5, N'Nguyễn Văn C', N'nguyenvanc@gmail.com', N'1', N'0913758988', 1)


INSERT [dbo].[ACCOUNT] ([maAccount], [tenAccount], [Email], [Pass], [Phone], [maTypeAccount]) VALUES (6, N'Lương Duy Bảo', N'duybao@gmail.com', N'1', N'0782856984', 2)
INSERT [dbo].[ACCOUNT] ([maAccount], [tenAccount], [Email], [Pass], [Phone], [maTypeAccount]) VALUES (7, N'Trần Văn A', N'tranvana@gmail.com', N'1', N'0782856995', 2)


-- Hợp đồng

INSERT into HOPDONG( tenHopDong) values ('Biên chế')
INSERT [dbo].[HOPDONG] ([tenHopDong]) VALUES ( N'Hợp đồng')
INSERT [dbo].[HOPDONG] ([tenHopDong]) VALUES (N'Thỉnh giảng')

-- Giảng viên

INSERT [dbo].[GIANGVIEN] ([maGiangVien], [tenGiangVien], [Nganh], [trinhDo], [ngaySinh], [maHopDong], [maAccount], [maKhoa]) VALUES (1, N'Nguyễn Thành Đạt', N'Phần mềm', N'Giáo sư', CAST(N'2000-07-06' AS Date), 1, 1, N'CNPM')
INSERT [dbo].[GIANGVIEN] ([maGiangVien], [tenGiangVien], [Nganh], [trinhDo], [ngaySinh], [maHopDong], [maAccount], [maKhoa]) VALUES (2, N'Trần Thanh Lâm', N'Phần cứng', N'Thạc Sĩ', CAST(N'2000-07-06' AS Date), 2, 2, N'KTMT')
INSERT [dbo].[GIANGVIEN] ([maGiangVien], [tenGiangVien], [Nganh], [trinhDo], [ngaySinh], [maHopDong], [maAccount], [maKhoa]) VALUES (3, N'Nguyễn Văn A', N'Toán Lí', N'Thạc Sĩ', CAST(N'2000-07-06' AS Date), 3, 3, N'KHMT')
INSERT [dbo].[GIANGVIEN] ([maGiangVien], [tenGiangVien], [Nganh], [trinhDo], [ngaySinh], [maHopDong], [maAccount], [maKhoa]) VALUES (4, N'Nguyễn Văn B', N'Khoa học', N'Thạc Sĩ', CAST(N'2000-07-06' AS Date), 2, 4, N'BMTL')
INSERT [dbo].[GIANGVIEN] ([maGiangVien], [tenGiangVien], [Nganh], [trinhDo], [ngaySinh], [maHopDong], [maAccount], [maKhoa]) VALUES (5, N'Nguyễn Văn C', N'Mạng', N'Thạc Sĩ', CAST(N'2000-07-06' AS Date), 1, 5, N'MMTT')

-- Trạng thái

INSERT [dbo].[TRANGTHAI] ( [tenTrangThai]) VALUES (N'DA DANG KI')
INSERT [dbo].[TRANGTHAI] ( [tenTrangThai]) VALUES ( N'DA DUYET DANG KI')
INSERT [dbo].[TRANGTHAI] ( [tenTrangThai]) VALUES ( N'DA HUY')
INSERT [dbo].[TRANGTHAI] ( [tenTrangThai]) VALUES ( N'DA GIA HAN')
INSERT [dbo].[TRANGTHAI] ( [tenTrangThai]) VALUES ( N'DA NGHIEM THU')
INSERT [dbo].[TRANGTHAI] ( [tenTrangThai]) VALUES ( N'CHO DUYET GIA HAN')

-- Khoa


insert into KHOA(maKhoa,tenKhoa) values ('CNPM',N'Công nghệ phần mềm') 
insert into KHOA(maKhoa,tenKhoa) values ('KHMT', N'Khoa học máy tính')
insert into KHOA(maKhoa,tenKhoa) values ('KTMT', N'Kĩ thuật máy tính')
insert into KHOA(maKhoa,tenKhoa) values ('MMTT', N'Mạng máy tính')
insert into KHOA(maKhoa,tenKhoa) values ('BMTL', N'Bộ môn toán lí')

-- Hội đồng

insert into HOIDONGNGHIEMTHU(maHoiDong,chuTichHoiDong, phanBien1,phanBien2,thuKi, ngayNghiemThu, maKhoa) values( '1',N'Trần Thanh Lâm',N'Lương Duy Bảo',N'Nguyễn Thành Đạt',N'Lê Thanh Trọng',CAST(N'2020-05-06T00:00:00.000' AS DateTime),'CNPM')
insert into HOIDONGNGHIEMTHU(maHoiDong,chuTichHoiDong, phanBien1,phanBien2,thuKi, ngayNghiemThu, maKhoa) values( '2',N'Nguyễn Thành Đạt',N'Trần Thanh Lâm',N'LÊ Thanh Trọng',N'Lương Duy Bảo',CAST(N'2020-05-06T00:00:00.000' AS DateTime),'CNPM')

-- Đề tài 
INSERT [dbo].[DETAI] ([maDeTai], [tenDeTai], [ngayThucHien], [linhVuc], [capDo], [ketQua], [linkDeTai], [maTrangThai], [maGiangVien], [maHoiDong]) VALUES (1, N'TRI TUE NHAN TAO', CAST(N'2018-01-01' AS Date), N'AI', N'KHOA', N'DAT', NULL, 2, 3, 1)
INSERT [dbo].[DETAI] ([maDeTai], [tenDeTai], [ngayThucHien], [linhVuc], [capDo], [ketQua], [linkDeTai], [maTrangThai], [maGiangVien], [maHoiDong]) VALUES (2, N'MANG XA HOI CHO MEO', CAST(N'2020-05-06' AS Date), N'PHAN MEM', N'KHOA', N'DAT', NULL, 2, 1, 2)
INSERT [dbo].[DETAI] ([maDeTai], [tenDeTai], [ngayThucHien], [linhVuc], [capDo], [ketQua], [linkDeTai], [maTrangThai], [maGiangVien], [maHoiDong]) VALUES (3, N'MACH DEN CAY THONG NOEL', CAST(N'2019-10-12' AS Date), N'KTMT', N'KHOA', N'DAT', NULL, 2, 2, 1)
INSERT [dbo].[DETAI] ([maDeTai], [tenDeTai], [ngayThucHien], [linhVuc], [capDo], [ketQua], [linkDeTai], [maTrangThai], [maGiangVien], [maHoiDong]) VALUES (4, N'Facebook', CAST(N'2018-05-06' AS Date), N'Xã hội', N'Trường', N'Đạt', NULL, 5, 3, 2)
INSERT [dbo].[DETAI] ([maDeTai], [tenDeTai], [ngayThucHien], [linhVuc], [capDo], [ketQua], [linkDeTai], [maTrangThai], [maGiangVien], [maHoiDong]) VALUES (5, N'Instagram', CAST(N'2017-10-12' AS Date), N'Chat', N'Bộ', N'Không đạt', NULL, 5, 4, 1)	


-- Biên bản nghiệm thu
INSERT [dbo].[BIENBANNGHIEMTHU] ([maBienBan], [maHoiDong], [tongDiem], [nhanXet], [linkBienBan], [maDeTai]) VALUES (1, 1, 75, N'Tốt', NULL, 1)
INSERT [dbo].[BIENBANNGHIEMTHU] ([maBienBan], [maHoiDong], [tongDiem], [nhanXet], [linkBienBan], [maDeTai]) VALUES (2, 2, 67, N'Không tốt', NULL, 2)
INSERT [dbo].[BIENBANNGHIEMTHU] ([maBienBan], [maHoiDong], [tongDiem], [nhanXet], [linkBienBan], [maDeTai]) VALUES (3, 1, 90, N'Chưa hoàn thiện', NULL, 3)


-- Đơn xin gia hạn

INSERT [dbo].[CHITIETDONXINGIAHAN] ([maCTDXGH], [ngayGiaHan], [ngayHoanThanh],[linkDonXin] ,[isAccept]) VALUES (1, CAST(N'2018-01-03' AS Date), CAST(N'2020-05-06' AS Date), NULL, 1)

INSERT [dbo].[DONXINGIAHAN] ([maDonXinGiaHan], [maGiangVien], [maCTDXGH], [maDeTai]) VALUES (1, 1, 1 ,N'1')






