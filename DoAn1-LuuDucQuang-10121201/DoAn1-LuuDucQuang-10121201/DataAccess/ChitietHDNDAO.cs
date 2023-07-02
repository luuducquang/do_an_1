using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn1_LuuDucQuang_10121201.DataAccess
{
    public class ChitietHDNDAO
    {
        QLMyPhamCuaCuaHangBanMyPhamEntities dbcon = new QLMyPhamCuaCuaHangBanMyPhamEntities();

        public List<ChitietHDN> GetChitietHDNs()
        {
            return dbcon.ChitietHDNs.ToList();
        }


        public List<SP_SPsaphet_Result> GetSPsaphet()
        {
            return dbcon.SP_SPsaphet().ToList();
        }

        public List<SP_TimthoigianHDN_Result> Getthoigian(DateTime start, DateTime end)
        {
            return dbcon.SP_TimthoigianHDN(start,end).ToList();
        }

        public List<SP_thongkethangHDN_Result> Gettheothang(int a)
        {
            return dbcon.SP_thongkethangHDN(a).ToList();
        }

        public List<SP_thongkenamHDN_Result> Gettheonam(int a)
        {
            return dbcon.SP_thongkenamHDN(a).ToList();
        }
        public void AddHDN(ChitietHDN x)
        {
            dbcon.ChitietHDNs.Add(x);
            dbcon.SaveChanges();
        }

        public void UpAmount(string x, int a)
        {
            ChitietHDN dhn = dbcon.ChitietHDNs.Where(s=>s.MaMP==x).First();
            dhn.Soluong += a;
            dbcon.SaveChanges();
        }

        public void DeleteHDN(string dl)
        {
            ChitietHDN a = dbcon.ChitietHDNs.Find(dl);
            dbcon.ChitietHDNs.Remove(a);
            dbcon.SaveChanges();
        }



        public void EditHDN(ChitietHDN x)
        {
            ChitietHDN ct = new ChitietHDN();
            ct.ID = x.ID;
            ct.MaHDN = x.MaHDN;
            ct.MaMP = x.MaMP;
            ct.Soluong = x.Soluong;
            ct.Dongia = x.Dongia;
            ct.Tongtien = x.Tongtien;
            DeleteHDN(x.ID);
            dbcon.ChitietHDNs.Add(ct);
            dbcon.SaveChanges();
        }
    }
}
