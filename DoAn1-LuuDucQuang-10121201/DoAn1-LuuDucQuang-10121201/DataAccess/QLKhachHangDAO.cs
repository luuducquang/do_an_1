using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn1_LuuDucQuang_10121201.DataAccess
{
    public class QLKhachHangDAO
    {
        QLMyPhamCuaCuaHangBanMyPhamEntities dbcon = new QLMyPhamCuaCuaHangBanMyPhamEntities();

        public List<KhachHang> GetKhachHangs()
        {
            return dbcon.KhachHangs.ToList();
        }

        public KhachHang Gettheomakh(string makh)
        {
            return dbcon.KhachHangs.Where(s => s.MaKH == makh).FirstOrDefault();
        }

        public void AddKH(KhachHang x)
        {
            dbcon.KhachHangs.Add(x);
            dbcon.SaveChanges();
        }

        public void DeleteKH(string dl)
        {
            KhachHang a = dbcon.KhachHangs.Find(dl);
            dbcon.KhachHangs.Remove(a);
            dbcon.SaveChanges();
        }



        public void EditKH(KhachHang x)
        {
            KhachHang nv = dbcon.KhachHangs.Find(x.MaKH);
            nv.MaKH = x.MaKH;
            nv.TenKH = x.TenKH;
            nv.GioiTinh = x.GioiTinh;
            nv.DiaChi = x.DiaChi;
            nv.Sdt = x.Sdt;
            DeleteKH(x.MaKH);
            dbcon.KhachHangs.Add(nv);
            dbcon.SaveChanges();
        }
    }
}
