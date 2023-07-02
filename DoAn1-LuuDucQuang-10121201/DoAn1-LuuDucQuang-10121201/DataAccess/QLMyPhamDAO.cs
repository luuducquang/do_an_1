using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn1_LuuDucQuang_10121201.DataAccess
{
    public class QLMyPhamDAO
    {
        QLMyPhamCuaCuaHangBanMyPhamEntities dbcon = new QLMyPhamCuaCuaHangBanMyPhamEntities();

        public List<ThongTinMyPham> GetThongTinMyPhams()
        {
            return dbcon.ThongTinMyPhams.ToList();
        }
        public ThongTinMyPham getTheomasp(string mamp) => dbcon.ThongTinMyPhams.Find(mamp);
        
            
        
        public List<ThongTinMyPham> GetThongTinMyPhams(string mancc)
        {
            return dbcon.ThongTinMyPhams.Where(p => p.MaNCC == mancc).ToList<ThongTinMyPham>();
        }

        public List<ThongTinMyPham> Getmaloaimp(string maloaimp)
        {
            return dbcon.ThongTinMyPhams.Where(p => p.MaloaiMP == maloaimp).ToList<ThongTinMyPham>();
        }

        public void AddMypham(ThongTinMyPham mp)
        {
            dbcon.ThongTinMyPhams.Add(mp);
            dbcon.SaveChanges();
        }
        
        public void Editmp(ThongTinMyPham mp)
        {
            dbcon.ThongTinMyPhams.Find(mp.MaMP);
            ThongTinMyPham myPham = new ThongTinMyPham();
            myPham.TenMP = mp.TenMP;
            myPham.Dungtich = mp.Dungtich;
            myPham.MaloaiMP = mp.MaloaiMP;
            myPham.MaNCC = mp.MaNCC;
            myPham.MaMP = mp.MaMP;
            myPham.Giaban = mp.Giaban;
            myPham.Mota = mp.Mota;
            Deletemypham(mp.MaMP);
            dbcon.ThongTinMyPhams.Add(myPham);
            dbcon.SaveChanges();
        }

        public void Deletemypham(string mamp)
        {
            ThongTinMyPham cn = dbcon.ThongTinMyPhams.Find(mamp);
            dbcon.ThongTinMyPhams.Remove(cn);
            dbcon.SaveChanges();
        }
        
        
    }
}
