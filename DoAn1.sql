create database QLMyPhamCuaCuaHangBanMyPham
go
use QLMyPhamCuaCuaHangBanMyPham
go


--Bang 1
create table DangNhap(
username nvarchar(50) primary key,
password nvarchar(50),
quyen nvarchar(50)
)
insert into DangNhap values ('1','1','quản lý')
insert into DangNhap values ('2','2','nhân viên')

--Bang 2
create table NhanVien(
MaNV nvarchar(10) primary key,
TenNV nvarchar(50), 
GioiTinh nvarchar(50),
DiaChi nvarchar(50),
Sdt nvarchar(20))

insert into NhanVien values ('001','Quang','Nam','HY','0154')


--Bang 3
create table NhaCungCap(
MaNCC nvarchar(10) primary key,
TenNCC nvarchar(50),
Diachi nvarchar(50),
Sdt nvarchar(20))


insert into NhaCungCap values('NCC01','Loreal','HY','011111')

--Bang 4
create table KhachHang(
MaKH nvarchar(10) primary key,
TenKH nvarchar(50),
GioiTinh nvarchar(20),
DiaChi nvarchar(50),
Sdt nvarchar(20))


insert into KhachHang values ('KH1','Teo','Nam','HY','032131')

--Bang 5
create table LoaiMyPham(
MaloaiMP nvarchar(50) primary key,
TenloaiMP nvarchar(50))

insert into LoaiMyPham values ('SR1','Serum')

--Bang 6
create table ThongTinMyPham(
MaMP nvarchar(10) primary key,
TenMP nvarchar(50),
Dungtich nvarchar(20),
MaloaiMP nvarchar(50) foreign key (MaloaiMP) references LoaiMyPham(MaloaiMP) on delete cascade on update cascade,
MaNCC nvarchar(10) foreign key (MaNCC) references NhaCungCap(MaNCC) on delete cascade on update cascade,
Giaban int,
Mota nvarchar(500)
)

insert into ThongTinMyPham values('M01','Tay trang','400ml','SR1','NCC01',100000,'khong')


--Bang 7
create table Hoadonnhap(
MaHDN nvarchar(10) primary key,
MaNV nvarchar(10) foreign key (MaNV) references Nhanvien(MaNV) on delete cascade on update cascade,
Ngaynhap datetime)

insert into Hoadonnhap values ('HDN01','001','2014-01-10')


drop table Hoadonnhap



--Bang 9
create table Hoadonban(
MaHDB nvarchar(10) primary key,
MaNV nvarchar(10) foreign key (MaNV)references Nhanvien(MaNV) on delete cascade on update cascade,
MaKH nvarchar(10) foreign key (MaKH) references Khachhang(MaKH) on delete cascade on update cascade,
Ngayban datetime)


insert into Hoadonban values ('HDB01','001','KH1','2014-01-01')
insert into Hoadonban values ('HDB02','001','KH1','2014-01-01')


--Bang11
create table Tonkho(
MaMP nvarchar(10) primary key foreign key (MaMP) references ThongTinMyPham(MaMP) on delete cascade on update cascade,
SLton int
)


insert into Tonkho values ('M01',10)


delete from Tonkho



--Bang 8
create table ChitietHDN(
ID nvarchar(10) primary key,
MaHDN nvarchar(10) foreign key (MaHDN)references Hoadonnhap(MaHDN) on delete cascade on update cascade,
MaMP nvarchar(10)foreign key (MaMP) references ThongtinMyPham(MaMP) on delete cascade on update cascade,
Soluong int,
Dongia int,
Tongtien int
)

insert into ChitietHDN values ('1','HDN01','M01',125,10000,100000)



--bang 10
create table ChitietHDB(
ID nvarchar(10) primary key,
MaHDB nvarchar(10) foreign key (MaHDB)references Hoadonban(MaHDB) on delete cascade on update cascade,
MaMP nvarchar(10)foreign key (MaMP) references ThongtinMyPham(MaMP) on delete cascade on update cascade,
Soluong int,
Dongia int,
Tongtien int
)

insert into ChitietHDB values ('1','HDB01','M01',125,1000,1111111)


drop table ChitietHDB
drop table ChitietHDN

-----------------------------------------------------------------
CREATE PROCEDURE SP_SPbanchay
AS
BEGIN
    SELECT TMP.*
    FROM ThongTinMyPham TMP
    INNER JOIN (
        SELECT TOP 10 CTHDB.MaMP
        FROM ChitietHDB CTHDB
        GROUP BY CTHDB.MaMP
        ORDER BY SUM(CTHDB.Soluong) DESC
    ) BestSelling ON TMP.MaMP = BestSelling.MaMP
END

exec SP_SPbanchay


