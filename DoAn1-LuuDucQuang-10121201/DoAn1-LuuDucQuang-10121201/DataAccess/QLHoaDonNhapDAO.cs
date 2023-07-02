using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn1_LuuDucQuang_10121201.DataAccess
{
    public class QLHoaDonNhapDAO
    {
        QLMyPhamCuaCuaHangBanMyPhamEntities dbcon = new QLMyPhamCuaCuaHangBanMyPhamEntities();

        public List<Hoadonnhap> GetHoadonnhaps()
        {
            return dbcon.Hoadonnhaps.ToList();
        }

        public List<Hoadonnhap> GetHoadonnhaps(string mahdn)
        {
            return dbcon.Hoadonnhaps.Where(p => p.MaHDN == mahdn).ToList<Hoadonnhap>();
        }
        public Hoadonnhap gethdnhap(string mahd)
        {
            return dbcon.Hoadonnhaps.Where(p => p.MaHDN == mahd).First();

        }

        public void AddHoadonnhap(Hoadonnhap hdn)
        {
            dbcon.Hoadonnhaps.Add(hdn);
            dbcon.SaveChanges();
        }

        public void EditHDN(Hoadonnhap hdn)
        {
            dbcon.Hoadonnhaps.Find(hdn.MaHDN);
            Hoadonnhap hoadonnhap = new Hoadonnhap();
            hoadonnhap.MaHDN = hdn.MaHDN;
            hoadonnhap.MaNV = hdn.MaNV;
            hoadonnhap.Ngaynhap = hdn.Ngaynhap;
            DeleteHoadonnhap(hdn.MaHDN);
            dbcon.Hoadonnhaps.Add(hoadonnhap);
            dbcon.SaveChanges();
        }

        public void DeleteHoadonnhap(string mahdn)
        {
            Hoadonnhap hd = dbcon.Hoadonnhaps.Find(mahdn);
            dbcon.Hoadonnhaps.Remove(hd);
            dbcon.SaveChanges();
        }


        //public void DonGia(Hoadonnhap hdn,int gia)
        //{
        //    //dbcon.Hoadonnhaps.Find(hdn.MaMP);
        //    //Hoadonnhap a = new Hoadonnhap();

        //    //Console.WriteLine('a' + a.Dongia);
        //    //dbcon.SaveChanges();

        //    Hoadonnhap tk = dbcon.Hoadonnhaps.Find(hdn.MaMP);
        //    gia = tk.Dongia.GetValueOrDefault();
        //    dbcon.SaveChanges();
        //}


    }
}
