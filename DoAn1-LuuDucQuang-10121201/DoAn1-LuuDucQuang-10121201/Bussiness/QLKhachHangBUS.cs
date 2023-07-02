using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DoAn1_LuuDucQuang_10121201.DataAccess;

namespace DoAn1_LuuDucQuang_10121201.Bussiness
{
    public class QLKhachHangBUS
    {
        QLKhachHangDAO khachHangDAO = new QLKhachHangDAO();
        public List<KhachHang> kh;
        public List<KhachHang> GetKhachHangs()
        {
            return khachHangDAO.GetKhachHangs();
        }

        public KhachHang Gettheomakh(string makh)
        {
            return khachHangDAO.Gettheomakh(makh);
        }


        public void AddKH(KhachHang x)
        {
            KhachHang khachHang = khachHangDAO.GetKhachHangs().Find(s => s.MaKH == x.MaKH  );
            if (khachHang == null)
            {
                khachHangDAO.AddKH(x);
                MessageBox.Show("Thêm thông tin thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show("Mã khách hàng đã tồn tại");
            }
        }

        public void DeleteKH(KhachHang d)
        {
            //NhanVien nv1 = nv.Find(s => s.MaNCC == d.MaNCC);
            //if (nv1 != null)
            //{
            //}
            khachHangDAO.DeleteKH(d.MaKH);
        }

        public void EditKH(KhachHang xg)
        {
            //NhanVien nv2 = nv.Find(s => s.MaNCC == xg.MaNCC);
            //if (nv2 != null)
            //{
            //}
            khachHangDAO.EditKH(xg);
        }
    }
}
