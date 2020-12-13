CREATE DATABASE QUANLYDETAI
USE QUANLYDETAI

CREATE TABLE TYPEACCOUNT(
    maTypeAccount int NOT NULL IDENTITY(1,1) PRIMARY KEY,
    tenTypeAccount varchar(255),
);

CREATE TABLE ACCOUNT(
    maAccount int NOT NULL IDENTITY(1,1) PRIMARY KEY,
    tenAccount varchar(255),
	Email varchar(255),
	password varchar(255),
	Phone varchar(10),
	maTypeAccount int,
	FOREIGN KEY (maTypeAccount) REFERENCES TypeAccount(maTypeAccount)
);

CREATE TABLE HOPDONG(
	maHopDong int NOT NULL IDENTITY(1,1) PRIMARY KEY,
	tenHopDong varchar(50),
);

CREATE TABLE KHOA(
	maKhoa int NOT NULL IDENTITY(1,1) PRIMARY KEY,
	tenKhoa varchar(50),
);

CREATE TABLE GIANGVIEN(
	maGiangVien int NOT NULL IDENTITY(1,1) PRIMARY KEY,
	tenGiangVien varchar(255),
	Nganh varchar(50),
	maHopDong int,
	maAccount int,
	maKhoa int,
	FOREIGN KEY (maHopDOng) REFERENCES HOPDONG(maHopDong),
	FOREIGN KEY (maAccount) REFERENCES Account(maAccount),
	FOREIGN KEY (maKhoa) REFERENCES KHOA(maKhoa),
);

CREATE TABLE TRANGTHAI(
	maTrangThai int NOT NULL IDENTITY(1,1) PRIMARY KEY,
	tenTrangThai varchar(50),
); 

CREATE TABLE DETAI(
	maDeTai int NOT NULL IDENTITY(1,1) PRIMARY KEY,
	tenDeTai varchar(255),
	ngayThucHien date,
	linhVuc varchar(255),
	capDo varchar(50),
	ketQua varchar(10),
	maTrangThai int,
	maGiangVien int,
	FOREIGN KEY (maTrangThai) REFERENCES TRANGTHAI(maTrangThai),
	FOREIGN KEY (maGiangVien) REFERENCES GIANGVIEN(maGiangVien),
);

CREATE TABLE CHITIETDONXINGIAHAN(
	maCTDXGH int NOT NULL IDENTITY(1,1) PRIMARY KEY,
	ngayGiaHan date,
	ngayHoanThanh date,
	isAccept int, /* 0 la bi huy, 1 la dc accept, 2 la pending */
);

CREATE TABLE DONXINGIAHAN (
	maDonXinGiaHan int NOT NULL IDENTITY(1,1) PRIMARY KEY,
	maGiangVien int,
	maCTDXGH int,
	FOREIGN KEY (maGiangVien) REFERENCES GIANGVIEN(maGiangVien),
	FOREIGN KEY (maCTDXGH) REFERENCES CHITIETDONXINGIAHAN(maCTDXGH),
);

ALTER TABLE DONXINGIAHAN ADD linkDonXin varchar(max);

CREATE TABLE HOIDONGNGHIEMTHU(
	maHoiDong int NOT NULL IDENTITY(1,1) PRIMARY KEY,
	chuTichHoiDong varchar(255),
	phanBien1 varchar(255),
	phanBien2 varchar(255),
	thuKi varchar(255),
	ngayNghiemThu date,
	maKhoa int,
	FOREIGN KEY (maKhoa) REFERENCES KHOA(maKhoa),
);

CREATE TABLE BIENBANNGHIEMTHU(
	maBienBan int NOT NULL IDENTITY(1,1) PRIMARY KEY,
	maHoiDong int,
	tongDiem int,
	nhanXet varchar(max),
	FOREIGN KEY (maHoiDong) REFERENCES HOIDONGNGHIEMTHU(maHoiDong),
);
ALTER TABLE BIENBANNGHIEMTHU ADD linkBienBan varchar(max);
