using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoAn1_LuuDucQuang_10121201.DataAccess;
using System.Windows.Forms;

namespace DoAn1_LuuDucQuang_10121201.Bussiness
{
    public class QLMyPhamBUS
    {
        List<ThongTinMyPham> lmp;
        QLMyPhamDAO myphamDAO = new QLMyPhamDAO();
        QLLoaiMyPhamDAO loaiMyPhamDAO = new QLLoaiMyPhamDAO();
        QLNhaCungCapDAO nhaCungCapDAO = new QLNhaCungCapDAO();
        public List<NhaCungCap> GetNhaCungCaps()
        {
            return nhaCungCapDAO.GetNhaCungCaps();
        }

        public List<LoaiMyPham> GetLoaiMyPhams()
        {
            return loaiMyPhamDAO.GetLoaiMyPhams();
        }

        public List<ThongTinMyPham> GetThongTinMyPhams()
        {
            return myphamDAO.GetThongTinMyPhams();
        }

        public List<ThongTinMyPham> GetThongTinMyPhams(string mancc)
        {
            return myphamDAO.GetThongTinMyPhams(mancc);
        }

        public List<ThongTinMyPham> Getmaloaimp(string maloaimp)
        {
            return myphamDAO.Getmaloaimp(maloaimp);
        }

        public ThongTinMyPham getTheomasp(string mamp)
        {
            return myphamDAO.getTheomasp(mamp);
        }

        public void AddMP(ThongTinMyPham mp)
        {
            ThongTinMyPham myPham = myphamDAO.GetThongTinMyPhams().Find(s => s.MaMP == mp.MaMP);
            if (myPham == null)
            {
                myphamDAO.AddMypham(mp);
                MessageBox.Show("Thêm thông tin thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show("Mã mỹ phẩm đã tồn tại");
            }
        }

        public void DeleteMP(ThongTinMyPham mamp)
        {
            ThongTinMyPham sv = myphamDAO.GetThongTinMyPhams().Find(s => s.MaMP == mamp.MaMP);
            if (mamp != null)
            {
                myphamDAO.Deletemypham(mamp.MaMP);  
            }
        }

        public void Editmp(ThongTinMyPham mp)
        {
            ThongTinMyPham myPham = myphamDAO.GetThongTinMyPhams().Find(s => s.MaMP == mp.MaMP);
            if (myPham != null)
            {
                myphamDAO.Editmp(mp);

            }
        }

    }
}
