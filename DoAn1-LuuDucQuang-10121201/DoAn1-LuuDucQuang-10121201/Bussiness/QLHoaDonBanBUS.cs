using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoAn1_LuuDucQuang_10121201.DataAccess;
using System.Windows.Forms;

namespace DoAn1_LuuDucQuang_10121201.Bussiness
{
    public class QLHoaDonBanBUS
    {
        QLHoaDonBanDAO hoadonbanDAO = new QLHoaDonBanDAO();
        QLHoaDonNhapDAO hoaDonNhapDAO = new QLHoaDonNhapDAO();
        QLMyPhamDAO myphamDAO = new QLMyPhamDAO();
        QLNhanVienDAO nhanVienDAO = new QLNhanVienDAO();
        QLKhachHangDAO khachhangDAO = new QLKhachHangDAO();
        public List<Hoadonban> hdb;

        QLTonKhoDAO tonKhoDAO = new QLTonKhoDAO();
        public List<Tonkho> tk;
        public List<Hoadonban> GetHoadonbans()
        {
            return hoadonbanDAO.GetHoadonbans();
        }

        public List<KhachHang> GetKhachHangs()
        {
            return khachhangDAO.GetKhachHangs();
        }

        public List<NhanVien> GetNhanViens()
        {
            return nhanVienDAO.GetNhanViens();
        }

        public List<ThongTinMyPham> GetThongTinMyPhams()
        {
            return myphamDAO.GetThongTinMyPhams();
        }

        public List<Hoadonban> GetHoadonbans(string mahdb)
        {
            return hoadonbanDAO.GetHoadonbans(mahdb);
        }

        public Hoadonban gettheomhdb(string mahdb)
        {
            return hoadonbanDAO.gettheomhdb(mahdb);
        }

        public void AddHoadonban(Hoadonban hd)
        {
            Hoadonban hoadonban = hoadonbanDAO.GetHoadonbans().Find(s => s.MaHDB == hd.MaHDB);
            if (hoadonban == null)
            {
                hoadonbanDAO.AddHoadonban(hd);
                MessageBox.Show("Thêm thông tin thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show("Mã hoá đơn bán đã tồn tại");
            }
        }

        public void DeleteHoadonban(Hoadonban hoadonban)
        {
                hoadonbanDAO.DeleteHoadonban(hoadonban.MaHDB);
        }


        public void EditHoadonban(Hoadonban hd)
        {
            hoadonbanDAO.EditHDB(hd);

        }


        
    }
}
