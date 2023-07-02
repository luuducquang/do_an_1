using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoAn1_LuuDucQuang_10121201.DataAccess;
using System.Windows.Forms;

namespace DoAn1_LuuDucQuang_10121201.Bussiness
{
    public class QLHoaDonNhapBUS
    {
        QLHoaDonNhapDAO hoadonnhapDAO = new QLHoaDonNhapDAO();
        QLMyPhamDAO myphamDAO = new QLMyPhamDAO();
        QLNhaCungCapDAO nhaCungCapDAO = new QLNhaCungCapDAO();
        QLNhanVienDAO nhanVienDAO = new QLNhanVienDAO();
        public List<Hoadonnhap> hdn;

        QLTonKhoDAO tonKhoDAO = new QLTonKhoDAO();
        public List<Tonkho> tk;
        public List<Hoadonnhap> GetHoadonnhaps()
        {
            return hoadonnhapDAO.GetHoadonnhaps();
        }

        public List<NhaCungCap> GetNhaCungCaps()
        {
            return nhaCungCapDAO.GetNhaCungCaps();
        }

        public List<NhanVien> GetNhanViens()
        {
            return nhanVienDAO.GetNhanViens();
        }
        public List<ThongTinMyPham> GetThongTinMyPhams()
        {
            return myphamDAO.GetThongTinMyPhams();
        }

        public List<Hoadonnhap> GetHoadonnhaps(string mamp)
        {
            return hoadonnhapDAO.GetHoadonnhaps(mamp);
        }

        

        public void AddHoadonnhap(Hoadonnhap hd)
        {
            Hoadonnhap hoadonnhap = hoadonnhapDAO.GetHoadonnhaps().Find(s => s.MaHDN == hd.MaHDN);
            if (hoadonnhap == null)
            {
                hoadonnhapDAO.AddHoadonnhap(hd);
                MessageBox.Show("Thêm thông tin thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show("Mã hoá đơn nhập đã tồn tại");
            }
        }

        public void DeleteHoadonnhap(Hoadonnhap hoadonnhap)
        {
            hoadonnhapDAO.DeleteHoadonnhap(hoadonnhap.MaHDN);
        }


        public void EditHoadonnhap(Hoadonnhap hd)
        {
            //Hoadonnhap hoadon = hoadonnhapDAO.GetHoadonnhaps().Find(s => s.MaHDN == hd.MaHDN);
            //QLTonKhoBUS.sltoncu = (int)hoadon.Soluong;

            //if (hoadon != null)
            //{
            hoadonnhapDAO.EditHDN(hd);

            //}
        }

        

    }
}