--SELECT M.MaMP, M.TenMP, M.Dungtich,M.MaloaiMP,M.MaNCC,M.Giaban,M.Mota, SUM(B.Soluong) AS TongSoluong
--from ThongTinMyPham M
--inner join ChitietHDB B
--on M.MaMP = B.MaMP
--group by M.MaMP, M.TenMP, M.Dungtich,M.MaloaiMP,M.MaNCC,M.Giaban,M.Mota
--order by sum(B.Soluong) desc





-----------------------------------------------------------------

CREATE PROCEDURE SP_SPbancham
AS
BEGIN
    SELECT TMP.*
    FROM ThongTinMyPham TMP
    INNER JOIN (
        SELECT TOP 10 CTHDB.MaMP
        FROM ChitietHDB CTHDB
        GROUP BY CTHDB.MaMP
        ORDER BY SUM(CTHDB.Soluong) ASC
    ) BestSelling ON TMP.MaMP = BestSelling.MaMP
END

exec SP_SPbancham

-----------------------------------------------------------------

CREATE PROCEDURE SP_SPsaphet
AS
BEGIN
    SELECT TMP.*
    FROM ThongTinMyPham TMP
    INNER JOIN (
        SELECT TK.MaMP
        FROM Tonkho TK
        WHere TK.SLton < 10
    ) BestSelling ON TMP.MaMP = BestSelling.MaMP
END

exec SP_SPsaphet

-----------------------------------------------------------------

alter PROCEDURE SP_Timthoigian
    @StartDate DATETIME,
    @EndDate DATETIME
AS
BEGIN
    SELECT CTB.ID, CTB.MaHDB, CTB.MaMP, CTB.Soluong, CTB.Dongia, CTB.Tongtien
    FROM ChitietHDB CTB inner join Hoadonban HDB ON 
	CTB.MaHDB = HDB.MaHDB
    WHERE HDB.Ngayban >= @StartDate AND HDB.Ngayban <= @EndDate
END

EXEC SP_Timthoigian '2023-01-01', '2023-05-31'


-----------------------------------------------------------------

alter PROCEDURE SP_TimthoigianHDN
    @StartDate DATETIME,
    @EndDate DATETIME
AS
BEGIN
    SELECT CTN.ID, CTN.MaHDN, CTN.MaMP, CTN.Soluong, CTN.Dongia, CTN.Tongtien
    FROM ChitietHDN CTN inner join Hoadonnhap HDN ON 
	CTN.MaHDN = HDN.MaHDN    WHERE HDN.Ngaynhap >= @StartDate AND HDN.Ngaynhap <= @EndDate
END

EXEC SP_TimthoigianHDN '2023-01-01', '2023-05-31'


select *from Hoadonban
where MaHDN = 'HDHSRM'


-----------------------------------------------------------------
alter proc SP_thongkethangHDB
@thang int
as
begin
	SELECT CTB.ID, CTB.MaHDB, CTB.MaMP, CTB.Soluong, CTB.Dongia, CTB.Tongtien
    FROM ChitietHDB CTB inner join Hoadonban HDB ON 
	CTB.MaHDB = HDB.MaHDB
	where DATEPART(month,HDB.Ngayban) = @thang
end

exec SP_thongkethangHDB 5


-----------------------------------------------------------------
alter proc SP_thongkenamHDB
@nam int
as
begin
	SELECT CTB.ID, CTB.MaHDB, CTB.MaMP, CTB.Soluong, CTB.Dongia, CTB.Tongtien
    FROM ChitietHDB CTB inner join Hoadonban HDB ON 
	CTB.MaHDB = HDB.MaHDB
	where Year(Ngayban) = @nam
end


exec SP_thongkenamHDB 2023


-----------------------------------------------------------------
alter proc SP_thongkethangHDN
@thang int
as
begin
	SELECT CTN.ID, CTN.MaHDN, CTN.MaMP, CTN.Soluong, CTN.Dongia, CTN.Tongtien
    FROM ChitietHDN CTN inner join Hoadonnhap HDN ON 
	CTN.MaHDN = HDN.MaHDN
	where DATEPART(month,HDN.Ngaynhap) = @thang
end

exec SP_thongkethangHDN 5


-----------------------------------------------------------------
alter proc SP_thongkenamHDN
@nam int
as
begin
	SELECT CTN.ID, CTN.MaHDN, CTN.MaMP, CTN.Soluong, CTN.Dongia, CTN.Tongtien
    FROM ChitietHDN CTN inner join Hoadonnhap HDN ON 
	CTN.MaHDN = HDN.MaHDN
	where DATEPART(YEAR,HDN.Ngaynhap) = @nam
end

exec SP_thongkenamHDN 2023

select sum(Tongtien) as tongtien
from ChitietHDB



SELECT *FROM ChitietHDB
where MaHDB like'hdb%'
order by maHDB asc

