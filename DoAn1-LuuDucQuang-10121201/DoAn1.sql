create database QLMyPhamCuaCuaHangBanMyPham
go
use QLMyPhamCuaCuaHangBanMyPham
go



--Bang 1
create table DangNhap(
username char(50) primary key,
password char(50),
quyen nvarchar(50)
)
insert into DangNhap values ('1','1','nhanvien')

--Bang 2
create table NhanVien(
MaNV char(10) primary key,
TenNV varchar(50), 
GioiTinh nvarchar(50),
DiaChi nvarchar(50),
Sdt nvarchar(50))

select*from NhaCungCap
insert into NhanVien values ('001','Quang','Nam','HY','0154')


--Bang 3
create table NhaCungCap(
MaNCC char(10) primary key,
TenNCC varchar(50),
Diachi nvarchar(50),
Sdt nvarchar(50))


insert into NhaCungCap values('NCC01','Loreal','HY','011111')

--Bang 4
create table KhachHang(
MaKH char(10) primary key,
TenKH varchar(50),
GioiTinh nvarchar(50),
DiaChi nvarchar(50),
Sdt nvarchar(50))


insert into KhachHang values ('KH1','Teo','Nam','HY','032131')

--Bang 5
create table ThongTinMyPham(
MaMP char(10) primary key,
TenMP varchar(50),
MaNCC char(10) foreign key (MaNCC) references NhaCungCap(MaNCC) on delete cascade on update cascade,
Soluong nvarchar(50),
Giaban nvarchar(50))


insert into ThongTinMyPham values('M01','Tay trang','NCC01',2,1200)


--Bang 6
create table Hoadonnhap(
MaHDN char(10) primary key,
MaNV char(10) foreign key (MaNV) references Nhanvien(MaNV) on delete cascade on update cascade,
MaMP char(10) foreign key (MaMP) references ThongtinMyPham(MaMP) on delete cascade on update cascade,
MaNCC char(10) foreign key (MaNCC) references NhaCungCap(MaNCC) ,
Soluong nvarchar(50),
Ngayban nvarchar(50),
Diachi varchar(50),
Sdt nvarchar(50),
Dongia nvarchar(50),
Tongtien nvarchar(50))


insert into Hoadonnhap values ('HDN01','001','M01','NCC01',125,'2014-01-10','HN','1465676778',1005,125625)

--Bang 7
create table Hoadonban(
MaHDB char(10) primary key,
MaNV char(10) foreign key (MaNV)references Nhanvien(MaNV) on delete cascade on update cascade,
MaKH char(10) foreign key (MaKH) references Khachhang(MaKH) on delete cascade on update cascade,
MaMP char(10)foreign key (MaMP) references ThongtinMyPham(MaMP) on delete cascade on update cascade,
Soluong nvarchar(50),
Ngayban nvarchar(50),
Diachi varchar(50),
Sdt nvarchar(50), 
Dongia nvarchar(50),
Tongtien nvarchar(50))


insert into Hoadonban values ('HDB01','001','KH1','M01',1200,'2014-01-01','HY','1659939285',120,144000)






select*from ThongTinMyPham
select*from NhaCungCap
select*from Hoadonban
select*from Hoadonnhap
select*from NhanVien
select*from KhachHang