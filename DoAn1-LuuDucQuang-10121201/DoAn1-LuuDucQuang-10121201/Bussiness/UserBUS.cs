using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoAn1_LuuDucQuang_10121201.DataAccess;
using System.Windows.Forms;

namespace DoAn1_LuuDucQuang_10121201.Bussiness
{
    public class UserBUS
    {
        List<DangNhap> list;

        UserDAO userDAO = new UserDAO();

        public List<DangNhap> listUser()
        {
            list = userDAO.listUser();
            return list;
        }
        public DangNhap getUs(string un)
        {
            return userDAO.getUs(un);

        }
        public bool isLogin(DangNhap user)
        {
            return userDAO.GetUser(user) != null;
        }
        public bool Addtk(DangNhap nv)
        {
            DangNhap NhanVien1 = listUser().Find(s => s.username == nv.username);

            if (NhanVien1 == null)
            {
                userDAO.Addtk(nv);
                MessageBox.Show("Thêm thông tin thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            else
            {
                MessageBox.Show("Tài khoản đã tồn tại");
                return false;
            }
        }

        public void DeleteUser(DangNhap nv)
        {
            DangNhap NhanVien1 = list.Find(s => s.username == nv.username);
            if (NhanVien1 != null)
            {
                userDAO.DeleteUser(nv.username);
            }
        }

        public void EditPass(DangNhap xg)
        {
            DangNhap dangnhap = list.Find(s => s.username == xg.username);
            if (dangnhap != null)
            {
                userDAO.EditPass(xg);
            }
        }

    }
}
