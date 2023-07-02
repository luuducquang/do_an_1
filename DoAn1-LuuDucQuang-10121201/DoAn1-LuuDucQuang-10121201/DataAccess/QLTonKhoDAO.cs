using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn1_LuuDucQuang_10121201.DataAccess
{
    public class QLTonKhoDAO
    {
        QLMyPhamCuaCuaHangBanMyPhamEntities dbcon = new QLMyPhamCuaCuaHangBanMyPhamEntities();

        public List<Tonkho> GetTonkhos()
        {
            return dbcon.Tonkhoes.ToList();
        }
        public Tonkho gettheoma(string mamp)
        {
            return dbcon.Tonkhoes.Where(s => s.MaMP == mamp).First();
         }

        public void AddTonkho(Tonkho x)
        {
            dbcon.Tonkhoes.Add(x);
            dbcon.SaveChanges();
        }


        public void DeleteTonkho(string dl)
        {
            Tonkho a = dbcon.Tonkhoes.Find(dl);
            dbcon.Tonkhoes.Remove(a);
            dbcon.SaveChanges();
        }



        public void EditTonkho(Tonkho x)
        {
            Tonkho nv = dbcon.Tonkhoes.Find(x.MaMP);
            nv.MaMP = x.MaMP;
            nv.SLton = x.SLton;
            dbcon.SaveChanges();
        }

        public void EditSL(Tonkho x,int a)
        {
            Tonkho tk = dbcon.Tonkhoes.Find(x.MaMP);
            tk.SLton += a;
            dbcon.SaveChanges();
        }

        public void EditSLTru(string mamp, int a)
        {
            Tonkho tk = dbcon.Tonkhoes.Find(mamp);
            tk.SLton -= a;
            dbcon.SaveChanges();
        }

        public void EditSLSua(string x,int m,int c)
        {
            Tonkho tk = dbcon.Tonkhoes.Find(x);
            tk.SLton = tk.SLton + (m - c);
            dbcon.SaveChanges();
        }

        public void EditSLSuaBan(string x, int c, int m)
        {
            Tonkho tk = dbcon.Tonkhoes.Find(x);
            tk.SLton = tk.SLton + (c - m);
            dbcon.SaveChanges();
        }

        public void SLSapHet(Tonkho x,int a)
        {
            Tonkho nv = dbcon.Tonkhoes.Find(x.MaMP);
            nv.SLton = x.SLton;
            dbcon.SaveChanges();
        }


        

    }
}
