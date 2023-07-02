using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn1_LuuDucQuang_10121201.DataAccess
{
    public class UserDAO
    {
        QLMyPhamCuaCuaHangBanMyPhamEntities dbcon = new QLMyPhamCuaCuaHangBanMyPhamEntities();


        public DangNhap GetUser(DangNhap user)
        {
            return dbcon.DangNhaps.SingleOrDefault(
                us => us.username == user.username && us.password == user.password);
        }
        public DangNhap getUs(string un)
        {
            return dbcon.DangNhaps.Where(s => s.username == un).FirstOrDefault();
        }
        public List<DangNhap> listUser()
        {
            return dbcon.DangNhaps.ToList<DangNhap>();
        }
        public void Addtk(DangNhap user)
        {
            dbcon.DangNhaps.Add(user);
            dbcon.SaveChanges();
        }

        public void DeleteUser(string UserName)
        {
            DangNhap Nv = dbcon.DangNhaps.Find(UserName);
            dbcon.DangNhaps.Remove(Nv);
            dbcon.SaveChanges();
        }

        public void EditPass(DangNhap x)
        {
            DangNhap dangnhap = dbcon.DangNhaps.Find(x.username);
            dangnhap.password = x.password;
            dangnhap.quyen = x.quyen;
            dbcon.SaveChanges();
        }
    }
}
