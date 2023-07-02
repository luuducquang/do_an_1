using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn1_LuuDucQuang_10121201.DataAccess
{
    public class QLNhanVienDAO
    {
        QLMyPhamCuaCuaHangBanMyPhamEntities dbcon = new QLMyPhamCuaCuaHangBanMyPhamEntities();

        public List<NhanVien> GetNhanViens()
        {
            return dbcon.NhanViens.ToList();
        }

        public NhanVien Gettheomanv(string manv)
        {
            return dbcon.NhanViens.Where(s => s.MaNV == manv).FirstOrDefault();
        }


        public void AddNhanVien(NhanVien x)
        {
            dbcon.NhanViens.Add(x);
            dbcon.SaveChanges();
        }

        public void DeleteNhanVien(string dl)
        {
            NhanVien a = dbcon.NhanViens.Find(dl);
            dbcon.NhanViens.Remove(a);
            dbcon.SaveChanges();
        }



        public void EditNhanVien(NhanVien x)
        {
            NhanVien nv = dbcon.NhanViens.Find(x.MaNV);
            nv.MaNV = x.MaNV;
            nv.TenNV = x.TenNV;
            nv.GioiTinh = x.GioiTinh;
            nv.DiaChi = x.DiaChi;
            nv.Sdt = x.Sdt;
            dbcon.SaveChanges();
        }
    }
}
