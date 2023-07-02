using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn1_LuuDucQuang_10121201.DataAccess
{
    public class ChitietHDBDAO
    {
        QLMyPhamCuaCuaHangBanMyPhamEntities dbcon = new QLMyPhamCuaCuaHangBanMyPhamEntities();

        public List<ChitietHDB> GetChitietHDBs()
        {
            return dbcon.ChitietHDBs.ToList();
        }

        public ChitietHDB GettheomaHDB(string x)
        {
            return dbcon.ChitietHDBs.Where(s => s.MaHDB == x).First();
        }

        public List<ChitietHDB> Getmahdblist(string mahdb)
        {
            return dbcon.ChitietHDBs.Where(p => p.MaHDB == mahdb).ToList<ChitietHDB>();
        }

        public List<SP_SPbanchay_Result> GetSPbanchay()
        {
            //return dbcon.ChitietHDBs.OrderByDescending(p => p.Soluong).ToList<ChitietHDB>();
            return dbcon.SP_SPbanchay().ToList();
        }

        public List<SP_SPbancham_Result> GetSPbancham()
        {
            return dbcon.SP_SPbancham().ToList();
        }
        public List<SP_Timthoigian_Result> Getthoigian(DateTime start, DateTime end)
        {
            return dbcon.SP_Timthoigian(start,end).ToList();
        }

        public List<SP_thongkethangHDB_Result> Gettheothang(int a)
        {
            return dbcon.SP_thongkethangHDB(a).ToList();
        }

        public List<SP_thongkenamHDB_Result> Gettheonam(int a)
        {
            return dbcon.SP_thongkenamHDB(a).ToList();
        }

        public void AddHDB(ChitietHDB x)
        {
            dbcon.ChitietHDBs.Add(x);
            dbcon.SaveChanges();
        }

        public void DeleteHDB(string dl)
        {
            ChitietHDB a = dbcon.ChitietHDBs.Find(dl);
            dbcon.ChitietHDBs.Remove(a);
            dbcon.SaveChanges();
        }

        public void UpAmount(string x, int a)
        {
            ChitietHDB dhn = dbcon.ChitietHDBs.Where(s => s.MaMP == x).First();
            dhn.Soluong += a;
            dbcon.SaveChanges();
        }

        public void EditHDB(ChitietHDB x)
        {
            ChitietHDB ct = new ChitietHDB();
            ct.ID = x.ID;
            ct.MaHDB = x.MaHDB;
            ct.MaMP = x.MaMP;
            ct.Soluong = x.Soluong;
            ct.Dongia = x.Dongia;
            ct.Tongtien = x.Tongtien;
            DeleteHDB(x.ID);
            dbcon.ChitietHDBs.Add(ct);
            dbcon.SaveChanges();
        }
    }
}
