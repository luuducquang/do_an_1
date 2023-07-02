using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn1_LuuDucQuang_10121201.DataAccess
{
    public class QLHoaDonBanDAO
    {
        QLMyPhamCuaCuaHangBanMyPhamEntities dbcon = new QLMyPhamCuaCuaHangBanMyPhamEntities();

        public List<Hoadonban> GetHoadonbans()
        {
            return dbcon.Hoadonbans.ToList();
        }


        public List<Hoadonban> GetHoadonbans(string mahdb)
        {
            return dbcon.Hoadonbans.Where(p => p.MaHDB == mahdb).ToList<Hoadonban>();
        }

        public Hoadonban gettheomhdb(string mahdb)
        {
            return dbcon.Hoadonbans.Where(p => p.MaHDB == mahdb).First();
        }

        public void AddHoadonban(Hoadonban hdb)
        {
            dbcon.Hoadonbans.Add(hdb);
            dbcon.SaveChanges();
        }

        public void EditHDB(Hoadonban hdb)
        {
            dbcon.Hoadonbans.Find(hdb.MaHDB);
            Hoadonban hoadonban = new Hoadonban();
            hoadonban.MaHDB = hdb.MaHDB;
            hoadonban.MaNV = hdb.MaNV;
            hoadonban.MaKH = hdb.MaKH;
            hoadonban.Ngayban = hdb.Ngayban;
            DeleteHoadonban(hdb.MaHDB);
            dbcon.Hoadonbans.Add(hoadonban);
            dbcon.SaveChanges();
        }

        public void DeleteHoadonban(string mahdb)
        {
            Hoadonban hd = dbcon.Hoadonbans.Find(mahdb);
            dbcon.Hoadonbans.Remove(hd);
            dbcon.SaveChanges();
        }

        
    }
}
