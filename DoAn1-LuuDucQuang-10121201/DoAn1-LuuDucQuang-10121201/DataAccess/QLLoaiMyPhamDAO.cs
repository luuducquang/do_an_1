using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn1_LuuDucQuang_10121201.DataAccess
{
    public class QLLoaiMyPhamDAO
    {
        QLMyPhamCuaCuaHangBanMyPhamEntities dbcon = new QLMyPhamCuaCuaHangBanMyPhamEntities();

        public List<LoaiMyPham> GetLoaiMyPhams()
        {
            return dbcon.LoaiMyPhams.ToList();
        }

        public void AddLoaiMP(LoaiMyPham x)
        {
            dbcon.LoaiMyPhams.Add(x);
            dbcon.SaveChanges();
        }

        public void DeleteLoaiMP(string dl)
        {
            LoaiMyPham a = dbcon.LoaiMyPhams.Find(dl);
            dbcon.LoaiMyPhams.Remove(a);
            dbcon.SaveChanges();
        }



        public void EditLoaiMP(LoaiMyPham x)
        {
            LoaiMyPham nv = dbcon.LoaiMyPhams.Find(x.MaloaiMP);
            nv.MaloaiMP = x.MaloaiMP;
            nv.TenloaiMP = x.TenloaiMP;
            dbcon.SaveChanges();
        }
    }
}
