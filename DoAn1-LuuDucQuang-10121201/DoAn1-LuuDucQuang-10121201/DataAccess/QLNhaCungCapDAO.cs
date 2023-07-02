using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn1_LuuDucQuang_10121201.DataAccess
{
    public class QLNhaCungCapDAO
    {
        QLMyPhamCuaCuaHangBanMyPhamEntities dbcon = new QLMyPhamCuaCuaHangBanMyPhamEntities();

        public List<NhaCungCap> GetNhaCungCaps()
        {
            return dbcon.NhaCungCaps.ToList();
        }

        public void AddNCC(NhaCungCap x)
        {
            dbcon.NhaCungCaps.Add(x);
            dbcon.SaveChanges();
        }

        public void DeleteNCC(string dl)
        {
            NhaCungCap a = dbcon.NhaCungCaps.Find(dl);
            dbcon.NhaCungCaps.Remove(a);
            dbcon.SaveChanges();
        }



        public void EditNCC(NhaCungCap x)
        {
            NhaCungCap nv = dbcon.NhaCungCaps.Find(x.MaNCC);
            nv.MaNCC = x.MaNCC;
            nv.TenNCC = x.TenNCC;
            nv.Diachi = x.Diachi;
            nv.Sdt = x.Sdt;
            dbcon.SaveChanges();
        }
    }
}
